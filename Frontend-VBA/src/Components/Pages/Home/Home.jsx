import React, { useState } from 'react';
//import { Link } from 'react-router-dom';
import styles from './Home.module.css'; // Assuming you will create a CSS file
import CustomLogo from '../../SubComponents/CustomLogo/CustomLogo';
import { Person } from '@mui/icons-material';

const HomePage = () => {
  const [activeTab, setActiveTab] = useState('General');

  return (
    <div className={styles['container']}>
      {/**/}
      <div className={styles['sidebar']}>
        <div className={styles['logo-container']}>
          <CustomLogo variant="primary" className={styles['logo']} />
        </div>
        <ul className={styles['menu']}>
          <li
            className={`${styles['menu-item']} ${activeTab === 'General' ? styles['active'] : ''}`}
            onClick={() => setActiveTab('General')}
          >
            <Person/>  General
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

      {/* */}
      <div className={styles['content']}>
        <h1>{activeTab} Page</h1>
        {/**/}
      </div>
    </div>
  );
};

export default HomePage;
