import React from 'react';
import styles from './Validation.module.css'

/**
 * A simple component that displays a validation message.
 *
 * @param {string} [value=""] - The validation message to display. Defaults to an empty string if not provided.
 * @returns {JSX.Element} The rendered span containing the validation message.
 */
function Validation({ value = "" , fullWidth = false}) {

	const classNames = `${styles.text} ${fullWidth ? styles.validation_full_width :''}`;

  return (
    <span className={classNames}>{value}</span>
  );
}

export default Validation;
