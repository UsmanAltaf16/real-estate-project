import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import { useAuth } from "../auth/AuthContext";
import { Button, Container, TextField, Typography, Stack } from "@mui/material";
import { useNavigate } from "react-router-dom";

const schema = yup.object({
  email: yup.string().email().required(),
  password: yup.string().min(6).required()
});

export default function Register() {
  const { register: doRegister } = useAuth();
  const nav = useNavigate();
  const { register, handleSubmit, formState: { errors, isSubmitting } } =
    useForm({ resolver: yupResolver(schema) });

  const onSubmit = async (v) => {
    try {
      await doRegister(v.email, v.password);
      nav("/properties");
    } catch (e) {
      alert("Registration failed");
    }
  };

  return (
    <Container maxWidth="xs" sx={{ mt: 6 }}>
      <Typography variant="h5" mb={2}>Register</Typography>
      <Stack component="form" onSubmit={handleSubmit(onSubmit)} spacing={2}>
        <TextField label="Email" {...register("email")} error={!!errors.email} helperText={errors.email?.message}/>
        <TextField label="Password" type="password" {...register("password")} error={!!errors.password} helperText={errors.password?.message}/>
        <Button variant="contained" type="submit" disabled={isSubmitting}>Create account</Button>
      </Stack>
    </Container>
  );
}
