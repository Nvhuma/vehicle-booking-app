import React, { useState, useEffect} from "react";
import styles from "./Profile.module.css";
import Button from "../../SubComponents/Button/Button";
import { Edit } from "@mui/icons-material";
import UserDetailsSection from "../../SubComponents/ProfileComponents/UserDetailsSection";
import UserDetailsSectionPlaceholder from "../../SubComponents/ProfileComponents/UserDetailsSectionPlaceholder";
import { toast } from "react-toastify";
import axios from "axios";
import { BASE_URL } from "../../../../config";
import { GetUser } from "../../../utils/Auth/Auth";

function Profile() {
  const [personalInfo, setPersonalInfo] = useState (null)
  const [personalAddress, setPersonalAddress] = useState (null)
  const user = GetUser();
  const token = user?.token;
  
  useEffect(() => {
    toast.promise(
      axios.get(`${BASE_URL}/api/user`, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      }),
      {
        pending: 'Loading user data...',
        //success: {
        //  render({ data }) {
            
        //    console.log(data.data); // Log the data on success
        //    return 'Load successful'; // Return an empty string to avoid showing a toast
        //  },
        //},
        error: {
          render({ data }) {
            console.error(data); // Log the entire error response
            const errorMessage = data?.response?.data?.message || "Error fetching user data.";
            return `Fetch failed: ${errorMessage}`;
          },
        },
      }
    );
  }, [token]);

  const formatPersonalInfo = (data) => {
    return [
      { label: "First Name", value: data.name },
      { label: "Last Name", value: data.surname },
      { label: "Email Address", value: data.email },
      { label: "Phone", value: data.phoneNumber },
      { label: "ID Number", value: data.identityNumber },
    ];
  };
  

  const addressInfo = [
    { label: "Address Line 1", value: "20530 N Rand Rd" },
    { label: "Address Line 2", value: "Apartment 26B" },
    { label: "Province", value: "Gauteng" },
    { label: "City", value: "Waverley" },
    { label: "Postal Code", value: "60010" },
  ];

  return (
    <div className={styles["profile-container"]}>
      <span className={styles["page-identity"]}>My Profile</span>

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

        <div
          className={`${styles["spotlight-actions-container"]} ${styles["section-action-button"]}`}
        >
          <Button value="Edit" icon={<Edit />} />
        </div>
      </div>

      {personalInfo && (<UserDetailsSection sectionTitle="Personal Information" details={personalInfo} />)}
      {personalAddress ? (<UserDetailsSection sectionTitle="Address" details={addressInfo} />) : (<UserDetailsSectionPlaceholder sectionTitle="Address"/>)}
    </div>
  );
}

export default Profile;
