import React, { useState, useEffect } from 'react';
import styles from './Home.module.css';
import Sidemenu from '../../SubComponents/SideMenu/Sidemenu';
import { Outlet } from 'react-router-dom';

const HomePage = () => {
  

  return (
    <div className={styles['home-container']}>
    <Sidemenu />
    <Outlet/>
    </div>
  );
};

export default HomePage;
