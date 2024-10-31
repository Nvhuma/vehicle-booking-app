import React, { useState } from "react";
import InputField from "../../InputField/InputField";
import styles from "./ChangePassword.module.css";
import Button from "../../Button/Button";
import { Close } from "@mui/icons-material";
import Validation from "../../Validations/Validation";
import axios from "axios";
import { toast } from "react-toastify";
import { BASE_URL } from "../../../../../config";
import { GetUser } from "../../../../utils/Auth/Auth";


function ChangePassword({ onClose }) {
  const [currentPassword, setCurrentPassword] = useState("");
  const [newPassword, setNewPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [errorMessage, setErrorMessage] = useState("");


  const handleChangePassword = async (e) => {
    setErrorMessage(null)
    e.preventDefault();

    if (!currentPassword || !newPassword || !confirmPassword) {
      setErrorMessage("All fields are required.");
      return;
    }
  
    if (newPassword !== confirmPassword) {
      setErrorMessage("New password and confirmation do not match.");
      return;
    }
  
    if (currentPassword === newPassword) {
      setErrorMessage("You cannot reuse your current password.");
      return;
    }
  
    const passwordData = {
      currentPassword,
      newPassword,
      confirmPassword,
    };
  
    let user = GetUser();
  
    toast.promise(
      axios.post(`${BASE_URL}/api/Account/change-password`, passwordData, {
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${user.token}`,
        },
      }),
      {
        pending: 'Changing password...',
        success: {
          render() {
            // Clear the fields upon successful password change
            // I also want to close this component <ChangePassword /> on success
            setCurrentPassword("");
            setNewPassword("");
            setConfirmPassword("");
            onClose();
            return 'Password changed successfully!';
          },
        },
        error: {
          render({ data }) {
            // Extract error message and set it in state to display in <Validation> component
            const error = data?.response?.data?.message || 'An error occurred while changing the password';
            setErrorMessage(error);
            return `Password change failed: ${error}`;
          },
        },
      }
    ).catch((error) => {
      console.error("Error changing password:", error);
    });
  };
  

  return (
    <div className={styles["change-password-container"]}>
      <div className={styles["change-password-form"]}>
        <div className={styles["section-identity"]}>Change Password</div>

        <button type="button" className={styles["close-button"]} onClick={onClose}>
          <Close />
        </button> { /** on click of this I want to close this component <ChangePassword /> */}

        <p className={styles["section-instruction"]}>
          Your password must be at least 8 characters long, include at least one
          uppercase letter, one lowercase letter, one number, and one special
          character.
        </p>

        <InputField
          name="currentPassword"
          type="password"
          fullWidth
          placeholder="Current Password"
          value={currentPassword}
          onChange={(e) => setCurrentPassword(e.target.value)}
          required
        />

        <InputField
          name="NewPassword"
          type="password"
          fullWidth
          placeholder="New Password"
          value={newPassword}
          onChange={(e) => setNewPassword(e.target.value)}
          pattern={"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[@$!%*?&])[A-Za-z0-9@$!%*?&]{8,}$"}sda
          required
        />

        <InputField
          name="ConfirmPassword"
          type="password"
          fullWidth
          placeholder="Confirm New Password"
          value={confirmPassword}
          onChange={(e) => setConfirmPassword(e.target.value)}
          pattern={"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[@$!%*?&])[A-Za-z0-9@$!%*?&]{8,}$"}
          required
        />

        {/* Render validation error if there's an error message */}
        {errorMessage && <Validation value={errorMessage} />}

        <Button fullWidth value="Change Password" onClick={handleChangePassword} />
      </div>
    </div>
  );
}

export default ChangePassword;
