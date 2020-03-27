import React from 'react';
import './StopsDetails.css';
import art0 from './artifact0.png'
import art1 from './atifact1.png'



const StopsDetails = ({cities,}) => {
    return(
    <div>
    <div className="card BookingContainer">

<div className="BookingHead">

<div className="Headtest">
<h3>Offer a Ride</h3>
<h10>We get your matches asap!</h10>
</div>
<div className="art0Div"><img className = "art0" src = {art0}/></div>
</div>

<form  class="form">
<div className="art1Main"> 
    <div className="form-group  field  fromLoc">
        <input className="form-control" id="Stop1" placeholder="Delhi" className="FromLocation"></input>
        <label htmlFor="Stop1">Stop 1</label>
    </div>
    <div className="art1Div"><img className = "art1" src = {art1}/></div>
    <div className="form-group field toLoc">
        <input  className="form-control" id="Stop2" placeholder="Hyderabad" className="ToLocation"></input>
        <label htmlFor="Stop2">Stop 2</label>
    </div>
</div>

<div className="subss">
    <div>
    <label  className="time">Available Seats</label>
        <div class="radio-toolbar">

            <input type="radio" id="i1" name="radioTime" value="5am-9am" />
            <label for="i1">1</label>

            <input type="radio" id="i2" name="radioTime" value="9am-12pm"/>
            <label for="i2">2</label>

            <input type="radio" id="i3" name="radioTime" value="12pm-3pm"/>
            <label for="i3">3</label>
        </div>
        </div>
        <div>
        <label  className="Price">Price</label>
        <h5>1800Rs</h5>
        </div>
</div>

<div className="sbutton">
    <button type="submit" className="btn btn-primary">Next >>></button>
</div>
</form>

</div>

    </div>
    );
} 
export default StopsDetails;