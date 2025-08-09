import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import { useAuth } from "../auth/AuthContext";
import { Button, Container, TextField, Typography, Stack } from "@mui/material";
import { useNavigate } from "react-router-dom";

const schema = yup.object({
  email: yup.string().email().required(),
  password: yup.string().required()
});

export default function Login() {
  const { login } = useAuth();
  const nav = useNavigate();
  const { register, handleSubmit, formState: { errors, isSubmitting } } =
    useForm({ resolver: yupResolver(schema) });

  const onSubmit = async (v) => {
    try {
      await login(v.email, v.password);
      nav("/properties");
    } catch (e) {
      alert("Invalid email/password");
    }
  };

  return (
    <Container maxWidth="xs" sx={{ mt: 6 }}>
      <Typography variant="h5" mb={2}>Login</Typography>
      <Stack component="form" onSubmit={handleSubmit(onSubmit)} spacing={2}>
        <TextField label="Email" {...register("email")} error={!!errors.email} helperText={errors.email?.message}/>
        <TextField label="Password" type="password" {...register("password")} error={!!errors.password} helperText={errors.password?.message}/>
        <Button variant="contained" type="submit" disabled={isSubmitting}>Login</Button>
      </Stack>
    </Container>
  );
}
