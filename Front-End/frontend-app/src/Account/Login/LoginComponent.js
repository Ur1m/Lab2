import React, { useState, useEffect } from "react";
import { Header } from "semantic-ui-react";
import { observer } from "mobx-react-lite";
import axios from "axios";
import styless from "../Login/styless.css";
import { Route } from "react";
import Courses from "../../Components/Courses/Courses";


export const LoginComponent = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [data, setData] = useState();
  const [isError, setIsError] = useState();
  useEffect(() => { }, []);

  async function login() {
    let item = { email, password };
    let result = await axios.post(
      "http://localhost:5000/api/Account/login",
      item
    ).then(res => {
      setIsError(false);
      window.location.href = '/courses'
    })
      .catch(err => {
        setIsError(true);
        console.log(err);
        setData(err.message)
      });
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
          <a href="/forgotpassword">Forgot your Password?</a>
          <br />
          <br />
          <button onClick={login} className="btn btn-primary">
            Login
          </button><br />
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

export default LoginComponent;
