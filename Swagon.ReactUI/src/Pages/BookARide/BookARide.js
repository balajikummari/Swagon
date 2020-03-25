import React from 'react';
import BookingForm from "../../Components/Booking/BookingForm"
import Match from "../../Components/MatchCard/Matchcard"
import './BookARide.css';


import Logo from '../../Components/Logo/logo'

const BookARide = ({Name = "Clint", matchesList = ["Andy","bobby"] }) => {
    return(
    <div className="Grid">
        <div className="logo"><Logo/></div>
            <div className="column2">
                <div><BookingForm/></div>
                <div className="matchesSec">
                    <h2 className="matchesHeading">Your Matches</h2>
                    <div className = "matches">
                    <Match Name="Tonny"/>
                    <Match Name="Banner"/>
                    <Match Name="Natasha"/>
                    <Match Name="Clint"/>
                    {/* <Match Name="Hydra"/> */}
                    </div>
                </div>  
         </div>
    </div>
    );
} 
export default BookARide;