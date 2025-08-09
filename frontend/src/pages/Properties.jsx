// Properties.jsx
import { useEffect, useState } from "react";
import { Container, Grid, Typography } from "@mui/material";
import { useSearchParams } from "react-router-dom";
import api from "../api/axios";
import FiltersBar from "../components/FiltersBar";
import PropertyCard from "../components/PropertyCard";

export default function Properties() {
  const [params] = useSearchParams();
  const [data, setData] = useState({ items: [], total: 0, page: 1, pageSize: 12 });
  const [loading, setLoading] = useState(true);

  const load = async () => {
    setLoading(true);
    const q = Object.fromEntries(params);
    const res = await api.get("/properties", { params: q });
    const d = res.data;

    // Normalize: support either an array OR {items,total,...}
    if (Array.isArray(d)) {
      setData({ items: d, total: d.length, page: 1, pageSize: d.length });
    } else {
      setData({
        items: d.items ?? [],
        total: d.total ?? 0,
        page: d.page ?? 1,
        pageSize: d.pageSize ?? (d.items?.length ?? 12)
      });
    }

    setLoading(false);
  };

  useEffect(() => { load(); /* eslint-disable-next-line */ }, [params.toString()]);

  if (loading) return <Container sx={{ mt: 4 }}><Typography>Loading…</Typography></Container>;

  return (
    <Container sx={{ mt: 4 }}>
      <Typography variant="h5" mb={2}>Properties</Typography>
      <FiltersBar />
      <Grid container spacing={2}>
        {(data.items ?? []).map(p => (
          <Grid item xs={12} sm={6} md={4} lg={3} key={p.id}>
            <PropertyCard p={p} onToggled={load} />
          </Grid>
        ))}
      </Grid>
    </Container>
  );
}
