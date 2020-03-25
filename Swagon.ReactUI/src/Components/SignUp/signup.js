import React from "react";
import './signup.css';

const SignUp = () => {
    return(
    <div className="SignupContainer">
        <h2>Signup</h2>
        <hr></hr>
        <form  class="form">
           
                <div className="form-groupe  field  ">
                    <input className="form-control" id="UserName" placeholder="Tonny@strak.tech" className="UserName"></input>
                    <label htmlFor="UserName">UserName</label>
                </div>
                <div className="form-groupe field ">
                    <input  type="password" className="form-control" id="PassWord" placeholder="🤫🤫🤫🤫🤫" className="PassWord"></input>
                    <label htmlFor="PassWord">Password</label>
                </div>
                <div className="form-groupe field ">
                    <input type="password" className="form-control" id="CPassWord" placeholder="prove youe memmory" className="CPassWord"></input>
                    <label htmlFor="CPassWord">Password</label>
                </div>
              
            <div className="sbutton">
                <button type="submit" className="btn btn-sub">Submit</button>
            </div>
        </form>
    </div>
    );
}
export default SignUp;
