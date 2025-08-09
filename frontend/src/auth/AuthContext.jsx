
import { createContext, useContext, useMemo, useState } from "react";
import api from "../api/axios";

const AuthCtx = createContext(null);
export const useAuth = () => useContext(AuthCtx);

export default function AuthProvider({children}){
    const [token, setToken] = useState(localStorage.getItem("token"));

    const login = async (email, password) => {
        const {data} = await api.post("auth/login", {email, password});
        localStorage.setItem("token", data.token);
        setToken(data.token);
    };

    const register = async (email, password) => {
        const {data} = await api.post("auth/register", {email, password});
        localStorage.setItem("token", data.token);
        setToken(data.token);
    };

    const logout = () => { localStorage.removeItem("token"); setToken(null); };

    const value = useMemo(() => ({token, login, register, logout}), [token]);
    return <AuthCtx.Provider value={value}>{children}</AuthCtx.Provider>;
}