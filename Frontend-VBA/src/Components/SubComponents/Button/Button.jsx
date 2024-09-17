// Button.js
import React from 'react';
import styles from './Button.module.css'; // Import the updated CSS file
import '@mui/icons-material';

/**
 * Button component renders a styled button with customizable appearance, width, and optional icon.
 * 
 * @param {string} [variant='primary'] - The variant of the button, determining its color and style. Default is 'primary'. Other options can be 'secondary' depending on your styling.
 * @param {boolean} [fullWidth=false] - If true, the button will take up 100% of its container's width. Default is false.
 * @param {string|ReactNode} value - The content to display inside the button. Can be a string or a React node (e.g., an icon or text).
 * @param {ReactNode} [icon=null] - An optional icon to display inside the button, rendered before the value.
 * 
 * @returns {JSX.Element} - The rendered button component with the appropriate styles applied.
 */
const Button = ({ variant = 'primary', fullWidth = false, value, icon = null }) => {
  // Function to get the button variant class
  const getVariantClass = (variant) => styles[`button_${variant}`];

  // Combine the class names
  const classNames = `${styles.button} ${getVariantClass(variant)} ${fullWidth ? styles.button_full_width : styles.button_dynamic}`;

  return (
    <button className={classNames}>
      {icon && <span className={styles.button_icon}>{icon}</span>}
      {value}
    </button>
  );
};

export default Button;
