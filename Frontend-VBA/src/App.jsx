import React from 'react';
import './App.css'
import Register from './Components/Pages/Register/Register';
import Login from './Components/Pages/Login/Login';
import { BrowserRouter as Router, Route, Routes, BrowserRouter } from 'react-router-dom';
import ForgotPassword from './Components/Pages/ForgotPassword/ForgotPassword';
import ResetPassword from './Components/Pages/ResetPassword/ResetPassword';
import ProtectedRoutes from './utils/ProtectedRoutes';
import Dashboard from './Components/Pages/Dashboard/Dashboard';
import Profile from './Components/Pages/Profile/Profile';



function App() {

  return (
    <BrowserRouter>
      <div className="App">
        <Routes>
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
          <Route path="/forgotPassword" element={<ForgotPassword />} />
          <Route path="/resetpassword" element={<ResetPassword />} />
          
          <Route element={<ProtectedRoutes/>}>
            <Route path='/' element={<Dashboard />}/>
            <Route path='/profile' element={<Profile />}/>
          </Route>       
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
