import React, { useState } from "react";
import "./Login.css";
import InputField from "../../SubComponents/InputField/InputField";
import Button from "../../SubComponents/Button/Button";
import axios from "axios";
import { useNavigate } from 'react-router-dom';
import { Link } from "react-router-dom";
import { Facebook, Google, MailOutline , LockOutlined } from "@mui/icons-material";


const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const navigate = useNavigate();


  const handleLogin = async (e) => {
    e.preventDefault();
    console.log("Login attempted with:", email, password);

    try {
      const response = await axios.post(
        "http://localhost:5287/api/Account/login",
        {
          email: email,
          password: password,
        },
        {
          headers: {
            "Content-Type": "application/json",
          },
        }
      );

      console.log("Login response:", response.data);

      if (response.status === 200) {
        //save the respsonse so that it an be later used react auth
        console.log("Login Successful!");
        console.log("UserName:", response.data.userName);
        console.log("Email:", response.data.email);
        console.log("FullName:", response.data.fullName);
        console.log("Token:", response.data.token);

        alert("Login successful! ");
      }
    } catch (error) {
      console.error("Login error:", error);
      if (error.response) {
        const errorMessage =
          error.response.data.message || "An unexpected error occurred.";
        alert(`Login failed: ${errorMessage}`);
      } else {
        alert("An unexpected error occurred. Please try again.");
      }
    }
  };

  return (
    <div className="login-container">
      <div className="login-image">
        <img src="src/assets/Rectangle 482.png" alt="Vehicle" />
      </div>
      <div className="login-form">
        <h1>VEHICLE BOOKING APP</h1>
        <form onSubmit={handleLogin}>
          <div className="input-group">
            <InputField
              type="email"
              placeholder="Email address"
              value={email}
              icon={<MailOutline />}
              onChange={(e) => setEmail(e.target.value)}
            />
          </div>
          <div className="input-group">
            <InputField
              type="password"
              placeholder="Password"
              value={password}
              icon={<LockOutlined />}
              onChange={(e) => setPassword(e.target.value)}
            />
          </div>
          <Link to="/ForgotPassword" className="forgot-password">
            Forgot password?
          </Link>
          <Button type="submit" variant="primary" value="Sign In" fullWidth />
          <Button
            variant="secondary"
            value="Sign In With facebook"
            fullWidth
            icon={<Facebook />}
          />
          <Button
            variant="secondary"
            value="Sign In with facebook"
            fullWidth
            icon={<Google />}
            />
            </form>
    
            {/* Register link */}
            <Link to="/register" className="register-link">
              Click here to Register
            </Link>
      </div>
    </div>
  );
};

export default Login;
