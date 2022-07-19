import LoginComponent from "./Account/Login/LoginComponent";
import AttributeList from "./Atributes/AttributeList";
import CategoryList from "./Category/CategoryList";
import { Navbar } from "./Components/Navbar/Navbar";

import React, { Fragment, useEffect, useState } from "react";
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link,
  RouteComponentProps,
  withRouter,
  useLocation,
  Routes,
  BrowserRouter,
} from "react-router-dom";
import { ProductsTable } from "./Components/Products/ProductsTable";
import { Home } from "./Components/Home/Home";
import ProductList from "./Products/ProductList";
import "./Components/Home/home.css";
import { Footer } from "./Components/Footer/Footer";
import ForgotPassword from "./Account/Login/ForgotPassword";
import RegisterComponent from "./Account/Login/RegisterComponent";
import { Courses } from "./Components/Courses/Courses";
import ResetPassword from "./Account/Login/ResetPassword";

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <Navbar />
        <Routes>
          <Route path="/" element={<Home />}></Route>
          <Route path="/courses" element={<Courses />}></Route>
          <Route path="/products" element={<ProductList />}></Route>
          <Route path="/login" element={<LoginComponent />}></Route>
          <Route path="/forgotpassword" element={<ForgotPassword />}></Route>
          <Route path="/register" element={<RegisterComponent />}></Route>
          <Route path="/reset-password" element={<ResetPassword />}></Route>
        </Routes>
      </header>
      <Footer/>

    </div>
  );
}

export default App;
