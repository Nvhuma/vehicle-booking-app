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
  const [userBookings, setUserBookings] = useState([]);
  const [isBookingsLoading, setIsBookingsLoading] = useState(true);
  const [isUpdateMode, setIsUpdateMode] = useState(false);
  const [currentBookingId, setCurrentBookingId] = useState(null);

  useEffect(() => {
    fetchVehicleModels();
    fetchServiceTypes();
    fetchEmployees();
    fetchUserBookings();
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

  const fetchUserBookings = async () => {
    try {
      const token = localStorage.getItem("token");
      const response = await fetch('http://localhost:5287/api/Bookings', {
        method: 'GET',
        headers: {
          'Authorization': `Bearer ${token}`,
          'Accept': 'application/json',
        },
      });
      if (response.ok) {
        const bookings = await response.json();
        setUserBookings(bookings);
      } else {
        console.error('Failed to fetch bookings');
      }
    } catch (error) {
      console.error('Error fetching user bookings:', error);
    } finally {
      setIsBookingsLoading(false);
    }
  };

  const handleDeleteBooking = async (bookingId) => {
    try {
      const token = localStorage.getItem("token");
      const response = await fetch(`http://localhost:5287/api/Bookings/${bookingId}`, {
        method: 'DELETE',
        headers: {
          'Authorization': `Bearer ${token}`,
          'Accept': 'application/json',
        },
      });

      if (response.ok) {
        alert("Booking deleted successfully.");
        fetchUserBookings();
      } else {
        const errorData = await response.json();
        console.error("Failed to delete booking:", errorData);
        alert(`Failed to delete booking: ${errorData.message || 'Unknown error'}`);
      }
    } catch (error) {
      console.error('Error deleting booking:', error);
      alert('Failed to delete booking.');
    }
  };

  const handleUpdateClick = (booking) => {
    setIsUpdateMode(true);
    setCurrentBookingId(booking.bookingId);
    
    // Find the matching vehicle model from our list
    const vehicleModel = vehicleModels.find(v => 
      v.make === booking.vehicle.make && 
      v.model === booking.vehicle.model && 
      v.year === booking.vehicle.year
    );
    
    // Pre-fill all the form fields
    setSelectedVehicle(vehicleModel);
    setSelectedService(booking.serviceType);
    setSelectedEmployee(booking.employeeId.toString());
    setDesiredDateTime(new Date(booking.desiredDateTime).toISOString().slice(0, 16));
    setAdditionalNotes(booking.additionalNotes || '');
  };

  const resetForm = () => {
    setSelectedVehicle(null);
    setSelectedService('');
    setSelectedEmployee('');
    setDesiredDateTime('');
    setAdditionalNotes('');
    setIsUpdateMode(false);
    setCurrentBookingId(null);
  };

  const submitOrUpdate = async () => {
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
      if (isUpdateMode) {
        const response = await putData(`http://localhost:5287/api/Bookings/${currentBookingId}`, bookingPayload);
        if (response) {
          alert('Booking updated successfully!');
          resetForm();
          fetchUserBookings();
        }
      } else {
        const response = await postData('http://localhost:5287/api/Bookings', bookingPayload);
        if (response) {
          alert('Booking submitted successfully!');
          resetForm();
          fetchUserBookings();
        }
      }
    } catch (error) {
      console.error(isUpdateMode ? 'Booking update error:' : 'Booking submission error:', error);
      alert(isUpdateMode ? 'Failed to update booking.' : 'Failed to submit booking.');
    }
  };

  const handleRefreshBookings = () => {
    fetchUserBookings();
  };

  return (
    <div style={formContainerStyle}>
      <h2 style={{ textAlign: 'center', marginBottom: '20px' }}>
        {isUpdateMode ? 'Update Booking' : 'Make a Booking'}
      </h2>

      {/* Booking Form */}
      <div style={inputRowStyle}>
        <select
          value={selectedVehicle ? selectedVehicle.vehicleModelId : ''}
          onChange={(e) => {
            const vehicle = vehicleModels.find(v => v.vehicleModelId === parseInt(e.target.value));
            setSelectedVehicle(vehicle || null);
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

        <select 
          value={selectedService} 
          onChange={(e) => setSelectedService(e.target.value)} 
          style={inputStyle}
        >
          <option value="">Select Service Type</option>
          {serviceTypes.map(service => (
            <option key={service.serviceTypeId} value={service.serviceTypeId}>
              {service.name}
            </option>
          ))}
        </select>

        <select 
          value={selectedEmployee} 
          onChange={(e) => setSelectedEmployee(e.target.value)} 
          style={inputStyle}
        >
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

      <div style={{ display: 'flex', gap: '10px' }}>
        <Button
          variant="primary"
          value={isLoading ? 'Submitting...' : (isUpdateMode ? 'Update Booking' : 'Submit Booking')}
          onClick={submitOrUpdate}
          fullWidth
          disabled={isLoading}
        />
        
        {isUpdateMode && (
          <Button
            variant="secondary"
            value="Cancel Update"
            onClick={resetForm}
            fullWidth
          />
        )}
      </div>

      {/* User Bookings Section */}
      <div style={bookingsContainerStyle}>
        <h2 style={{ textAlign: 'center', marginTop: '40px' }}>Your Bookings</h2>

        <Button
          variant="secondary"
          value="Refresh Bookings"
          onClick={handleRefreshBookings}
          style={refreshButtonStyle}
        />

        {isBookingsLoading ? (
          <p>Loading bookings...</p>
        ) : (
          <div style={{ marginTop: '20px' }}>
            {userBookings.map((booking) => (
              <div key={booking.bookingId} style={bookingBoxStyle}>
                <h3>{booking.vehicle?.make} {booking.vehicle?.model} ({booking.serviceType})</h3>
                <p>Status: {booking.bookingStatus}</p>
                <p>Date: {new Date(booking.desiredDateTime).toLocaleString()}</p>
                <p>Notes: {booking.additionalNotes || 'None'}</p>
                <div style={{ display: 'flex', gap: '10px', marginTop: '10px' }}>
                  <Button
                    variant="primary"
                    value="Update Booking"
                    onClick={() => handleUpdateClick(booking)}
                    fullWidth
                  />
                  <Button
                    variant="primary"
                    value="Delete Booking"
                    onClick={() => handleDeleteBooking(booking.bookingId)}
                    fullWidth
                    style={{ backgroundColor: 'red', color: 'white', border: 'none' }}
                  />
                </div>
              </div>
            ))}
          </div>
        )}
      </div>
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

async function putData(url, data) {
  try {
    const token = localStorage.getItem("token");

    const response = await fetch(url, {
      method: 'PUT',
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
    alert("Failed to update booking.");
  }
}

const formContainerStyle = {
  display: 'flex',
  flexDirection: 'column',
  width: '100%',
  maxWidth: '12000px',
  margin: 'auto',
  padding: '30px',
  border: '1px solid #ccc',
  borderRadius: '8px',
  backgroundColor: '#f9f9f9',
};

const inputRowStyle = {
  display: 'flex',
  gap: '15px',
  marginBottom: '20px',
};

const inputStyle = {
  padding: '10px',
  fontSize: '16px',
  border: '1px solid #ccc',
  borderRadius: '4px',
  flex: 1,
};

const textareaStyle = {
  padding: '10px',
  fontSize: '16px',
  border: '1px solid #ccc',
  borderRadius: '4px',
  flex: 1,
  height: '40px',
  marginTop: '10px',
};

const bookingsContainerStyle = {
  width: '100%',
  marginTop: '20px',
};

const bookingBoxStyle = {
  margin: '15px 0',
  padding: '15px',
  border: '1px solid #ddd',
  borderRadius: '5px',
};

const refreshButtonStyle = {
  alignSelf: 'flex-end',
};

export default Booking;
