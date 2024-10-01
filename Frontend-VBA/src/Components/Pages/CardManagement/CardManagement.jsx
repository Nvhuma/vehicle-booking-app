// CardManagement.js
import React, { useEffect, useState } from 'react';
import InputField from '../../SubComponents/InputField/InputField'; // Adjust path as necessary
import Button from '../../SubComponents/Button/Button'; // Adjust path as necessary
import styles from './CardManagement.module.css'; // Create this file for styles if needed
import axios from 'axios';
import { BASE_URL } from '../../../../config'; // Adjust this import if needed
import { addCard, getCards } from '../../../utils/APIs/CardsApi'; // Adjust this import if needed
import { GetUser } from '../../../utils/Auth/Auth'; // Adjust this import if needed

const CardManagement = () => {
  const [cards, setCards] = useState([]);
  const [cardHolder, setCardHolder] = useState("");
  const [cardNumber, setCardNumber] = useState("");
  const [cvv, setCvv] = useState("");
  const [bankName, setBankName] = useState("");
  const [expiryDate, setExpiryDate] = useState("");
  const [isAddingCard, setIsAddingCard] = useState(false);
  const user = GetUser();

  // Fetch cards on component mount
  useEffect(() => {
    fetchCards();
  }, []);

  // API call to fetch cards
  const fetchCards = async () => {
    try {
      const fetchedCards = await getCards();
      setCards(fetchedCards);
    } catch (error) {
      console.error('Failed to fetch cards:', error.response ? error.response.data : error.message);
    }
  };

  // Handle input changes for the new card
  const handleCardHolderChange = (e) => setCardHolder(e.target.value);
  const handleCardNumberChange = (e) => setCardNumber(e.target.value);
  const handleCvvChange = (e) => setCvv(e.target.value);
  const handleBankNameChange = (e) => setBankName(e.target.value);
  const handleExpiryDateChange = (e) => setExpiryDate(e.target.value);

  // Handle adding a new card
  const handleAddCard = async () => {
    const newCard = {
      cardHolder,
	  cardNumber,
	  cvv,
	  bankName,
	  expiryDate,
    };

    try {
      const results = await axios.post(`${BASE_URL}/api/card`, newCard, {
        headers: {
          Authorization: `Bearer ${user.token}`,
          'Content-Type': 'application/json',
        },
      });

      // Update the state with the added card
      setCards((prevCards) => [...prevCards, results.data]);

      // Reset input fields after adding a card
      setInputFields({
        cardHolder: '',
        cardNumber: '',
        cvv: '',
        bankName: '',
        expiryDate: '',
      });
    } catch (error) {
      console.error('Error saving card:', error);
    }
  };

  // Handle deleting a card
  const handleDeleteCard = async (cardId) => {
    try {
      await axios.delete(`${BASE_URL}/api/card/${cardId}`, {
        headers: {
          Authorization: `Bearer ${user.token}`,
        },
      });
      fetchCards(); // Refresh card list
    } catch (error) {
      console.error('Failed to delete card:', error);
    }
  };

  return (
    <div className={styles['card-management']}>
      <h2>Manage Your Cards</h2>
      

      {/* Toggle form visibility */}
      <button onClick={() => setIsAddingCard(!isAddingCard)}>
        {isAddingCard ? 'Cancel' : 'Add Card'}
      </button>

      {/* Conditionally render the add card form */}
      {isAddingCard && (
        <div className={styles['card-form']}>
          <InputField
            type="text"
            placeholder="Card Holder"
            value={cardHolder}
            onChange={handleCardHolderChange}
            name="cardHolder" // Ensure the name attribute matches the state property
          />
          <InputField
            type="text"
            placeholder="Card Number"
            value={cardNumber}
            onChange={handleCardNumberChange}
            name="cardNumber" // Ensure the name attribute matches the state property
          />
          <InputField
            type="text"
            placeholder="CVV"
            value={cvv}
            onChange={handleCvvChange}
            name="cvv" // Ensure the name attribute matches the state property
          />
          <InputField
            type="text"
            placeholder="Bank Name"
            value={bankName}
            onChange={handleBankNameChange}
            name="bankName" // Ensure the name attribute matches the state property
          />
          <InputField
            type="date"
            value={expiryDate}
            onChange={handleExpiryDateChange}
            name="expiryDate" // Ensure the name attribute matches the state property
          />
          <button onClick={handleAddCard}>Submit</button>
        </div>
      )}

      {/* Button to view cards */}
      <button onClick={fetchCards}>View Cards</button>

      {/* Render card list */}
      <ul className={styles['card-list']}>
        {cards.map((card) => (
          <li key={card.id} className={styles['card-item']}>
            {card.cardNumber} - {card.expiryDate}
            <button onClick={() => handleDeleteCard(card.id)} className={styles['delete-button']}>
              Delete
            </button>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default CardManagement;
