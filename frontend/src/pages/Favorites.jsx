import { useEffect, useState } from "react";
import { Container, Grid, Typography } from "@mui/material";
import api from "../api/axios";
import PropertyCard from "../components/PropertyCard";

export default function Favorites() {
  const [items, setItems] = useState([]);

  const load = async () => {
    const { data } = await api.get("/favorites");
    setItems(data);
  };

  useEffect(() => { load(); }, []);

  return (
    <Container sx={{ mt: 4 }}>
      <Typography variant="h5" mb={2}>Saved Properties</Typography>
      <Grid container spacing={2}>
        {items.map(p => (
          <Grid item xs={12} sm={6} md={4} lg={3} key={p.id}>
            <PropertyCard p={p} onToggled={load} />
          </Grid>
        ))}
      </Grid>
    </Container>
  );
}
