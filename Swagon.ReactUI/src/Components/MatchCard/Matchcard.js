import React from 'react';
import './Matchcard.css';


const Match = ({Name = "Clint", matchesList = ["Andy","bobby"] }) => {
    return(
        <div className = "match card">
        <h3>{Name}</h3>
        <div className="rideDesc">
        <div><h15>From</h15><h4>Delhi</h4></div>
        <div><h15>To</h15><h4>Hyderabad</h4></div>
        <div><h15>Date</h15><h4>xx/mm/yy</h4></div>
        <div><h15>TIme</h15><h4>5am - 9am</h4></div>
        <div><h15>Price</h15><h4>180USD</h4></div>
        <div><h15>Seat Avilability</h15><h4>02</h4></div>
        </div>
    </div>
    );
} 
export default Match;