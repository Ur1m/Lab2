import React, { useState, useEffect } from "react";
import axios from "axios";

export const ForgotPassword = () => {
  const [email, setEmail] = useState("");
  const [message, setMessage] = useState("");
  const [data, setData] = useState();
  const [isError, setIsError] = useState();

  useEffect(() => {}, []);

  async function login() {
    let item = { email };
    let result = await axios
      .post("http://localhost:5003/api/Account/forgot-password", item)
      .then((res) => {
        setIsError(false);
        setData("A reset link has been sent!");
        setEmail("");
      })
      .catch((err) => {
        setIsError(true);
        setData(err.response.statusText);
      });
  }

  return (
    <div className="login-container">
      <div className="login-form">
        <div className="textbox">
          <h3>Reset Your Password</h3>
          <p className="paragrafff">
            Lost your password? Please enter your email address. <br />
            You will receive a link to create a new password via email.
          </p>
        </div>
        <div>
          <input
            type="text"
            placeholder="Email"
            onChange={(e) => setEmail(e.target.value)}
            className="form-control"
          />
          <br />
          <button onClick={login} className="btn btn-primary">
            Reset
          </button>
          <br />
          <br />
          {data && (
            <div className="form-group">
              <div
                className={
                  isError ? "alert alert-danger" : "alert alert-success"
                }
                role="alert"
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

export default ForgotPassword;
