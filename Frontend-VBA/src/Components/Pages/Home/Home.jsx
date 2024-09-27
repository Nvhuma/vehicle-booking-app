import React, { useState, useEffect } from 'react';
import styles from './Home.module.css';
import CustomLogo from '../../SubComponents/CustomLogo/CustomLogo';
import { Person } from '@mui/icons-material';
import { getCards, addCard, deleteCard } from '../../../utils/APIs/CardsApi';
import InputField from '../../SubComponents/InputField/InputField'; // Import the InputField component
import Button from '../../SubComponents/Button/Button'; // Import the Button component

const HomePage = () => {
  const [activeTab, setActiveTab] = useState('General');
  const [cards, setCards] = useState([]);
  const [isAddingCard, setIsAddingCard] = useState(false); // Toggle for showing add card form
  const [newCard, setNewCard] = useState({
    cardHolder: '',
    cardNumber: '',
    cvv: '',
    bankName: '',
    expiryDate: '',
  });

  // Fetch cards when 'Profile' tab is active
  useEffect(() => {
    if (activeTab === 'Profile') {
      fetchCards();
    }
  }, [activeTab]);

  // API call to fetch cards
  const fetchCards = async () => {
    try {
      const fetchedCards = await getCards();
      setCards(fetchedCards);
    } catch (error) {
      console.error('Failed to fetch cards:', error.response ? error.response.data : error.message); 
      // Use error.response to check for server-side errors and error.message for network issues
    }
  };
  

  // Handle input changes for the new card
  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setNewCard((prevCard) => ({
      ...prevCard,
      [name]: value
    }));
  };

  // Handle adding a new card
  const handleAddCard = async () => {
    try {
      await addCard(newCard);
      setIsAddingCard(false); // Hide the form after adding the card
      fetchCards(); // Refresh card list
    } catch (error) {
      console.error('Failed to add card:', error);
    }
  };

  // Handle deleting a card
  const handleDeleteCard = async (cardId) => {
    try {
      await deleteCard(cardId);
      fetchCards(); // Refresh card list
    } catch (error) {
      console.error('Failed to delete card:', error);
    }
  };

  return (
    <div className={styles['container']}>
      {/* Sidebar */}
      <div className={styles['sidebar']}>
        <div className={styles['logo-container']}>
          <CustomLogo variant="primary" className={styles['logo']} />
        </div>
        <ul className={styles['menu']}>
          <li
            className={`${styles['menu-item']} ${activeTab === 'General' ? styles['active'] : ''}`}
            onClick={() => setActiveTab('General')}
          >
            <Person /> General
          </li>
          <li
            className={`${styles['menu-item']} ${activeTab === 'Profile' ? styles['active'] : ''}`}
            onClick={() => setActiveTab('Profile')}
          >
            Profile
          </li>
          <li
            className={`${styles['menu-item']} ${activeTab === 'Advanced' ? styles['active'] : ''}`}
            onClick={() => setActiveTab('Advanced')}
          >
            Advanced
          </li>
          <li
            className={`${styles['menu-item']} ${activeTab === 'Support' ? styles['active'] : ''}`}
            onClick={() => setActiveTab('Support')}
          >
            Support
          </li>
        </ul>
      </div>

      {/* Content */}
      <div className={styles['card-content']}>
        <h1>{activeTab} Page</h1>

        {/* Conditionally render card management when Profile tab is active */}
        {activeTab === 'Profile' && (
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
                  value={newCard.cardHolder}
                  onChange={handleInputChange}
                  name="cardHolder"
                />
                <InputField
                  type="text"
                  placeholder="Card Number"
                  value={newCard.cardNumber}
                  onChange={handleInputChange}
                  name="cardNumber"
                />
                <InputField
                  type="text"
                  placeholder="CVV"
                  value={newCard.cvv}
                  onChange={handleInputChange}
                  name="cvv"
                />
                <InputField
                  type="text"
                  placeholder="Bank Name"
                  value={newCard.bankName}
                  onChange={handleInputChange}
                  name="bankName"
                />
                <InputField
                  type="text"
                  placeholder="Expiry Date"
                  value={newCard.expiryDate}
                  onChange={handleInputChange}
                  name="expiryDate"
                />
                <Button
                  variant="primary"
                  value="Submit"
                  fullWidth={true}
                  onClick={handleAddCard}
                />
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
        )}
      </div>
    </div>
  );
};

export default HomePage;
