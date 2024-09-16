import React from 'react';
import styles from './InputField.module.css'; // Assuming your CSS is in InputField.module.css
import SearchIcon from '../Icons/SearchIcon';
import MailIcon from '../Icons/MailIcon';
import LockIcon from '../Icons/LockIcon';


/**
 * InputField component renders a styled input field with optional icon and size.
 * 
 * @param {string} type - The type of the input field (e.g., 'text', 'password'). Default is 'text'.
 * @param {string} size - The size of the input field. Can be 'small', 'medium', or 'large'. Default is 'medium'.
 * @param {boolean} fullWidth - If true, the input field will take up 100% of its container's width. Default is false.
 * @param {string} placeholder - The placeholder text for the input field.
 * @param {ReactNode} [icon] - Optional icon to display inside the input field.
 */

const InputField = ({ type = 'text', size = 'medium', fullWidth = false, placeholder = '', icon = '' }) => {
  // Function to render the icon dynamically
  const renderIcon = () => {
    switch (icon) {
      case 'search':
        return <SearchIcon />;
      case 'mail':
        return <MailIcon />;
      case 'lock':
        return <LockIcon />;
      default:
        return null;
    }
  };

  // Create className string dynamically
  const inputClassNames = `${styles.input} ${styles[`input_${size}`]} ${fullWidth ? styles.input_fullWidth : ''} ${icon ? `${styles.input_with_icon}` : ''}`;
  const containerClassNames = `${styles.input_container} ${icon ? `${styles.input_container_with_icon}` : ''}`;

  return (
    <div className={containerClassNames}>
      {icon && renderIcon(icon)}
      <input
        type={type}
        className={inputClassNames}
        placeholder={placeholder}
      />
    </div>
  );
};

export default InputField;
