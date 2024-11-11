import React, { useState } from "react";
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import styles from "./Login.module.css";
import InputField from "../../SubComponents/InputField/InputField";
import Button from "../../SubComponents/Button/Button";
import axios from "axios";
import { useNavigate } from 'react-router-dom';
import { Link } from "react-router-dom";
import { Facebook, Google, MailOutline, LockOutlined } from "@mui/icons-material";
import Validation from "../../SubComponents/Validations/Validation";
import CustomLogo from "../../SubComponents/CustomLogo/CustomLogo";
import { BASE_URL } from "../../../../config";
import { SetUser } from "../../../utils/Auth/Auth";

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

  const handleLogin = async (e) => {
    e.preventDefault();
    console.log("Login attempted with:", email, password);

    toast.promise(
      axios.post(
        `${BASE_URL}/api/Account/login`,
        { email, password },
        { headers: { "Content-Type": "application/json" } }
      ),
      {
        pending: 'Validating Credentials...',
        success: {
          render({ data }) {
            const user = data.data; // Assume this contains userName, email, fullName, token, and roles
            const { token } = user; // Extract token from user data
            
            if (token) {
              localStorage.setItem("token", token); // Save token to localStorage
              SetUser(user); // Store other user details if needed
              return 'Login Successful! 🎉';
            } else {
              throw new Error("Token not found in response");
            }
          }
        },
        error: {
          render({ data }) {
            const errorMessage = data?.response?.data?.message || "Error logging in.";
            return `Login failed: ${errorMessage}`;
          }
        }
      }
    )
    .then(() => {
      setTimeout(() => {
        navigate('/Home'); // Redirect to home page after a short delay
      }, 2000);
    })
    .catch((error) => {
      console.error("Login error:", error);
    });
  };

  return (
    <div className={styles['login-container']}>
      <div className={styles["site-image-containera"]}>
        <img className={styles["site-image"]} src="src/assets/images/login_image.png" alt="Vehicle" />
      </div>
      <div className={styles["form-container"]}>
        <h1 className={styles["business-name"]}>AUTO SERVICES</h1>
        <div className={styles["logo-container"]}>
          <CustomLogo
            variant="primary"
            className={styles['logo']}
          />
        </div>
        <form className={styles['login-form']} onSubmit={handleLogin}>
          <h3 className={styles["page-identity"]}>Login</h3>
          <div className={styles["input-group"]}>
            <InputField
              type="email"
              fullWidth
              placeholder="Email address"
              value={email}
              icon={<MailOutline />}
              onChange={(e) => setEmail(e.target.value)}
              required
            />
          </div>

          <div className={styles["input-group"]}>
            <InputField
              type="password"
              fullWidth
              placeholder="Password"
              value={password}
              icon={<LockOutlined />}
              onChange={(e) => setPassword(e.target.value)}
              required
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
            value="Sign In With Facebook"
            fullWidth
            icon={<Facebook />}
            className={styles["input-button"]}
          />

          <Button
            variant="social"
            value="Sign In with Google"
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
