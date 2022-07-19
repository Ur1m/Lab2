import React, { useState, useEffect } from "react";
import { Header } from "semantic-ui-react";
import { observer } from "mobx-react-lite";
import axios from "axios";
import styless from "../Login/styless.css"

export const ResetPassword = () => {
  const [Password, setPassword] = useState("");
  const [CPassword, setCPassword] = useState("");
  useEffect(() => {}, []);

  async function reset() {
    let item = { Password };
    let result = await axios.post(
      "http://localhost:5000/api/reset-password",
      item
    );
  }

  return (
    <div className="wraper">
      
    <div className="containerr">
      <div className="textbox">
        <h3>Reset Your Password</h3>
        <p className="paragrafff">Please enter your new password</p>
      </div>
      <div className="col-sm-4 ">
        <input
          type="password"
          placeholder="Password"
          onChange={(e) => setPassword(e.target.value)}
          className="form-control"
        />
        <br />
        <input
          type="password"
          placeholder="Confirm Password"
          onChange={(e) => setCPassword(e.target.value)}
          className="form-control"
        />
        <br />
        <button onClick={reset} className="btn btn-primary">
          Reset
        </button>
      </div>
    </div>
    </div>
  );
};

export default ResetPassword;
