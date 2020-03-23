import React from 'react';
import './dashboard.css';

import Logo from '../../Components/Logo/logo'

const Dashboard = ({Name}) => {
    return(
    <div className="Grid">
        <Logo/>
        <div className="empty"></div>
        <div className = "name"><h3 >Hey John {Name}</h3></div>
        <div className = "options">
            <h3 id="book" className = "option"> Book A Ride</h3>
            <h3 id ="offer" className ="option">  Offer A Ride</h3>
        </div>
    </div>
    );
} 
export default Dashboard;