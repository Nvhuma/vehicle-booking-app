import React from 'react'
import styles from './Profile.module.css'
import Button from '../../SubComponents/Button/Button'
import { Edit } from '@mui/icons-material'

function Profile() {
  return (
    <div className={styles['profile-container']}>
      <p className={styles['page-identity']}>My Profile</p>

      <div className={styles["user-spotlight"]}>
        <div className={styles["spotlight-image-container"]}>
          <img src="https://placehold.co/150" alt="" className={styles["spotlight-image"]} />
        </div>

        <div className={styles["spotlight-text-container"]}>
          <span className={styles['spotlight-name']}>Peter Griffin</span>
          <span className={styles['spotlight-role']}>Super User</span>
        </div>

        <div className={styles["spotlight-actions-container"]}>
          <Button
            value="Edit"
            icon={<Edit />} />
        </div>

      </div>
    </div>
  )
}

export default Profile