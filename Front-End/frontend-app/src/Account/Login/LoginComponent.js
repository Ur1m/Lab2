import { useState, useContext } from 'react';
import axios from 'axios';
import UserContext from '../../UserContext';


export const LoginComponent = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const { setUser } = useContext(UserContext);

  async function login() {

    const body = JSON.stringify({
      email: email,
      password: password,
    });

    try {
      const response = await axios.post("https://localhost:5003/api/Account/login", body, {
        headers: {
          "Content-Type": "application/json",
        },
      });
      const user = response.data;
      console.error(user.userName);
      setUser(user);
    } catch (error) {
      console.error(error);
    }
  };

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
        </div>
      </div>
    </div>
  );
};

export default LoginComponent;
