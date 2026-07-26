import React, { useState, useEffect } from 'react';
import styles from './Home.module.css';
import Sidemenu from '../../SubComponents/SideMenu/Sidemenu';
import { Outlet } from 'react-router-dom';
import TopHeader from '../../SubComponents/TopHeader/TopHeader';

const HomePage = () => {


  return (
    <div className={styles['home-container']}>
      <Sidemenu />
      <div className={styles["main-content"]}>
        <TopHeader />
        <Outlet />
      </div>
    </div>
  );
};

export default HomePage;
