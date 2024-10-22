// userApi.js
import axios from "axios";
import { toast } from "react-toastify";
import { BASE_URL } from "../../../config";
import { SetUser, GetUser } from "../Auth/Auth";


export const getPersonalInfo = async (token, showToast = true) => {
  const loadToastId = showToast ? toast.loading("Loading user data...") : null;
  try {
    const response = await axios.get(`${BASE_URL}/api/user`, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    });
    
    if (showToast) {
      toast.dismiss(loadToastId); // Close the loading toast
      toast.success("User data loaded successfully!"); // Show success toast
    }
    
    return response.data;
  } catch (error) {
    if (showToast) {
      const errorMessage = error?.response?.data?.message || "Error fetching user data.";
      toast.update(loadToastId, {
        render: `Fetch failed: ${errorMessage}`,
        type: "error",
        isLoading: false,
      });
    }
    throw error.response?.data || { message: "Error fetching user data." };
  }
};

export const updatePersonalInfo = async (token, updatedData) => {
  // Loading toast with inherited global properties
  const loadToastId = toast.loading("Updating user data...");

  // Transform the updatedData to match the API's expected structure
  const transformedData = {
    name: updatedData["First Name"], // Maps "First Name" to "name"
    surname: updatedData["Last Name"], // Maps "Last Name" to "surname"
    userName: updatedData["Email Address"], // Maps "Email Address" to "userName"
    email: updatedData["Email Address"], // Maps "Email Address" to "email"
    phoneNumber: updatedData["Phone"], // Maps "Phone" to "phoneNumber"
  };

  try {
    const response = await axios.patch(`${BASE_URL}/api/user`, transformedData, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    });

    let user = GetUser();

    const updatedUser = {
      ...user, // Retain the existing user details
      fullName: `${response.data.name} ${response.data.surname}`,
      email: response.data.email,
      userName: response.data.userName,
    };

    SetUser(updatedUser);

    toast.update(loadToastId, {
      render: "User data updated successfully!",
      type: "success",
      isLoading: false,
      autoClose: 5000, 
      closeOnClick: true, 
    });

    return response.data; 
  } catch (error) {
    const errorMessage = error?.response?.data?.message || "Error updating user data.";

    toast.update(loadToastId, {
      render: `Update failed: ${errorMessage}`,
      type: "error",
      isLoading: false,
      autoClose: 5000, 
      closeOnClick: true, 
    });

    throw error;
  }
};


export const updatePersonalAddress = async (token, updatedData) => {
  const loadToastId = toast.loading("Updating address data...");

  try {
    const response = await axios.patch(`${BASE_URL}/api/user/address`, updatedData, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    });

    toast.update(loadToastId, {
      render: "Address updated successfully!",
      type: "success",
      isLoading: false,
      autoClose: 5000,
      closeOnClick: true, 
    });

    return response.data;
  } catch (error) {
    const errorMessage =
      error?.response?.data?.message || "Error updating address data.";
    toast.update(loadToastId, {
      render: `Update failed: ${errorMessage}`,
      type: "error",
      isLoading: false,
      autoClose: 5000,
      closeOnClick: true, 
    });
    throw error;
  }
};


