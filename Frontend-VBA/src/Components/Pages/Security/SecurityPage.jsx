import React from 'react'
import styles from './securityPage.module.css'
import UserSpotlight from '../../SubComponents/UserSpotlight/UserSpotlight'
import Button from '../../SubComponents/Button/Button'
import { Edit } from '@mui/icons-material'

function SecurityPage() {
	return (
		<div className={styles['security-container']}>
			<span className={styles["page-identity"]}>Security</span>
			<UserSpotlight />

			<div className={styles["change-password-section-container"]}>
				<span className={styles['section-identity']}>Change Password</span>
				<p className={styles['section-paragraph']}>
					For added security, it's essential to keep your password updated regularly. 
					Make sure your new password is strong and unique to protect your account. 
					This is part of our broader commitment to keeping your information safe</p>
				<div className={styles["section-button-container"]}>
					<Button
					icon={<Edit />}
					value="Change Password" />
				</div>
			</div>
		</div>
	)
}

export default SecurityPage