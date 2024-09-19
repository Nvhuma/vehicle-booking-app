import React from 'react'

function CustomLogo({variant = "black", className}) {

  return (
	<img className={className} src={`src/assets/images/logo_${variant}.png`} alt="Company Logo" />
  )
}

export default CustomLogo