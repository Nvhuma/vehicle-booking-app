import React from "react";
import styles from "./UserDetailsSection.module.css";
import Button from "../../Button/Button";
import { Edit } from "@mui/icons-material";

function UserDetailsSection({ sectionTitle, details, onEdit }) {
  return (
    <div className={styles["user-details-container"]}>
      <div className={styles["user-details-layout-container"]}>
        <span className={styles["section-identity"]}>{sectionTitle}</span>
        <div className={styles["user-details-info-container"]}>
          {details.map(({ label, value }) => (
            <div key={label} className={styles["user-info-group"]}>
              <span className={styles["user-info-label"]}>{label}</span>
              <span className={styles["user-info"]}>{value}</span>
            </div>
          ))}
        </div>
      </div>

      <div className={`${styles["spotlight-actions-container"]} ${styles["section-action-button"]}`}>
      <Button value="Edit" icon={<Edit />} onClick={onEdit} />
      </div>
    </div>
  );
}

export default UserDetailsSection;
