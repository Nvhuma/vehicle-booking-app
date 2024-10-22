import React from "react";
import InputField from "../../InputField/InputField";
import styles from "./UpdateUserDetails.module.css";
import Button from "../../Button/Button";
import { Close } from "@mui/icons-material";

function UpdateUserDetails({ sectionTitle, details, onClose, onSubmit }) {
  const handleSubmit = (event) => {
    event.preventDefault();
    const updatedData = details.reduce((acc, field) => {
      acc[field.label] = event.target[field.label]?.value || field.value;
      return acc;
    }, {});
    onSubmit(updatedData);
  };

  return (
    <div className={styles["update-user-details-container"]}>
      <form className={styles["update-user-details-form"]} onSubmit={handleSubmit}>
        <div className={styles["section-identity"]}>{sectionTitle}</div>
        <button type="button" className={styles["close-button"]} onClick={onClose}>
          <Close />
        </button>
        {details.map((field, index) => (
          <div key={index} className={styles["input-group"]}>
            <label htmlFor={field.label}>{field.label}</label>
            <InputField
              name={field.label}
              type={field.type || "text"}
              fullWidth
              placeholder={`Enter ${field.label}`}
              defaultValue={field.value}
            />
          </div>
        ))}
        <div className={styles["input-group"]}>
          <Button fullWidth value="Submit" type="submit" />
        </div>
      </form>
    </div>
  );
}

export default UpdateUserDetails;
