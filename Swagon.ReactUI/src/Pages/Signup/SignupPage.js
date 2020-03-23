import React from 'react';
import './SignupPage.css';

import Signup from '../../Components/SignUp/signup'
import Logo from '../../Components/Logo/logo'
import Intro from '../../Components/Intro/intro'



const SignupPage = () => {
    return(
    <div className="mycontainer">
        <div className="LogoItem">
        <Logo/>
        </div>
        <div className = "IntoItem">
        <Intro/>
        </div>
        <div className = "SignupItem">
        <Signup/>
        </div>
    </div>
    );
} 
export default SignupPage;