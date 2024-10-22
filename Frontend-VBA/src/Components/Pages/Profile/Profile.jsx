import React, { useState, useEffect } from "react";
import styles from "./Profile.module.css";
import Button from "../../SubComponents/Button/Button";
import { Edit } from "@mui/icons-material";
import UserDetailsSection from "../../SubComponents/ProfileComponents/UserDetailsSection/UserDetailsSection";
import UserDetailsSectionPlaceholder from "../../SubComponents/ProfileComponents/UserDetailsSection/UserDetailsSectionPlaceholder";
import UpdateUserDetails from "../../SubComponents/ProfileComponents/UpdateUserDetails/UpdateUserDetails";
import { toast } from "react-toastify";
import axios from "axios";
import { BASE_URL } from "../../../../config";
import { GetUser } from "../../../utils/Auth/Auth";

function Profile() {
  const [personalInfo, setPersonalInfo] = useState(null);
  const [personalAddress, setPersonalAddress] = useState(null);
  const [editingSection, setEditingSection] = useState(null);

  const user = GetUser();
  const token = user?.token;

  useEffect(() => {
    const loadToastId = toast.loading("Loading user data...");
    axios
      .get(`${BASE_URL}/api/user`, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
      .then((response) => {
        const formattedInfo = formatPersonalInfo(response.data);
        setPersonalInfo(formattedInfo);
        toast.dismiss(loadToastId);
      })
      .catch((error) => {
        const errorMessage =
          error?.response?.data?.message || "Error fetching user data.";
        toast.update(loadToastId, {
          render: `Fetch failed: ${errorMessage}`,
          type: "error",
          isLoading: false,
          autoClose: 5000,
        });
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
    console.log(`${section} clicked`);
    setEditingSection(section);
  };

  const handleCloseUpdate = () => {
    setEditingSection(null);
  };

  const handleSubmitUpdate = (updatedData) => {
    const loadToastId = toast.loading("Updating user data...");
    axios
      .put(`${BASE_URL}/api/user`, updatedData, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
      .then((response) => {
        const updatedInfo = formatPersonalInfo(response.data);
        setPersonalInfo(updatedInfo);

        const updatedAddress = formatAddressInfo(response.data);
        setPersonalAddress(updatedAddress);

        toast.update(loadToastId, {
          render: "User data updated successfully!",
          type: "success",
          isLoading: false,
          autoClose: 5000,
        });
        setEditingSection(null); 
      })
      .catch((error) => {
        const errorMessage =
          error?.response?.data?.message || "Error updating user data.";
        toast.update(loadToastId, {
          render: `Update failed: ${errorMessage}`,
          type: "error",
          isLoading: false,
          autoClose: 5000,
        });
      });
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
          onClose={handleCloseUpdate}
        />
      ) : ""}
    </div>
  );
}

export default Profile;
