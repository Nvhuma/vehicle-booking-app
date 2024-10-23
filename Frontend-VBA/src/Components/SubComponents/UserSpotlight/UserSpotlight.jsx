import React, { useState } from 'react'
import styles  from './UserSpotlight.module.css'
import { GetUser } from "../../../utils/Auth/Auth";
import Button from '../Button/Button';
import { Edit } from '@mui/icons-material';

function UserSpotlight({button}) {
	const user = GetUser();

	return (
		<div className={styles["user-spotlight-container"]}>
        <div className={styles["spotlight-image-container"]}>
          <img
            src="https://placehold.co/150"
            alt=""
            className={styles["spotlight-image"]}
          />
        </div>

        <div className={styles["spotlight-text-container"]}>
          <span className={styles["spotlight-name"]}>{user.fullName}</span>
          <span className={styles["spotlight-role"]}>{user.roles[0]}</span>
          <span className={styles["spotlight-location"]}>
            Gauteng, South Africa
          </span>
        </div>


        {button ?
        (<div
          className={`${styles["spotlight-actions-container"]} ${styles["section-action-button"]}`}
        >
          <Button value="Edit" icon={<Edit />} />
        </div>)
        : 
        ("")
      }
      </div>
	)
}

export default UserSpotlight