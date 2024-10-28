import React, { useState } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom'
import InputField from "../../SubComponents/InputField/InputField";
import Button from "../../SubComponents/Button/Button";
import styles from './Register.module.css'; // Assuming you have your CSS file
import CustomLogo from '../../SubComponents/CustomLogo/CustomLogo';
import Validation from '../../SubComponents/Validations/Validation';
import { toast } from 'react-toastify';
import ReCAPTCHA from 'react-google-recaptcha';
import { RECAPTCHA_SITE_KEY } from '../../../../config';
import { BASE_URL } from '../../../../config';

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
  const [capVal, setCapVal] = useState(null)

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
      const response = await axios.post(`${BASE_URL}/api/Account/register`, registerData);
      if (response.status === 200) {
        setSuccess('User registered successfully. Please check your email to confirm your account.');
        setError('');
      }
    } catch (error) {
      setError(error.response?.data?.errors?.[0] || 'An error occurred during registration');
    }
  };

  return (
    <div className={styles["register-container"]}>
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

        <form className={styles["register-form"]} onSubmit={handleRegister}>
          <h3 className={styles["page-identity"]}>Register</h3>

          <div className={styles["input-group"]}>
            <div className={styles["short-input-group"]}>
              <Validation value={'Replace text with code for validation'} />
              <InputField
                type="text"
                fullWidth
                placeholder="Name"
                value={name}
                onChange={(e) => setName(e.target.value)}
              />
            </div>

            <div className={styles["short-input-group"]}>
              <Validation value={'Replace text with code for validation'} />
              <InputField
                type="text"
                fullWidth
                placeholder="Surname"
                value={surname}
                onChange={(e) => setSurname(e.target.value)}
              />
            </div>
          </div>

          <div className={styles["input-group"]}>
            <div className={styles["short-input-group"]}>
              <Validation value={'Replace text with code for validation'} />
              <InputField
                type="text"
                fullWidth
                placeholder="Username"
                value={userName}
                onChange={(e) => setUserName(e.target.value)}
              />
            </div>

            <div className={styles["short-input-group"]}>
              <Validation value={'Replace text with code for validation'} />
              <InputField
                type="text"
                fullWidth
                placeholder="Phone Number"
                value={phoneNumber}
                onChange={(e) => setPhoneNumber(e.target.value)}
              />
            </div>
          </div>

          <div className={styles["input-group"]}>
            <Validation value={'Replace text with code for validation'} />
            <InputField
              type="email"
              fullWidth
              placeholder="Email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
            />
          </div>

          <div className={styles["input-group"]}>
            <Validation value={'Replace text with code for validation'} />
            <InputField
              type="password"
              fullWidth
              placeholder="Password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
            />
          </div>

          <div className={styles["input-group"]}>
            <Validation value={'Replace text with code for validation'} />
            <InputField
              type="password"
              fullWidth
              placeholder="Confirm Password"
              value={confirmPassword}
              onChange={(e) => setConfirmPassword(e.target.value)}
            />
          </div>

          <div className={styles["input-group"]}>
            <Validation value={'Replace text with code for validation'} />
            <InputField
              type="text"
              fullWidth
              placeholder="Identity Number"
              value={identityNumber}
              onChange={(e) => setIdentityNumber(e.target.value)}
            />
          </div>

          {error && <div className="error-message">{error}</div>}
          {success && <div className="success-message">{success}</div>}

          <ReCAPTCHA
            sitekey={RECAPTCHA_SITE_KEY}
            onChange={(val) => setCapVal(val)}
          />

          <Button
            type="submit"
            variant={ !capVal ? "disabled" : "primary"}
            value="Register"
            fullWidth
            disabled={!capVal}
            className={styles["input-button"]}
          />
        </form>

        {/* Register link */}
        <Link to="/" className={styles["login-link"]}>
          Already have an account <span>Login</span>
        </Link>

      </div>
    </div>
  );
};

export default Register;
