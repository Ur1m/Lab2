import React, { useState, useEffect } from "react";
import { Header } from "semantic-ui-react";
import { observer } from "mobx-react-lite";
import axios from "axios";
import styless from "../Login/styless.css"

export const ForgotPassword = () => {
    const [email, setEmail] = useState("");
    const [message, setMessage] = useState("");
    useEffect(() => {}, []);
  
    async function login() {
      let item = { email };
      let result = await axios.post(
        "http://localhost:5000/api/Account/forgot-password",
        item
      );

      if(result.status == 200){
       //do code here
      }else{
      //do code here
      }
    }
  
    return (
    <div className="wraper">
      
    <div className="containerr">
      <div className="textbox">
        <h3>Reset Your Password</h3>
        <p className="paragrafff">Lost your password? Please enter your email address. <br/>You will receive a link to create a new password via email.</p>
      </div>
      <div className="col-sm-4 ">
        <input
          type="text"
          placeholder="Email"
          onChange={(e) => setEmail(e.target.value)}
          className="form-control"
        />
        <br/>
        <button onClick={login} className="btn btn-primary">
          Reset
        </button>
      </div>
      <div>{setMessage}</div>
    </div>
    </div>
  );
};

export default ForgotPassword;
