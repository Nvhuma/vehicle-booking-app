import React from "react";
import styles from "./UserDetailsSection.module.css";
import Button from "../../Button/Button";
import { Edit } from "@mui/icons-material";

function UserDetailsSectionPlaceholder({ sectionTitle, onEdit }) {
  return (
    <div className={styles["user-details-container"]}>
      <div className={styles["user-details-layout-container"]}>
        <span className={styles["section-identity"]}>{sectionTitle}</span>
      </div>

      <div
        className={`${styles["spotlight-actions-container"]} ${styles["section-action-button"]}`}
      >
       <Button value="Edit" icon={<Edit />} onClick={onEdit} /> {/* this is where it all begins*/}
      </div>
    </div>
  );
}

export default UserDetailsSectionPlaceholder;
