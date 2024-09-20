import React, { useState } from "react";
import styles from "./Login.module.css";
import InputField from "../../SubComponents/InputField/InputField";
import Button from "../../SubComponents/Button/Button";
import axios from "axios";
import { useNavigate } from 'react-router-dom';
import { Link } from "react-router-dom";
import { Facebook, Google, MailOutline, LockOutlined } from "@mui/icons-material";
import Validation from "../../SubComponents/Validations/Validation";
import CustomLogo from "../../SubComponents/CustomLogo/CustomLogo";


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
    <div className={styles['login-container']}>
      <div className="login-image">
        <img className={styles["site-image"]} src="src/assets/images/login_image.png" alt="Vehicle" />
      </div>
      <div className={styles["form-container"]}>
        <h1 className={styles["business-name"]}>AUTO SERVICES</h1>
        <div className={styles["logo-container"]}>
          <CustomLogo
          variant="primary"
          className={styles['logo']} />
        </div>
        <form className={styles['login-form']} onSubmit={handleLogin}>

          <div className={styles["input-group"]}>
            <Validation value={''} />
            <InputField
              type="email"
              fullWidth
              placeholder="Email address"
              value={email}
              icon={<MailOutline />}
              onChange={(e) => setEmail(e.target.value)}
            />
          </div>

          <div className={styles["input-group"]}>
            <Validation value={''} />
            <InputField
              type="password"
              fullWidth
              placeholder="Password"
              value={password}
              icon={<LockOutlined />}
              onChange={(e) => setPassword(e.target.value)}
            />
          </div>

          <Link to="/ForgotPassword" className={styles["forgot-password"]}>
            Forgot password?
          </Link>

          <Button
            type="submit"
            variant="primary"
            value="Sign In"
            fullWidth
            className={styles["input-button"]}
          />

          <Button
            variant="social"
            value="Sign In With facebook"
            fullWidth
            icon={<Facebook />}
            className={styles["input-button"]} // Add custom styles here
          />

          <Button
            variant="social"
            value="Sign In with facebook"
            fullWidth
            icon={<Google />}
            className={styles["input-button"]}
          />

        </form>

        {/* Register link */}
        <Link to="/register" className={styles["register-link"]}>
          Click here to <span>Register</span>
        </Link>

      </div>
    </div>
  );
};

export default Login;
