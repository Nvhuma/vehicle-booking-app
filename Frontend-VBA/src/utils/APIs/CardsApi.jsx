
import axios from 'axios';
import { BASE_URL } from '../../../config';

const API_CARDS_URL = `${BASE_URL}/api/card`;

// POST: Add new card
export const addCard = async (cardData) => {
  try {
    const response = await axios.post(`${API_CARDS_URL}`, cardData);
    return response.data;
  } catch (error) {
    console.error('Error adding card:', error);
    throw error;
  }
};

// GET: Fetch all cards
export const getCards = async () => {
  try {
    const response = await axios.get(`${API_CARDS_URL}`);
    return response.data;
  } catch (error) {
    console.error('Error fetching cards:', error);
    throw error;
  }
};

// DELETE: Delete a card by ID
export const deleteCard = async (cardId) => {
  try {
    const response = await axios.delete(`${API_CARDS_URL}/${cardId}`);
    return response.data;
  } catch (error) {
    console.error('Error deleting card:', error);
    throw error;
  }
};
