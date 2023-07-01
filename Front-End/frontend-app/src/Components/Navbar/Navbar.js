import "./../../Css/bootstrap.css";
import "../Home/home.css";
import { Link } from "react-router-dom";
import axios from "axios";

const user = JSON.parse(localStorage.getItem("user"));

export const Navbar = () => {
  const handleLogout = async () => {
    try {
      await axios.post("https://localhost:5003/api/Account/logout");
      localStorage.removeItem("user");
      window.location.reload(); // Refresh the page after logout
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <>
      <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
        <div className="container-fluid">
          <a className="navbar-brand" href="#">
            LearNow
          </a>
          <button
            className="navbar-toggler"
            type="button"
            data-bs-toggle="collapse"
            data-bs-target="#navbarColor02"
            aria-controls="navbarColor02"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span className="navbar-toggler-icon"></span>
          </button>

          <div className="collapse navbar-collapse" id="navbarColor02">
            <ul className="navbar-nav me-auto">
              <li className="nav-item">
                <Link className="nav-link active" to="/">
                  Home
                </Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link active" to="/courses">
                  Courses
                </Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link active" to="/products">
                  Add Products
                </Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link active" to="/addtocart">
                  Cart
                </Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link active" to="/about">
                  About
                </Link>
              </li>
            </ul>

            {user && user.userName ? (
              <button className="btn btn-secondary float-right" onClick={handleLogout}>
                Log Out from: {user.userName}
              </button>
            ) : (
              <div>
                <Link className="btn btn-secondary float-right" to="/login">
                  Log in
                </Link>
                <Link className="btn btn-primary float-right" to="/register">
                  Sign up
                </Link>
              </div>
            )}
          </div>
        </div>
      </nav>
    </>
  );
};
