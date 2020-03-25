import React from 'react';
import './Matchcard.css';
import art from './art1.png'
import avtar from './avtar.png'


const Match = ({Name = "Clint", To ="Hyderabad",From ="Delhi", date ="05/09/2020",time = "5am - 9pm", price = 950, SeatAvailability = 4 }) => {
    return(
        <div className = "match card">
        <div className="from"> <h3>{Name}</h3> <img className="avtar" src ={avtar}/> </div> 
        <div className="rideDesc">
        <div>
             <h15>From</h15>
                <div className = "from"> 
                <h4>{From}</h4>
                <img className="art" src ={art}/> 
                </div>
        </div>
        <div> <h15>To</h15><h4>{To}</h4>     </div>
        <div> <h15>Date</h15><h4>{date}</h4> </div>
        <div> <h15>TIme</h15><h4>{time}</h4> </div>
        <div> <h15>Price</h15><h4>Rs.{price}</h4> </div>
        <div><h15>Seat Avilability</h15><h4>{SeatAvailability}</h4></div>
        </div>
    </div> 
    );
} 
export default Match;