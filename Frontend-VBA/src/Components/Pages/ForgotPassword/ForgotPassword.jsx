import React, { useState } from 'react';
import styles from './ForgotPassword.module.css';
import InputField from "../../SubComponents/InputField/InputField";
import Button from "../../SubComponents/Button/Button";
import axios from 'axios';
import { MailOutlined } from "@mui/icons-material";
import Validation from '../../SubComponents/Validations/Validation';
import { Link } from "react-router-dom";
import CustomLogo from '../../SubComponents/CustomLogo/CustomLogo';
import { toast } from 'react-toastify';

const ForgotPassword = () => {
  const [email, setEmail] = useState('');
  const [message, setMessage] = useState('');

  const handleForgotPassword = async (e) => {
    e.preventDefault();

    try {
      const response = await axios.post(
        'http://localhost:5287/api/Account/forgot-password',
        { email },
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      );

      if (response.status === 200) {
        setMessage('Password reset email sent successfully. Please check your email.');
      }
    } catch (error) {
      console.error('Error sending reset email:', error);
      setMessage('An error occurred. Please try again later.');
    }
  };

  return (
    <div className={styles["forgot-password-container"]}>
      <div className={styles["site-image-container"]}>
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
        
        <form className={styles['forgot-password-form']} onSubmit={handleForgotPassword}>
        <h3 className={styles["page-identity"]}>Forgot Password</h3>
        <p className={styles["page-instructions"]}>Enter your email address and we will send you a link to reset your password.</p>
          <div className={styles["input-group"]}>
            <Validation
              value={"Your email does not exist"}
            />
            <InputField
              type="email"
              fullWidth
              placeholder="Email address"
              value={email}
              icon={<MailOutlined />}
              onChange={(e) => setEmail(e.target.value)}
            />
          </div>
          <Link to="/" className={styles["back-to-login"]}>
            Back to Login
          </Link>
          <Button
            type="submit"
            variant="primary"
            value="Send Reset Link"
            fullWidth
            className={styles["input-button"]}
            />
        </form>
        {message && <p className="message">{message}</p>}
      </div>
    </div>
  );
};

export default ForgotPassword;
