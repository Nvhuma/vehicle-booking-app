import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Button from '../../SubComponents/Button/Button'; 
import styles from './AdminPanel.module.css';


function AdminPanel() {
  const [adjustPricePercentage, setAdjustPricePercentage] = useState(0);
  const [userId, setUserId] = useState('');
  const [newRole, setNewRole] = useState('');
  const [roles, setRoles] = useState([]);
  const [isLoadingRoles, setIsLoadingRoles] = useState(false);
  const [error, setError] = useState(null);

  // Fetch roles on component mount
  useEffect(() => {
    fetchRoles();
  }, []);

  // Function to fetch available roles
  const fetchRoles = async () => {
    setIsLoadingRoles(true);
    setError(null);
    try {
      const response = await axios.get('http://localhost:5287/api/Admin/Roles');
      setRoles(response.data);
    } catch (err) {
      setError('Failed to fetch roles');
    } finally {
      setIsLoadingRoles(false);
    }
  };

  // Function to adjust prices by a percentage
  const handleAdjustPrices = async () => {
    try {
      await axios.post('http://localhost:5287/api/Admin/adjust-prices', {
        percentage: adjustPricePercentage
      });
      alert('Prices adjusted successfully!');
    } catch (err) {
      setError('Failed to adjust prices');
    }
  };

  // Function to change user role
  const handleChangeRole = async () => {
    try {
      await axios.post( 'http://localhost:5287/api/Admin/change-role', {
        userId: userId,
        newRole: newRole
      });
      alert('User role updated successfully!');
    } catch (err) {
      setError('Failed to change user role');
    }
  };

  return (
    <div className={styles.adminPanel}>
      <h1>Admin Panel</h1>

      {error && <p style={{ color: 'red' }}>{error}</p>}

      <div className={styles.section}>
        <h2>Adjust Prices</h2>
        <input
          type="number"
          value={adjustPricePercentage}
          onChange={(e) => setAdjustPricePercentage(e.target.value)}
          placeholder="Percentage to adjust"
          className={styles.input}
        />
        <Button
          value="Adjust Prices"
          variant="primary"
          onClick={handleAdjustPrices}
        />
      </div>

      <div className={styles.section}>
        <h2>Change User Role</h2>
        <input
          type="text"
          value={userId}
          onChange={(e) => setUserId(e.target.value)}
          placeholder="User ID"
          className={styles.input}
        />
        <input
          type="text"
          value={newRole}
          onChange={(e) => setNewRole(e.target.value)}
          placeholder="New Role"
          className={styles.input}
        />
        <Button
          value="Change Role"
          variant="secondary"
          onClick={handleChangeRole}
        />
      </div>

      <div className={styles.section}>
        <h2>Available Roles</h2>
        {isLoadingRoles ? (
          <p>Loading roles...</p>
        ) : (
          <ul>
            {roles.map((role, index) => (
              <li key={index}>{role}</li>
            ))}
          </ul>
        )}
      </div>
    </div>
  );
}

export default AdminPanel;
