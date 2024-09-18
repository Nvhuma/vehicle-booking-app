import React, { useState } from 'react';
import './ForgotPassword.module.css';
import InputField from "../../SubComponents/InputField/InputField";
import Button from "../../SubComponents/Button/Button";
import axios from 'axios';
import {MailOutlined} from "@mui/icons-material";

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
    <div className="forgot-password-container">
      <h1>Forgot Password</h1>
      <p>Enter your email address and we will send you a link to reset your password.</p>
      <form onSubmit={handleForgotPassword}>
        <div className="input-group">
          <InputField
            type="email"
            placeholder="Email address"
            value={email}
            icon={<MailOutlined />}
            onChange={(e) => setEmail(e.target.value)}
          />
        </div>
        <Button type="submit" variant="primary" value="Send Reset Link" fullWidth />
      </form>
      {message && <p className="message">{message}</p>}
    </div>
  );
};

export default ForgotPassword;
