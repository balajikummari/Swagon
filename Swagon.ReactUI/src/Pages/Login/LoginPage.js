import React from 'react';
import './LoginPage.css';

import Login from '../../Components/Login/login'
import Logo from '../../Components/Logo/logo'
import Intro from '../../Components/Intro/intro'



const LoginPage = () => {
    return(
    <div className="mycontainer">
        <div className="LogoItem">
        <Logo/>
        </div>
        <div className = "IntoItem">
        <Intro/>
        </div>
        <div className = "SignupItem">
        <Login/>
        </div>
    </div>
    );
} 
export default LoginPage;