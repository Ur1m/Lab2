import { useState, useContext } from "react";
import axios from "axios";
import UserContext from "../../UserContext";

const LoginComponent = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const { setUser } = useContext(UserContext);
  const [error, setError] = useState(null);

  const handleLogin = async () => {
    const credentials = {
      email,
      password,
    };

    try {
      const response = await axios.post(
        "https://localhost:5003/api/Account/login",
        credentials,
        {
          headers: {
            "Content-Type": "application/json",
          },
        }
      );

      const user = response.data;
      localStorage.setItem("user", JSON.stringify(user));
      if (response.status === 200) {
        setUser(user);
        window.location = "/courses";
      }
    } catch (error) {
      setError(error.response.data.message);
    }
  };

  return (
    <div className="login-container">
      <div className="login-form">
        <h3>Welcome To LearnNow</h3>
        <p>Please enter your credentials</p>
        {error && <div className="error">{error}</div>}
        <input
          type="text"
          placeholder="Email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          className="form-control"
        />
        <input
          type="password"
          placeholder="Password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          className="form-control"
        />
        <a href="/forgotpassword">Forgot your Password?</a>
        <button onClick={handleLogin} className="btn btn-primary">
          Login
        </button>
      </div>
    </div>
  );
};

export default LoginComponent;
