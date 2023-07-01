import LoginComponent from "./Account/Login/LoginComponent";
import { Navbar } from "./Components/Navbar/Navbar";

import React, { useState } from "react";
import { Route, Routes } from "react-router-dom";
import { Home } from "./Components/Home/Home";
import ProductList from "./Products/ProductList";
import { About } from "./Components/About/About";
import "./Components/Home/home.css";
import { Footer } from "./Components/Footer/Footer";
import ForgotPassword from "./Account/Login/ForgotPassword";
import RegisterComponent from "./Account/Login/RegisterComponent";
import { Courses } from "./Components/Courses/Courses";
import ResetPassword from "./Account/Login/ResetPassword";
import UserContext from "./UserContext";
import AddToCart from "./Components/AddToCart/AddToCart";

function App() {
  const [user, setUser] = useState(null);
  return (
    <div className="App">
      <header className="App-header">
        <UserContext.Provider value={{ user, setUser }}>
        <Navbar />
          <Routes>
            <Route path="/" element={<Home />}></Route>
            <Route path="/courses" element={<Courses />}></Route>
            <Route path="/products" element={<ProductList />}></Route>
            <Route path="/login" element={<LoginComponent />}></Route>
            <Route path="/forgotpassword" element={<ForgotPassword />}></Route>
            <Route path="/register" element={<RegisterComponent />}></Route>
            <Route path="/reset-password" element={<ResetPassword />}></Route>
            <Route path="/about" element={<About />}></Route>
            <Route path="/addToCart" element={<AddToCart />}></Route>
          </Routes>
        </UserContext.Provider>
      </header>
      <Footer />
    </div>
  );
}

export default App;
