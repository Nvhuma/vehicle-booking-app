import React, { useState } from 'react';
import styles from './Checkbox.module.css';
import { Check } from '@mui/icons-material';

const Checkbox = ({ variant = 'primary', label, onChange }) => {
  const [isChecked, setIsChecked] = useState(false);

  const handleToggle = () => {
    setIsChecked(!isChecked);
    if (onChange) {
      onChange(!isChecked);
    }
  };

  // Create the className string dynamically
  const checkboxClass = `${styles.checkbox} ${styles[`checkbox_${variant}`]} ${isChecked ? styles.checkbox_checked : ''}`;

  return (
    <label className={styles.checkbox_container}>
      <input
        type="checkbox"
        className={styles.checkbox_input}
        checked={isChecked}
        onChange={handleToggle}
      />
      <span className={checkboxClass}>
        {isChecked && <Check fontSize='small' className={styles.checkmark} />}
      </span>
      {label && <span className={styles.checkbox_label}>{label}</span>}
    </label>
  );
};

export default Checkbox;
