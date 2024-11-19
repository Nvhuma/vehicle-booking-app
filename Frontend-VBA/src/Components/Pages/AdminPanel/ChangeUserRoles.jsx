import React, { useState, useEffect } from 'react';
import { GetUser } from "../../../utils/Auth/Auth";
import TopHeader from './TopHeader'; // Import the TopHeader component
import Button from './Button'; // Import the Button component for consistent styling
import styles from './ChangeUserRoles.module.css';

const ChangeUserRoles = () => {
  const [users, setUsers] = useState([]);
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchUsers = async () => {
      try {
        const token = localStorage.getItem('token');
        if (!token) throw new Error('User is not logged in');

        const response = await fetch('http://localhost:5287/api/User/all', {
          method: 'GET',
          headers: {
            'Authorization': `Bearer ${token}`,
            'Accept': '*/*',
          },
        });

        if (!response.ok) throw new Error('Failed to fetch users');

        const data = await response.json();
        setUsers(data);
      } catch (err) {
        setError(err.message);
      } finally {
        setLoading(false);
      }
    };

    fetchUsers();
  }, []);

  const handleRoleChange = async (userId, newRole) => {
    try {
      const token = localStorage.getItem('token');
      if (!token) throw new Error('User is not logged in');

      const response = await fetch(`http://localhost:5287/api/User/change-role/${userId}`, {
        method: 'POST',
        headers: {
          'Authorization': `Bearer ${token}`,
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ role: newRole }),
      });

      if (!response.ok) throw new Error('Failed to change user role');

      alert('Role updated successfully!');
    } catch (err) {
      alert(`Error: ${err.message}`);
    }
  };

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error}</p>;

  return (
    <div className={styles.container}>
      {/* Top Header Section */}
      <TopHeader />

      <h1 className={styles.title}>Manage User Roles</h1>
      <div className={styles.userList}>
        {users.map((user) => (
          <div key={user.id} className={styles.userCard}>
            <p className={styles.userName}>{user.fullName || `${user.firstName} ${user.lastName}`}</p>
            <p className={styles.userEmail}>{user.email}</p>
            <p className={styles.userRole}>Role: {user.role}</p>
            <div className={styles.actions}>
              {/* Use the Button component for consistency */}
              <Button
                variant="primary"
                value="Make Admin"
                onClick={() => handleRoleChange(user.id, 'Admin')}
                className={styles.actionButton}
              />
              <Button
                variant="secondary"
                value="Make User"
                onClick={() => handleRoleChange(user.id, 'User')}
                className={styles.actionButton}
              />
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

export default ChangeUserRoles;
