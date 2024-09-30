import React from 'react'
import { NavLink } from 'react-router-dom'
import styles from './Sidemenu.module.css'
import { Event, Logout, Payment, Person, Security } from '@mui/icons-material'
import CustomLogo from '../CustomLogo/CustomLogo'

function Sidemenu() {
	return (
		<div className={styles['side-menu']}>
			<div className={styles['nav-logo-container']}>
				<NavLink to="" className={styles['nav-link']}>
					<CustomLogo
						variant="primary"
						className={styles['logo']}
					/>
					<h4 className={styles['logo-text']}>Auto Servives</h4>
				</NavLink>
			</div>
			<div className={styles['nav-links-container']}>
				<NavLink
					to="/"
					className={({ isActive }) =>
						`${styles['nav-link']} ${isActive ? styles['active'] : ''}`
					}
				>
					<Person className={styles['nav-link-icon']} />
					Profile
				</NavLink>

				<NavLink
					to="/bookings"
					className={({ isActive }) =>
						`${styles['nav-link']} ${isActive ? styles['active'] : ''}`
					}
				>
					<Event className={styles['nav-link-icon']} />
					Bookings
				</NavLink>

				<NavLink
					to="/billing"
					className={({ isActive }) =>
						`${styles['nav-link']} ${isActive ? styles['active'] : ''}`
					}
				>
					<Payment className={styles['nav-link-icon']} />
					Billing
				</NavLink>

				<NavLink
					to="/security"
					className={({ isActive }) =>
						`${styles['nav-link']} ${isActive ? styles['active'] : ''}`
					}
				>
					<Security className={styles['nav-link-icon']} />
					Security
				</NavLink>
			</div>

			<div className={styles['nav-logout-container']}>
				Side menu Bottom

				<NavLink to="" className={styles['nav-link']}>
					<Logout className={styles['nav-link-icon']} />
					Logout
				</NavLink>

			</div>
		</div>
	)
}

export default Sidemenu