import React, { useState, useEffect } from 'react';
import Button from "../../SubComponents/Button/Button";

const Booking = () => {
  const [vehicleModels, setVehicleModels] = useState([]);
  const [serviceTypes, setServiceTypes] = useState([]);
  const [employees, setEmployees] = useState([]);
  const [selectedVehicle, setSelectedVehicle] = useState(null);
  const [selectedService, setSelectedService] = useState('');
  const [selectedEmployee, setSelectedEmployee] = useState('');
  const [desiredDateTime, setDesiredDateTime] = useState('');
  const [additionalNotes, setAdditionalNotes] = useState('');
  const [isLoading, setIsLoading] = useState(false);

  useEffect(() => {
    fetchVehicleModels();
    fetchServiceTypes();
    fetchEmployees();
  }, []);

  const fetchVehicleModels = async () => {
    setIsLoading(true);
    try {
      const response = await fetchData('http://localhost:5287/api/VehicleModel');
      if (response) setVehicleModels(response);
    } catch (error) {
      console.error('Error fetching vehicle models:', error);
    } finally {
      setIsLoading(false);
    }
  };

  const fetchServiceTypes = async () => {
    setIsLoading(true);
    const response = await fetchData('http://localhost:5287/api/ServiceTypes');
    if (response) setServiceTypes(response);
    setIsLoading(false);
  };

  const fetchEmployees = async () => {
    setIsLoading(true);
    const response = await fetchData('http://localhost:5287/api/Employee');
    if (response) setEmployees(response);
    setIsLoading(false);
  };

  const submitBooking = async () => {
    if (!selectedVehicle || !selectedService || !selectedEmployee || !desiredDateTime) {
      alert('Please complete all selections before booking.');
      return;
    }

    const bookingPayload = {
      vehicle: {
        make: selectedVehicle.make,
        model: selectedVehicle.model,
        year: selectedVehicle.year,
      },
      serviceType: selectedService,
      desiredDateTime,
      employeeId: parseInt(selectedEmployee),
      additionalNotes,
      vehicleModelId: selectedVehicle.vehicleModelId,
    };

    try {
      const response = await postData('http://localhost:5287/api/Bookings', bookingPayload);
      if (response) alert('Booking submitted successfully!');
    } catch (error) {
      console.error('Booking submission error:', error);
      alert('Failed to submit booking.');
    }
  };

  return (
    <div style={formContainerStyle}>
      <h2 style={{ textAlign: 'center', marginBottom: '20px' }}>Make a Booking</h2>

      <div style={inputRowStyle}>
        <select
          onChange={(e) => {
            const vehicle = vehicleModels.find(v => v.vehicleModelId === parseInt(e.target.value));
            setSelectedVehicle(vehicle);
          }}
          style={inputStyle}
        >
          <option value="">Select Vehicle Model</option>
          {vehicleModels.map(vehicle => (
            <option key={vehicle.vehicleModelId} value={vehicle.vehicleModelId}>
              {vehicle.make} {vehicle.model} ({vehicle.year})
            </option>
          ))}
        </select>

        <select onChange={(e) => setSelectedService(e.target.value)} style={inputStyle}>
          <option value="">Select Service Type</option>
          {serviceTypes.map(service => (
            <option key={service.serviceTypeId} value={service.serviceTypeId}>
              {service.name}
            </option>
          ))}
        </select>

        <select onChange={(e) => setSelectedEmployee(e.target.value)} style={inputStyle}>
          <option value="">Select Employee</option>
          {employees.map(employee => (
            <option key={employee.employeeId} value={employee.employeeId}>
              {employee.name}
            </option>
          ))}
        </select>
      </div>

      <div style={inputRowStyle}>
        <input
          type="datetime-local"
          value={desiredDateTime}
          onChange={(e) => setDesiredDateTime(e.target.value)}
          style={inputStyle}
        />

        <textarea
          placeholder="Additional Notes"
          value={additionalNotes}
          onChange={(e) => setAdditionalNotes(e.target.value)}
          style={textareaStyle}
        />
      </div>

      <Button
        variant="primary"
        value={isLoading ? 'Submitting...' : 'Submit Booking'}
        onClick={submitBooking}
        fullWidth
        disabled={isLoading}
      />
    </div>
  );
};

// Helper functions for fetch and post
async function fetchData(url) {
  try {
    const response = await fetch(url);
    if (!response.ok) throw new Error(`Error: ${response.status}`);
    return await response.json();
  } catch (error) {
    console.error(error);
    alert("Failed to fetch data from the server.");
  }
}

async function postData(url, data) {
  try {
    const token = localStorage.getItem("token");

    const response = await fetch(url, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${token}`,
        'Accept': 'application/json-patch+json',
      },
      body: JSON.stringify(data),
    });

    if (!response.ok) {
      const errorData = await response.json();
      console.error("Server responded with:", errorData);
      throw new Error(`Error: ${response.status} - ${errorData.message || response.statusText}`);
    }

    const responseData = await response.json();
    return responseData;
  } catch (error) {
    console.error(error);
    alert("Failed to submit booking.");
  }
}

// Styles
const formContainerStyle = {

  display: 'flex',
  flexDirection: 'column',
  width: '100%',
  maxWidth: '1200px',
  margin: 'auto',
  padding: '30px',
  border: '1px solid #ccc',
  borderRadius: '8px',
  backgroundColor: '#f9f9f9',
  position: 'relative',
	
};

const inputRowStyle = {
  display: 'flex',
  justifyContent: 'space-between',
  gap: '20px', 
  marginBottom: '20px', 
};

const inputStyle = {
  flex: '1', 
  padding: '10px',
  fontSize: '16px',
  borderRadius: '5px',
  border: '1px solid #ccc',
};

const textareaStyle = {
  flex: '2', 
  padding: '10px',
  fontSize: '16px',
  borderRadius: '5px',
  border: '1px solid #ccc',
  resize: 'vertical',
};

export default Booking;
