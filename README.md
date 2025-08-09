# 🏠 Real Estate Search Portal

A full-stack real estate application with a **.NET 8 Web API backend** and a **React + Vite frontend**.  
Features include property listings, search, authentication (JWT), favorites, and seed data.

---

## 📂 Project Structure

```
/backend   → ASP.NET Core Web API
/frontend  → React + Vite frontend
```

---

## 🚀 Features

- **Backend**
  - ASP.NET Core Web API
  - Entity Framework Core with SQL Server
  - JWT-based authentication (Register/Login)
  - Property CRUD endpoints
  - Favorite properties feature
  - Seed data for testing

- **Frontend**
  - React + Vite
  - Property listing & detail pages
  - Login / Register
  - Save favorite properties
  - Responsive UI

---

## 🛠 Prerequisites

- **Backend**
  - [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
  - SQL Server (LocalDB / Express / Azure)

- **Frontend**
  - [Node.js (v18+ recommended)](https://nodejs.org/)

---

## ⚙️ Backend Setup

1. **Navigate to backend folder**
   ```bash
   cd backend
   ```

2. **Update `appsettings.json`**
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=RealEstateDb;User Id=sa;Password=YourPassword;Trusted_Connection=True;TrustServerCertificate=True;"
   },
   "Jwt": {
     "Key": "your-secure-random-key",
     "Issuer": "RealEstateApi",
     "Audience": "RealEstateClient"
   }
   ```

3. **Run migrations**
   ```bash
   dotnet ef database update
   ```

4. **Run the API**
   ```bash
   dotnet run
   ```
   API will run on: `https://localhost:7029`

---

## 💻 Frontend Setup

1. **Navigate to frontend folder**
   ```bash
   cd frontend
   ```

2. **Create `.env` file**
   ```env
   VITE_API_BASE_URL=https://localhost:7029
   ```

3. **Install dependencies**
   ```bash
   npm install
   ```

4. **Run frontend**
   ```bash
   npm run dev
   ```
   App will run on: `http://localhost:5173`

---

## 🔑 Test Credentials (if seed data enabled)

| Email          | Password |
|----------------|----------|
| test@test.com  | 123456   |

---

## 📌 Notes

- Images in property listings are using **Unsplash placeholder API**.
- Backend uses **BCrypt.Net** for password hashing.
- CORS is enabled for local development.

---

## 📝 License
MIT License
