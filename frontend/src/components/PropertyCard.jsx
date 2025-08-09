import { Card, CardContent, CardMedia, Typography, CardActions, Button, Stack, Chip } from "@mui/material";
import api from "../api/axios";
import { useAuth } from "../auth/AuthContext";
import { Link as RouterLink } from "react-router-dom";

export default function PropertyCard({ p, onToggled }) {
  const { token } = useAuth();
  const img = (p.imageUrls && p.imageUrls[0]) || "/img/placeholder.jpg";

  const toggle = async () => {
    if (!token) { alert("Please login to save properties"); return; }
    await api.post(`/favorites/${p.id}`);
    onToggled?.(p.id);
  };

  return (
    <Card>
      <CardMedia component="img" height="160" image={img} alt={p.title} />
      <CardContent>
        <Typography variant="h6">{p.title}</Typography>
        <Typography variant="body2" color="text.secondary">{p.address}</Typography>
        <Stack direction="row" spacing={1} mt={1}>
          <Chip label={`${p.bedrooms} bd`} />
          <Chip label={`${p.bathrooms} ba`} />
          <Chip label={`${p.carSpots} car`} />
          <Chip label={p.listingType} />
        </Stack>
        <Typography variant="h6" mt={1}>${p.price}</Typography>
      </CardContent>
      <CardActions>
        <Button size="small" component={RouterLink} to={`/properties/${p.id}`}>Details</Button>
        <Button size="small" onClick={toggle}>Save / Unsave</Button>
      </CardActions>
    </Card>
  );
}
