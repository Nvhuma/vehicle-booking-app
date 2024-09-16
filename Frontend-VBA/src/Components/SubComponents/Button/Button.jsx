// Button.js
import React from 'react';
import styles from './Button.module.css'; // Import the updated CSS file

const Button = ({ variant = 'primary', fullWidth = false, value }) => {
   // Function to get the button variant class
   const getVariantClass = (variant) => styles[`button_${variant}`];
  
   // Combine the class names
   const classNames = `${styles.button} ${getVariantClass(variant)} ${fullWidth ? styles.button_full_width : styles.button_dynamic}`;

  return (
    <button className={classNames}>
      {value}
    </button>
  );
};

export default Button;
