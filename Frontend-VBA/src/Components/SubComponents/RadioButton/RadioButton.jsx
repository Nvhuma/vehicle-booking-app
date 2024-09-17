import React from 'react';
import styles from './RadioButton.module.css';

/**
 * RadioButton component for selecting one option from a group.
 * 
 * @param {string} variant - The variant of the radio button ('primary' or 'secondary').
 * @param {boolean} checked - Indicates whether the radio button is checked.
 * @param {string} name - The name attribute for the radio group.
 * @param {string} value - The value of the radio button.
 * @param {Function} onChange - Callback function to handle the change event.
 * 
 * @returns {JSX.Element} - The rendered radio button component.
 */
const RadioButton = ({ variant = 'primary', checked, name, value, onChange }) => {
  // Determine the class names based on the variant and checked state
  const radioClass = `${styles.radio} ${styles[`radio_${variant}`]} ${checked ? styles.radio_checked : ''}`;

  return (
    <label className={styles.radio_container}>
      <input
        type="radio"
        className={styles.radio_input}
        name={name}
        value={value}
        checked={checked}
        onChange={onChange} // Call the onChange handler when the radio button changes
      />
      <span className={radioClass}></span>
    </label>
  );
};

export default RadioButton;
