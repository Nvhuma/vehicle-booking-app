import React from 'react';
import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import Login from './Components/Pages/Login/Login';
import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';



function App() {

  return (
    <Router>
      <div className="App">
        <Routes>
        <Route path="/" element={<Navigate to="/Login" />} />
          <Route path="/Login" element={<Login />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
