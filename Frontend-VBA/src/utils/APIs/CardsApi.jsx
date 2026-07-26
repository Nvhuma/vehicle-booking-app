import axios from 'axios';
import { BASE_URL } from '../../../config';
import { GetUser } from '../Auth/Auth';

const API_CARDS_URL = `${BASE_URL}/api/card`;

const getUserConfig = () => {
  const user = GetUser();

  // Check if the user and token exist
  if (!user || !user.token) {
    throw new Error('User is not authenticated.');
  }

  // Log user details and token for debugging
  console.log("User details:", user);
  console.log("User token:", user.token);  // Check if token is correct

  return {
    headers: {
      Authorization: `Bearer ${user.token}`, // Corrected the token header
    },
  };
};

// POST: Add new card
export const addCard = async (cardData) => {
  try {
    const config = getUserConfig(); // Get token in headers
    console.log("addCard request data:", cardData); // Log the card data being sent
    console.log("addCard config:", config); // Log headers including token

    // Send POST request to create a card
    const response = await axios.post(`${API_CARDS_URL}`, cardData, config);

    console.log("addCard response:", response.data); // Log success response data
    // Return a success message or the response data
    return response.data;
  } catch (error) {
    // Log full error details for better debugging
    console.error('Error adding card:', error.response?.data || error.message);
    throw new Error(error.response?.data || 'An error occurred while adding the card');
  }
};

// GET: Fetch all cards
export const getCards = async () => {
  try {
    const config = getUserConfig(); // Get token in headers
    console.log("getCards config:", config); // Log headers including token

    // Send GET request to fetch cards
    const response = await axios.get(`${API_CARDS_URL}`, config);

    console.log("getCards response:", response.data); // Log success response data
    // Return the array of cards
    return response.data;
  } catch (error) {
    // Log full error details for better debugging
    console.error('Error fetching cards:', error.response?.data || error.message);
    throw new Error(error.response?.data || 'An error occurred while fetching cards');
  }
};

// DELETE: Delete a card by ID
export const deleteCard = async (cardId) => {
  try {
    const config = getUserConfig(); // Get token in headers
    console.log("deleteCard ID:", cardId); // Log the card ID being deleted
    console.log("deleteCard config:", config); // Log headers including token

    // Send DELETE request to delete a card
    const response = await axios.delete(`${API_CARDS_URL}/${cardId}`, config);

    console.log("deleteCard response:", response.data); // Log success response data
    // Return a success message or response data
    return response.data;
  } catch (error) {
    // Log full error details for better debugging
    console.error('Error deleting card:', error.response?.data || error.message);
    throw new Error(error.response?.data || 'An error occurred while deleting the card');
  }
};
