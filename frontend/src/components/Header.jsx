import { AppBar, Toolbar, Typography, Button, Stack } from "@mui/material";
import { NavLink, useNavigate } from "react-router-dom";
import { useAuth } from "../auth/AuthContext";

const linkStyle = ({ isActive }) => ({
  color: "inherit",
  textDecoration: "none",
  opacity: isActive ? 1 : 0.8
});

export default function Header() {
  const { token, logout } = useAuth();
  const nav = useNavigate();

  const handleLogout = () => {
    logout();
    nav("/login");
  };

  return (
    <AppBar position="sticky">
      <Toolbar sx={{ gap: 2 }}>
        <Typography
          variant="h6"
          component={NavLink}
          to="/properties"
          sx={{ color: "inherit", textDecoration: "none", flexGrow: 1 }}
        >
          Real Estate Search
        </Typography>

        <Stack direction="row" spacing={1} alignItems="center">
          <Button component={NavLink} to="/properties" sx={linkStyle}>
            Properties
          </Button>

          {token && (
            <Button component={NavLink} to="/favorites" sx={linkStyle}>
              Saved
            </Button>
          )}

          {!token ? (
            <>
              <Button component={NavLink} to="/login" sx={linkStyle}>
                Login
              </Button>
              <Button component={NavLink} to="/register" sx={linkStyle}>
                Register
              </Button>
            </>
          ) : (
            <Button onClick={handleLogout} sx={{ color: "inherit" }}>
              Logout
            </Button>
          )}
        </Stack>
      </Toolbar>
    </AppBar>
  );
}
