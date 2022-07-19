import React, { useState, useEffect } from "react";
import { Header } from "semantic-ui-react";
import { observer } from "mobx-react-lite";
import axios from "axios";
import styless from "../Login/styless.css"

export const LoginComponent = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  useEffect(() => {}, []);

  async function login() {
    let item = { email, password };
    let result = await axios.post(
      "http://localhost:5000/api/Account/login",
      item
    );
  }

  return (
    <div className="wraper">
      
    <div className="containerr">
      <div className="textbox">
        <h3>Welcome To Lernow</h3>
        <p className="paragrafff">Please enter your credentials</p>
      </div>
      <div className="col-sm-4 ">
        <input
          type="text"
          placeholder="email"
          onChange={(e) => setEmail(e.target.value)}
          className="form-control"
        />
        <br />
        <input
          type="password"
          placeholder="password"
          onChange={(e) => setPassword(e.target.value)}
          className="form-control"
        />
        <br />
        <button onClick={login} className="btn btn-primary">
          Login
        </button>
      </div>
    </div>
    </div>
  );
};

export default LoginComponent;
