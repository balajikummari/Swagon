import React from 'react';
import './BookingForm.css';


const BookingForrm = ({Name = "Clint", matchesList = ["Andy","bobby"] }) => {
    return(
   
         <div className="card BookingContainer">
            <h3>Book A Ride {Name}</h3>
            <h10>We get your matches asap!</h10>
            <form  class="form ">
            <div className="form-group rounded field">
                <input className="form-control" id="FromLocation" placeholder="Delhi" className="FromLocation"></input>
                <label htmlFor="FromLocation">FromLocation</label>
            </div>

            <div className="form-group rounded field">
                <input  className="form-control" id="ToLocation" placeholder="Hyderabad" className="ToLocation"></input>
                <label htmlFor="ToLocation">ToLocation</label>
            </div>

            <div className="form-group rounded field">
                <input type="date" className="form-control" id="date" placeholder="when is it..." className="date"></input>
                <label htmlFor="date">Date</label>
            </div>

            <div className="sbutton">
                <button type="submit" className="btn btn-primary">Submit</button>
            </div>
        </form>

        </div>
    );
} 
export default BookingForrm;