import React from 'react';
import './App.css'
import Register from './Components/Pages/Register/Register';
import Login from './Components/Pages/Login/Login';
import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import ForgotPassword from './Components/Pages/ForgotPassword/ForgotPassword';



function App() {

  return (
    <Router>
      <div className="App">
        <Routes>
        <Route path="/" element={<Navigate to="/Login" />} />
          <Route path="/Login" element={<Login />} />
          <Route path="/Register" element={<Register />} /> 
          <Route path="/ForgotPassword" element={<ForgotPassword />} /> 
        </Routes>
      </div>
    </Router>
  );
}

export default App;
