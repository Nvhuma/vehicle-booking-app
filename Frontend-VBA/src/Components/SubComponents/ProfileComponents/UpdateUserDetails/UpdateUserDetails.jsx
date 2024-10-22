import React, { useState, useEffect } from "react";
import InputField from "../../InputField/InputField";
import styles from "./UpdateUserDetails.module.css";
import Button from "../../Button/Button";
import { Close } from "@mui/icons-material";

function UpdateUserDetails({ sectionTitle, details, onClose, onSubmit }) {
  // Initialize form values with the passed details
  const [formValues, setFormValues] = useState({});

  // Populate form values when the details prop is received or changed
  useEffect(() => {
    if (details) {
      const initialValues = {};
      details.forEach((field) => {
        field.label ? console.log(field.label) : console.log ("label is blank")
        initialValues[field.label] = field.value || ""; // Default to empty string if no value
      });
      setFormValues(initialValues);
    }
  }, [details]);

  // Handle input field changes
  const handleInputChange = (event) => {
    const { name, value } = event.target;
    console.log(`changing ${name} to ${value}`);
    setFormValues((prevValues) => ({
      ...prevValues,
      [name]: value, // Update the specific field value
    }));
  };

  // Handle form submission
  const handleSubmit = (event) => {
    event.preventDefault();
    onSubmit(formValues); // Pass the updated form values to the parent component
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
              value={formValues[field.label]} // Controlled input value
              onChange={handleInputChange} // Handle input changes
              readOnly={field.label === "ID Number"} // Make ID Number read-only
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