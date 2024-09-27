import React, { useState } from "react";
import { ToastContainer, toast } from 'react-toastify';
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
            // Get the entire user object from the response
            const user = data.data; // This will contain userName, email, fullName, token, and roles
    
            // Use SetUser to store the entire user object in localStorage with expiration
            SetUser(user);
    
            return 'Login Successful! 🎉';
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
      // Delay redirection to allow toast success message to be seen
      setTimeout(() => {
        navigate('/Home'); // Redirect to home page after 2 seconds
      }, 2000);
    })
    .catch((error) => {
      console.error("Login error:", error);
    });
  };

  // Move the return statement outside of the handleLogin function
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
      <ToastContainer
        theme="colored"
      />
    </div>
  );
};

export default Login;
