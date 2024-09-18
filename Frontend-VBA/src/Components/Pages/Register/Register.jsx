import React, { useState } from 'react';
import axios from 'axios';
import InputField from "../../SubComponents/InputField/InputField";
import Button from "../../SubComponents/Button/Button";
import './Register.module.css'; // Assuming you have your CSS file


const Register = () => {
  const [name, setName] = useState('');
  const [surname, setSurname] = useState('');
  const [userName, setUserName] = useState('');
  const [email, setEmail] = useState('');
  const [phoneNumber, setPhoneNumber] = useState('');
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const [identityNumber, setIdentityNumber] = useState('');
  const [error, setError] = useState('');
  const [success, setSuccess] = useState('');

  const handleRegister = async (e) => {
    e.preventDefault();

    if (password !== confirmPassword) {
      setError('Passwords do not match');
      return;
    }

    const registerData = {
      name,
      surname,
      userName,
      email,
      phoneNumber,
      password,
      confirmPassword,
      identityNumber,
    };

    try {
      const response = await axios.post('http://localhost:5287/api/Account/register', registerData);
      if (response.status === 200) {
        setSuccess('User registered successfully. Please check your email to confirm your account.');
        setError('');
      }
    } catch (error) {
      setError(error.response?.data?.errors?.[0] || 'An error occurred during registration');
    }
  };

  return (
    <div className="register-container">
      <h1>Register for Vehicle Booking App</h1>
      <form onSubmit={handleRegister}>
        <InputField
          type="text"
          placeholder="Name"
          value={name}
          onChange={(e) => setName(e.target.value)}
        />
        <InputField
          type="text"
          placeholder="Surname"
          value={surname}
          onChange={(e) => setSurname(e.target.value)}
        />
        <InputField
          type="text"
          placeholder="Username"
          value={userName}
          onChange={(e) => setUserName(e.target.value)}
        />
        <InputField
          type="email"
          placeholder="Email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
        <InputField
          type="text"
          placeholder="Phone Number"
          value={phoneNumber}
          onChange={(e) => setPhoneNumber(e.target.value)}
        />
        <InputField
          type="password"
          placeholder="Password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
        <InputField
          type="password"
          placeholder="Confirm Password"
          value={confirmPassword}
          onChange={(e) => setConfirmPassword(e.target.value)}
        />
        <InputField
          type="text"
          placeholder="Identity Number"
          value={identityNumber}
          onChange={(e) => setIdentityNumber(e.target.value)}
        />
        {error && <div className="error-message">{error}</div>}
        {success && <div className="success-message">{success}</div>}
        <Button type="submit" variant="primary" value="Register" fullWidth />
      </form>
    </div>
  );
};

export default Register;
