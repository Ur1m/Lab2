import React, { useState, useEffect } from "react";
import { Header } from "semantic-ui-react";
import { observer } from "mobx-react-lite";
import axios from "axios";
import styless from "../Login/styless.css"

export const RegisterComponent = () => {
  const [Name, setName] = useState("");
  const [Email, setEmail] = useState("");
  const [Password, setPassword] = useState("");
  const [data, setData] = useState();
  const [isError, setIsError] = useState();
  useEffect(() => {}, []);

  async function register() {
    let item = { Name, Email, Password };
    let result = await axios.post(
      "http://localhost:5003/api/Operations/createUser",
      item
    ).then(res => {
        setIsError(false);
        setData("Registered successfully!");
      })
        .catch(err => {
          setIsError(true);
          setData(err.response.statusText);
        });
  }

  return (
    <div className="wraper">
      
    <div className="containerr">
      <div className="textbox">
        <h3>Welcome To Learnow</h3>
        <p className="paragrafff">Please enter your info</p>
      </div>
      <div className="col-sm-4 ">
      <input
          type="text"
          placeholder="Name and Surname"
          onChange={(e) => setName(e.target.value)}
          className="form-control"
        />
        <br />
        <input
          type="text"
          placeholder="Email"
          onChange={(e) => setEmail(e.target.value)}
          className="form-control"
        />
        <br />
        <input
          type="password"
          placeholder="Password"
          onChange={(e) => setPassword(e.target.value)}
          className="form-control"
        />
        <br />
        <button onClick={register} className="btn btn-primary">
          Register
        </button>
        <br />
          <br />
          {data && (
            <div className='form-group'>
              <div
                className={isError ? 'alert alert-danger' : 'alert alert-success'}
                role='alert'
              >
                {data}
              </div>
            </div>
          )}
        </div>
      </div>

    </div>
  );
};

export default RegisterComponent;
