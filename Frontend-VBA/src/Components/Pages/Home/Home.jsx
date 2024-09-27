import React, { useState, useEffect } from 'react';
import styles from './Home.module.css';
import CustomLogo from '../../SubComponents/CustomLogo/CustomLogo';
import { Person } from '@mui/icons-material';
import { getCards, deleteCard } from '../../../utils/APIs/CardsApi';
import InputField from '../../SubComponents/InputField/InputField'; // Import the InputField component
import Button from '../../SubComponents/Button/Button'; // Import the Button component
import axios from 'axios';
import { BASE_URL } from '../../../../config';
import { GetUser } from '../../../utils/Auth/Auth';
import CardManagement from '../CardManagement/CardManagement';

const HomePage = () => {
  const [activeTab, setActiveTab] = useState('General');
  const [cards, setCards] = useState([]);
  const [isAddingCard, setIsAddingCard] = useState(false); // Toggle for showing add card form
  const [inputFields, setInputFields] = useState({
    cardHolder: '',
    cardNumber: '',
    cvv: '',
    bankName: '',
    expiryDate: '',
  });
  const [userData, setUserData] = useState("");

  const user = GetUser();

  // Fetch cards when 'Profile' tab is active
  useEffect(() => {
    if (activeTab === 'Profile') {
      fetchCards();
    }
  }, [activeTab]);

  useEffect(() => {
    if (activeTab === 'General') {
      fetchUser();
    }
  }, [activeTab]);

  // API call to fetch cards
  const fetchCards = async () => {
    try {
      const fetchedCards = await getCards();
      setCards(fetchedCards);
    } catch (error) {
      console.error('Failed to fetch cards:', error.response ? error.response.data : error.message);
    }
  };

  const fetchUser = async () => {
    try {
      const results = await axios.get(`${BASE_URL}/api/user`, {
        headers: {
          Authorization: `Bearer ${user.token}`,
        },
      });

      console.log('Fetched user data:', results.data);
      setUserData(results.data);
    } catch (error) {
      console.error('Error fetching user data:', error);
    }
  };

  // Handle input changes for the new card
  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setInputFields((prevFields) => ({
      ...prevFields,
      [name]: value, // Update the specific field based on input name
    }));
  };

  // Handle adding a new card
  const handleAddCard = async () => {
    console.log("clicked");

    // Create the new card object from inputFields state
    const newCard = {
      ...inputFields,
    };

    try {
      const results = await axios.post(`${BASE_URL}/api/card`, newCard, {
        headers: {
          Authorization: `Bearer ${user.token}`,
          'Content-Type': 'application/json',
        },
      });

      // Assuming the API returns the added card, update the state
      setCards((prevCards) => [...prevCards, results.data]);
      console.log("card added");

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
          <CardManagement />
        )}

        {activeTab === 'General' && (
          <div>
            {userData && Object.entries(userData).map(([key, value]) => (
              <div key={key}>
                <p>
                  <span style={{ fontWeight: 700 }}>{key.replace(/([A-Z])/g, ' $1')}: </span>
                  {value}
                </p>
              </div>
            ))}
          </div>
        )}
      </div>
    </div>
  );
};

export default HomePage;
