import React, { useState } from 'react';
import styles from './Checkbox.module.css';

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
      <span className={checkboxClass}></span>
      {label && <span>{label}</span>}
    </label>
  );
};

export default Checkbox;
