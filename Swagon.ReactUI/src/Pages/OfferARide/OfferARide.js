import React from 'react';
import './OfferARide.css';
import Logo from '../../Components/Logo/logo'
import RideDetails from '../../Components/RideDeatils/RideDetails'
import StopDetails from '../../Components/StopsDetails/StopsDetails'



const OfferARide = () => {
    return(
        <div>
            <Logo/>
            <div className="details"> <RideDetails /><StopDetails /></div>
        </div>

    );
} 
export default OfferARide;