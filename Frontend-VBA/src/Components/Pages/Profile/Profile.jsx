import React, { useState, useEffect } from "react";
import styles from "./Profile.module.css";
import Button from "../../SubComponents/Button/Button";
import { Edit } from "@mui/icons-material";
import UserDetailsSection from "../../SubComponents/ProfileComponents/UserDetailsSection/UserDetailsSection";
import UserDetailsSectionPlaceholder from "../../SubComponents/ProfileComponents/UserDetailsSection/UserDetailsSectionPlaceholder";
import UpdateUserDetails from "../../SubComponents/ProfileComponents/UpdateUserDetails/UpdateUserDetails";
import { GetUser } from "../../../utils/Auth/Auth";
import { updatePersonalInfo, getPersonalInfo } from "../../../utils/APIs/UserApi";

function Profile() {
  const [personalInfo, setPersonalInfo] = useState(null);
  const [personalAddress, setPersonalAddress] = useState(null);
  const [editingSection, setEditingSection] = useState(null);

  const user = GetUser();
  const token = user?.token;


  /*  Use Effect to fetch initial data.*/
  useEffect(() => {
    getPersonalInfo(token)
   .then((responseData) => {
      const formattedInfo = formatPersonalInfo(responseData);
      setPersonalInfo(formattedInfo);
    })
   .catch((error) => {
      console.error(error); // Just in case I need more detail on the error
    });
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


  const handleEditSection = (section) => {
    setEditingSection(section);
  };

  const handleCloseUpdate = () => {
    setEditingSection(null);
  };

  const handleSubmitUpdate = async (updatedData, section) => {
    let userData;
  
    if (section === "Personal Information") {
      userData = await updatePersonalInfo(token, updatedData);
      const updatedInfo = formatPersonalInfo(userData);
      console.log("Updated info :",updatedInfo)
    setPersonalInfo(updatedInfo);
    } else if (section === "Address") {
      userData = await updatePersonalAddress(token, updatedData);
      const updatedAddress = formatAddressInfo(userData);
      setPersonalAddress(updatedAddress);
    }
  
    setEditingSection(null);
  };

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

      {personalInfo ? (
        <UserDetailsSection
        sectionTitle="Personal Information"
        details={personalInfo}
        onEdit={() => handleEditSection("Personal Information")}
      />
      ) : (
        <UserDetailsSectionPlaceholder
        sectionTitle="Personal Information"
        onEdit={() => handleEditSection("Personal Information")} />
      )}

      {personalAddress ? (
        <UserDetailsSection
        sectionTitle="Address"
        details={addressInfo}
        onEdit={() => handleEditSection("Address")} 
      />
      ) : (
        <UserDetailsSectionPlaceholder
        sectionTitle="Address"
        onEdit={() => handleEditSection("Address")}/>
      )}

      {editingSection ? (
        <UpdateUserDetails
          sectionTitle={`Update ${editingSection}`}
          details={
            editingSection === "Personal Information"
              ? personalInfo
              : addressInfo
          }
           onSubmit={(updatedData) => handleSubmitUpdate(updatedData, editingSection)}
          onClose={handleCloseUpdate}
        />
      ) : ""}
    </div>
  );
}

export default Profile;
