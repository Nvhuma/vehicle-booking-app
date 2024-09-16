import React from 'react';
import styles from './InputField.module.css'; // Assuming your CSS is in InputField.module.css
import SearchIcon from '../Icons/SearchIcon';
//import MailIcon from '../Icons/MailIcon';
//import LockIcon from '../Icons/LockIcon';

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
      {icon && <SearchIcon />}
      <input
        type={type}
        className={inputClassNames}
        placeholder={placeholder}
      />
    </div>
  );
};

export default InputField;
