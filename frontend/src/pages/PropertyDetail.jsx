import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import api from "../api/axios";
import { Container, Typography, Box, Chip, Stack } from "@mui/material";

export default function PropertyDetail() {
  const { id } = useParams();
  const [property, setProperty] = useState(null);

  useEffect(() => {
    api.get(`/properties/${id}`).then((res) => setProperty(res.data));
  }, [id]);

  if (!property) return <Container sx={{ mt: 4 }}>Loading...</Container>;

  return (
    <Container sx={{ mt: 4 }}>
      {/* Title */}
      <Typography variant="h4" gutterBottom>
        {property.title}
      </Typography>

      {/* Image */}
      {property.imageUrls?.length > 0 && (
        <Box
          component="img"
          src={property.imageUrls[0]} // show first image
          alt={property.title}
          sx={{
            width: "100%",
            height: 400,
            objectFit: "cover",
            borderRadius: 2,
            mb: 3
          }}
        />
      )}

      {/* Price & Listing Type */}
      <Typography variant="h5" color="primary" gutterBottom>
        {property.listingType === "Sale"
          ? `$${property.price.toLocaleString()}`
          : `$${property.price}/month`}
      </Typography>

      {/* Address */}
      <Typography variant="body1" gutterBottom>
        {property.address}
      </Typography>

      {/* Features */}
      <Stack direction="row" spacing={1} sx={{ my: 2 }}>
        <Chip label={`${property.bedrooms} Beds`} />
        <Chip label={`${property.bathrooms} Baths`} />
        <Chip label={`${property.carSpots} Car Spots`} />
      </Stack>

      {/* Description */}
      <Typography variant="body2">{property.description}</Typography>
    </Container>
  );
}
