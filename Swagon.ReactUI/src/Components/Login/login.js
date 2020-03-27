import React from "react";
import './login.css';

const Login = () => {
    return(
    <div className="LoginContainer">
        <h2>Login</h2>
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
             
            <div className="sbutton">
                <button type="submit" className="btn btn-sub">Submit</button>
            </div>
            <div className="almem">New here? <a href="#">SignUP</a></div>
        </form>
    </div>
    );
}
export default Login;
