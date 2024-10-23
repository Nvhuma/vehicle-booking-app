import React from 'react'
import styles from './securityPage.module.css'
import UserSpotlight from '../../SubComponents/UserSpotlight/UserSpotlight'

function SecurityPage() {
	return (
		<div className={styles['security-container']}>
			<span className={styles["page-identity"]}>Security</span>
			<UserSpotlight />
		</div>
	)
}

export default SecurityPage