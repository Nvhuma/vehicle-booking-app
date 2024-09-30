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
              <Route path="billing" element={<CardManagement />} />
              <Route path="/profile" element={<Navigate to="/" />} />
            </Route>
          </Route>
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
