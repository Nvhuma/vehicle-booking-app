import React, { useState } from "react";
import "./Login.css";
import InputField from "../../SubComponents/InputField/InputField";
import Button from "../../SubComponents/Button/Button";
import axios from 'axios';


const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleLogin = async (e) => {
    e.preventDefault();
    console.log("Login attempted with:", email, password);

 

    try {
      const response = await axios.post("http://localhost:5287/api/Account/login", {
        email: email,  
        password: password
      }, {
        headers: {
          'Content-Type': 'application/json'
        }
      });

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
        const errorMessage = error.response.data.message || "An unexpected error occurred.";
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
        <h1>VEHICLE BOOKING</h1>
        <form onSubmit={handleLogin}>
          <div className="input-group">
            <InputField
              type="email"
              placeholder="Email address"
              value={email}
              icon="mail"
              onChange={(e) => setEmail(e.target.value)}
            />
          </div>
          <div className="input-group">
            <InputField
              type="password"
              placeholder="Password"
              value={password}
              icon="lock"
              onChange={(e) => setPassword(e.target.value)}
            />
          </div>
          <a href="/forgot-password" className="forgot-password">
            Forgot password?
          </a>
          <Button type = "submit" variant="primary" value="Sign In" fullWidth />
          <Button variant="secondary" value="Sign In With facebook" fullWidth />
          <Button variant="secondary" value="Sign In with facebook" fullWidth />
        </form>
        <a href="/register" className="register-link">
          Click here to Register
        </a>
      </div>
    </div>
  );
};

export default Login;