import React, { useState, useEffect } from 'react';
import styles from './UsersList.Module.css'; // Importing the CSS Module

const UsersList = () => {
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [percentage, setPercentage] = useState('');
  const [adjustPriceStatus, setAdjustPriceStatus] = useState('');
  const [servicePrices, setServicePrices] = useState([]); // New state for service prices

  useEffect(() => {
    // Fetch users data
    const fetchUsers = async () => {
      try {
        const token = localStorage.getItem('token');
        if (!token) {
          throw new Error('User is not logged in');
        }

        const response = await fetch('http://localhost:5287/api/User/all', {
          method: 'GET',
          headers: {
            'Authorization': `Bearer ${token}`,
            'Accept': '*/*',
          },
        });

        if (!response.ok) {
          throw new Error('Failed to fetch users');
        }

        const data = await response.json();
        setUsers(data);
      } catch (err) {
        setError(err.message);
      } finally {
        setLoading(false);
      }
    };

    // Fetch service prices data
    const fetchServicePrices = async () => {
      try {
        const token = localStorage.getItem('token');
        if (!token) {
          throw new Error('User is not logged in');
        }

        const response = await fetch('http://localhost:5287/api/Admin/service-prices', {
          method: 'GET',
          headers: {
            'Authorization': `Bearer ${token}`,
            'Accept': '*/*',
          },
        });

        if (!response.ok) {
          throw new Error('Failed to fetch service prices');
        }

        const data = await response.json();
        setServicePrices(data);
      } catch (err) {
        setError(err.message);
      }
    };

    fetchUsers();
    fetchServicePrices();
  }, []);

  const handleAdjustPrice = async () => {
    try {
      const token = localStorage.getItem('token');
      if (!token) {
        throw new Error('User is not logged in');
      }

      const response = await fetch('http://localhost:5287/api/Admin/adjust-prices', {
        method: 'POST',
        headers: {
          'Authorization': `Bearer ${token}`,
          'Content-Type': 'application/json-patch+json',
        },
        body: JSON.stringify({ percentage: parseFloat(percentage) }),
      });

      if (!response.ok) {
        throw new Error('Failed to adjust prices');
      }

      setAdjustPriceStatus('Prices adjusted successfully.');
    } catch (err) {
      setAdjustPriceStatus(`Error: ${err.message}`);
    }
  };

  if (loading) {
    return <p>Loading...</p>;
  }

  if (error) {
    return <p>Error: {error}</p>;
  }

  return (
    <div className={styles.cardContainer}>
      <h1>User List</h1>
      <div className={styles.usersList}>
        {users.map((user) => (
          <div className={styles.userCard} key={user.id}>
            <h3 className={styles.name}>{user.name} {user.surname}</h3>
            <p className={styles.email}>{user.email}</p>
            <p className={styles.phoneNumber}>{user.phoneNumber}</p>
            <p className={styles.gender}>{user.gender}</p>
            <p className={styles.userId}>User ID: {user.id}</p>
          </div>
        ))}
      </div>

      {/* Adjust Prices Section with Service Price Cards */}
      <div className={styles.adjustPriceCard}>
        <h2>Adjust Service Prices</h2>
        <input
          type="number"
          value={percentage}
          onChange={(e) => setPercentage(e.target.value)}
          placeholder="Enter percentage"
          className={styles.input}
        />
        <button onClick={handleAdjustPrice} className={styles.adjustButton}>
          Adjust Prices
        </button>
        {adjustPriceStatus && <p className={styles.statusMessage}>{adjustPriceStatus}</p>}

        {/* Service Price Cards */}
        <div className={styles.servicePriceList}>
          {servicePrices.map((service) => (
            <div className={styles.serviceCard} key={service.id}>
              <h3>{service.make} {service.model} ({service.year})</h3>
              <p>Horsepower Range: {service.horsepowerRange}</p>
              <p>Torque Range: {service.torqueRange}</p>
              <p>Max Towing Capacity: {service.maxTowingCapacity} lbs</p>
              <p>Emission Standard: {service.emissionStandard}</p>
              <p>Service Type ID: {service.serviceTypeId}</p>
              <p>Price: <span className={styles.price}></span> ${service.price.toFixed(2)}</p>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
};

export default UsersList;
