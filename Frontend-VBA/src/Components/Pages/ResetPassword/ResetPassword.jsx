import React, { useState, useEffect } from "react";
import { useNavigate, useLocation } from "react-router-dom";
import axios from "axios";
import styles from "./ResetPassword.module.css";
import InputField from "../../SubComponents/InputField/InputField";
import Button from "../../SubComponents/Button/Button";
import { LockOutlined } from "@mui/icons-material";
import Validation from "../../SubComponents/Validations/Validation";
import CustomLogo from "../../SubComponents/CustomLogo/CustomLogo";

const ResetPassword = () => {
  const [newPassword, setNewPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");

  const navigate = useNavigate();
  const location = useLocation();
  
  // Extract userId and token from URL query params
  const queryParams = new URLSearchParams(location.search);
  const userId = queryParams.get('userId');
  const token = queryParams.get('token');

  useEffect(() => {
    if (!userId || !token) {
      alert("Invalid or missing reset token. Please check your email or contact support.");
      navigate("/forgot-password");
    }
  }, [userId, token, navigate]);

  const handleResetPassword = async (e) => {
    e.preventDefault();

    if (newPassword !== confirmPassword) {
      alert("Passwords do not match.");
      return;
    }

    try {
      const response = await axios.post(
        "https://localhost:5287/api/Account/resetpassword",
        {
          userId,
          token,
          newPassword,
          confirmPassword,
        },
        {
          headers: {
            "Content-Type": "application/json",
          },
        }
      );

      if (response.status === 200) {
        alert("Password reset successful! Please log in with your new password.");
        navigate("/login");
      }
    } catch (error) {
      console.error("Reset password error:", error);
      if (error.response) {
        const errorMessage =
          error.response.data.message || "An unexpected error occurred.";
        alert(`Reset failed: ${errorMessage}`);
      } else {
        alert("An unexpected error occurred. Please try again.");
      }
    }
  };

  return (
    <div className={styles['reset-container']}>
      <div className="reset-image">
        <img className={styles["site-image"]} src="src/assets/images/reset_password_image.png" alt="Vehicle" />
      </div>
      <div className={styles["form-container"]}>
        <h1 className={styles["business-name"]}>AUTO SERVICES</h1>
        <div className={styles["logo-container"]}>
          <CustomLogo variant="primary" className={styles['logo']} />
        </div>
        <form className={styles['reset-form']} onSubmit={handleResetPassword}>

          <div className={styles["input-group"]}>
            <Validation value={''} />
            <InputField
              type="password"
              fullWidth
              placeholder="New Password"
              value={newPassword}
              icon={<LockOutlined />}
              onChange={(e) => setNewPassword(e.target.value)}
            />
          </div>

          <div className={styles["input-group"]}>
            <Validation value={''} />
            <InputField
              type="password"
              fullWidth
              placeholder="Confirm Password"
              value={confirmPassword}
              icon={<LockOutlined />}
              onChange={(e) => setConfirmPassword(e.target.value)}
            />
          </div>

          <Button
            type="submit"
            variant="primary"
            value="Reset Password"
            fullWidth
            className={styles["input-button"]}
          />
        </form>
      </div>
    </div>
  );
};

export default ResetPassword;
