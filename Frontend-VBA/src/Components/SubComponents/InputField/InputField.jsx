import React from 'react';
import styles from './InputField.module.css'; // Assuming your CSS is in InputField.module.css

/**
 * InputField component renders a customizable input field with optional icon and size settings.
 * 
 * This component allows users to create text input fields with various configurations including
 * different types (text, password, etc.), sizes (small, medium, large), and whether the field
 * should occupy the full width of its container. Additionally, an optional icon can be provided
 * to display inside the input field.
 * 
 * @param {string} type - The type of the input field. Determines the type of input (e.g., 'text', 'password'). Default is 'text'.
 * @param {string} size - The size of the input field. Defines the input field's size. Acceptable values are 'small', 'medium', or 'large'. Default is 'medium'.
 * @param {boolean} fullWidth - A boolean value that, if true, makes the input field occupy 100% of its container's width. Default is false.
 * @param {string} placeholder - The placeholder text to be displayed when the input field is empty. Provides a hint to the user about what to enter.
 * @param {ReactNode} [icon] - An optional icon to be displayed inside the input field. This can be a React component or an image.
 * @param {string} value - The current value of the input field. This is controlled by the parent component.
 * @param {Function} onChange - A function to handle changes to the input field's value. This is called when the user types into the input field.
 * 
 * @returns {JSX.Element} - A styled input field element with optional icon and size adjustments based on the provided props.
 */

const InputField = ({ type = 'text', size = 'medium', fullWidth = false, placeholder = '', icon = '', value, onChange }) => {
  // Function to render the icon dynamically

  // Create className string dynamically
  const inputClassNames = `${styles.input} ${styles[`input_${size}`]} ${fullWidth ? styles.input_fullWidth : ''} ${icon ? `${styles.input_with_icon}` : ''}`;
  const containerClassNames = `${styles.input_container} ${icon ? `${styles.input_container_with_icon}` : ''}`;

  return (
    <div className={containerClassNames}>
      {icon &&  <span className={styles.icon}>{icon}</span>  }
      <input
        type={type}
        className={inputClassNames}
        placeholder={placeholder}
        value={value}  // Add value prop
        onChange={onChange}  // Add onChange prop
      />
    </div>
  );
};


export default InputField;
