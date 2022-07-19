import "./../../Css/bootstrap.css";
import "../Home/home.css";
import { Link } from "react-router-dom";
export const Navbar = () => {
  return (
    <>
      <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
        <div className="container-fluid">
          <a className="navbar-brand" href="#">
            Lernow
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
                <Link className="nav-link active" to="/products">
                  Courses
                </Link>
              </li>
            </ul>
            <button type="button" className="btn btn-secondary  float-right">
              Log in
            </button>
            <button
              type="button"
              className="btn btn-primary float-right buton1"
            >
              <Link to="/products">Courses</Link>
            </button>
          </div>
        </div>
      </nav>
    </>
  );
};
