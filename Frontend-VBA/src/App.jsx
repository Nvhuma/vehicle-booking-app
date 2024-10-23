import React from "react";
import "./App.css";
import Register from "./Components/Pages/Register/Register";
import Login from "./Components/Pages/Login/Login";
import {
  BrowserRouter as Router,
  Route,
  Routes,
  BrowserRouter,
  Navigate,
} from "react-router-dom";
import ForgotPassword from "./Components/Pages/ForgotPassword/ForgotPassword";
import ResetPassword from "./Components/Pages/ResetPassword/ResetPassword";
import ProtectedRoutes from "./utils/Auth/ProtectedRoutes";
import Profile from "./Components/Pages/Profile/Profile";
import Home from "./Components/Pages/Home/Home";
import CardManagement from "./Components/Pages/CardManagement/CardManagement";
import { ToastContainer } from "react-toastify";
import { Security } from "@mui/icons-material";
import SecurityPage from "./Components/Pages/Security/SecurityPage";

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <Routes>
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
          <Route path="/forgotPassword" element={<ForgotPassword />} />
          <Route path="/resetpassword" element={<ResetPassword />} />

          <Route element={<ProtectedRoutes />}>
            <Route path="/home" element={<Navigate to="/" />} />

            {/* Home Route with Nested Routes */}
            <Route path="/" element={<Home />}>
              <Route path="/profile" element={<Profile />} />
              <Route path="/dashboard" element={<Navigate to="/" />} />
              <Route path="billing" element={<CardManagement />} />
              <Route path="security" element={<SecurityPage />} />
            </Route>
          </Route>
        </Routes>
        <ToastContainer
          position="top-right"
          autoClose={5000}
          hideProgressBar={false}
          newestOnTop={false}
          closeOnClick
          rtl={false}
          pauseOnFocusLoss
          draggable
          pauseOnHover
          theme="colored"
          transition:Bounce
        />
      </div>
    </BrowserRouter>
  );
}

export default App;
