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
  const [capVal, setCapVal] = useState(null);

  const validationRequirements = {
    passwordValidation : "Your password must meet these requirements:\nBe at least 8 characters\nInclude at least \nOne uppercase letter \nOne lowercase letter\nOne number\nOne special character",
    matchValidation : "This field must match the password field.",
    emailValidation : "Please enter a valid email address.",
    namesValidation : "Cannot contain any numbers"
  }

  const handleRegister = async (e) => {
    e.preventDefault();
  
    if (password !== confirmPassword) {
      toast.error('Passwords do not match');
      return;
    }
  
    const registerData = {
      name,
      surname,
      email,
      phoneNumber,
      password,
      confirmPassword,
      identityNumber,
    };
  
    toast.promise(
      axios.post(`${BASE_URL}/api/Account/register`, registerData, { headers: { "Content-Type": "application/json" } }),
      {
        pending: 'Registering user...',
        success: {
          render() {
            // Clear form fields upon successful registration
            setName('');
            setSurname('');
            setEmail('');
            setPhoneNumber('');
            setPassword('');
            setConfirmPassword('');
            setIdentityNumber('');
  
            return 'Registration successful! Please check your email to confirm your account.';
          }
        },
        error: {
          render({ data }) {
            const errorMessage = data?.response?.data?.errors?.[0] || 'An error occurred during registration';
            return `Registration failed: ${errorMessage}`;
          }
        }
      }
    )
    .catch((error) => {
      console.error("Registration error:", error);
    });
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
             
              <InputField
                type="text"
                fullWidth
                placeholder="Name"
                value={name}
                onChange={(e) => setName(e.target.value)}
                title={validationRequirements.namesValidation}
                required
              />
            </div>

            <div className={styles["short-input-group"]}>
             
              <InputField
                type="text"
                fullWidth
                placeholder="Surname"
                value={surname}
                onChange={(e) => setSurname(e.target.value)}
                required
              />
            </div>
          </div>

          <div className={styles["input-group"]}>
              <InputField
                type="tel"
                fullWidth
                placeholder="Phone Number"
                value={phoneNumber}
                onChange={(e) => setPhoneNumber(e.target.value)}
                pattern={"[0-9]{10,11}"}
                required
              />
          </div>

          <div className={styles["input-group"]}>
           
            <InputField
              type="text"
              fullWidth
              placeholder="Email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              pattern={"[a-zA-z0-9]+@+[a-zA-z0-9]+\.+[a-zA-z0-9]{2,}(?:\.[a-zA-z0-9]{2,})?"}
              required
            />
          </div>

          <div className={styles["input-group"]}>
           
            <InputField
              type="password"
              fullWidth
              placeholder="Password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              pattern={"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[@$!%*?&])[A-Za-z0-9@$!%*?&]{8,}$"} // Regex code to ensure password requirements are met
              title={validationRequirements.passwordValidation}
              required
            />
          </div>

          <div className={styles["input-group"]}>
           
            <InputField
              type="password"
              fullWidth
              placeholder="Confirm Password"
              value={confirmPassword}
              onChange={(e) => setConfirmPassword(e.target.value)}
              pattern={"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[@$!%*?&])[A-Za-z0-9@$!%*?&]{8,}$"} // Regex code to ensure password requirements are met
              title={validationRequirements.passwordValidation}
              required
            />
          </div>

          <div className={styles["input-group"]}>
           
            <InputField
              type="text"
              fullWidth
              placeholder="Identity Number"
              value={identityNumber}
              onChange={(e) => setIdentityNumber(e.target.value)}
              pattern={"[0-9]{13}"}
              required
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
