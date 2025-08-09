import { useEffect, useState } from "react";
import { Stack, TextField, MenuItem, Button } from "@mui/material";
import { useSearchParams } from "react-router-dom";

export default function FiltersBar() {
  const [params, setParams] = useSearchParams();
  const [form, setForm] = useState({
    q: params.get("q") || "",
    minPrice: params.get("minPrice") || "",
    maxPrice: params.get("maxPrice") || "",
    bedrooms: params.get("bedrooms") || "",
    bathrooms: params.get("bathrooms") || "",
    suburb: params.get("suburb") || "",
    listingType: params.get("listingType") || ""
  });

  useEffect(() => {
    // sync when URL changes externally
    setForm(f => ({
      ...f,
      q: params.get("q") || "",
      minPrice: params.get("minPrice") || "",
      maxPrice: params.get("maxPrice") || "",
      bedrooms: params.get("bedrooms") || "",
      bathrooms: params.get("bathrooms") || "",
      suburb: params.get("suburb") || "",
      listingType: params.get("listingType") || ""
    }));
  }, [params]);

  const apply = () => {
    const next = new URLSearchParams();
    Object.entries(form).forEach(([k, v]) => { if (v) next.set(k, v); });
    setParams(next);
  };

  const clear = () => setParams({});

  return (
    <Stack direction="row" spacing={2} sx={{ mb: 2 }} useFlexGap flexWrap="wrap">
      <TextField label="Search" value={form.q} onChange={e => setForm({...form, q: e.target.value})} size="small" />
      <TextField label="Min Price" value={form.minPrice} onChange={e => setForm({...form, minPrice: e.target.value})} type="number" size="small" />
      <TextField label="Max Price" value={form.maxPrice} onChange={e => setForm({...form, maxPrice: e.target.value})} type="number" size="small" />
      <TextField label="Beds" value={form.bedrooms} onChange={e => setForm({...form, bedrooms: e.target.value})} type="number" size="small" />
      <TextField label="Baths" value={form.bathrooms} onChange={e => setForm({...form, bathrooms: e.target.value})} type="number" size="small" />
      <TextField label="Suburb/City" value={form.suburb} onChange={e => setForm({...form, suburb: e.target.value})} size="small" />
      <TextField label="Type" value={form.listingType} onChange={e => setForm({...form, listingType: e.target.value})} select size="small" sx={{ minWidth: 130 }}>
        <MenuItem value="">Any</MenuItem>
        <MenuItem value="Sale">Sale</MenuItem>
        <MenuItem value="Rent">Rent</MenuItem>
      </TextField>
      <Button variant="contained" onClick={apply}>Apply</Button>
      <Button onClick={clear}>Clear</Button>
    </Stack>
  );
}
