import React from 'react';
import styles from './Switch.module.css'; // Import the CSS file for switch styles

/**
 * Switch component for toggling between two states (e.g., on/off).
 * 
 * @param {string} [variant='primary'] - The variant of the switch, determining its color scheme. Default is 'primary'.
 * @param {boolean} [checked=false] - The initial checked state of the switch. Default is false.
 * @param {function} onChange - Callback function to handle the change event.
 * 
 * @returns {JSX.Element} - The rendered switch component.
 */
const Switch = ({ variant = 'primary', checked = false, onChange }) => {
  // Determine the class names based on variant and checked state
  const switchClass = `${styles.switch} ${styles[`switch_${variant}`]} ${checked ? styles.switch_checked : ''}`;

  return (
    <label className={styles.switch_container}>
      <input
        type="checkbox"
        className={styles.switch_input}
        checked={checked}
        onChange={onChange}
      />
      <span className={switchClass}></span>
    </label>
  );
};

export default Switch;
