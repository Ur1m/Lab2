import React from "react";
import "./../../Css/bootstrap.css";
import "./../AddToCart/addCart.css";
import { useState, useEffect } from "react";
import axios from "axios";

import {
  MDBBtn,
  MDBCard,
  MDBCardBody,
  MDBModal,
  MDBModalHeader,
  MDBModalBody,
  MDBModalFooter,
  MDBCardImage,
  MDBCol,
  MDBContainer,
  MDBIcon,
  MDBInput,
  MDBRow,
  MDBTypography,
} from "mdb-react-ui-kit";

export default function AddToCart() {
  const [cardProd, setCardProd] = useState();
  const [totalPrice, setTotalPrice] = useState(0);
  const [showModal, setShowModal] = useState(false);
  const [formData, setFormData] = useState({
    cardNumber: "",
    month: "",
    year: "",
    cvc: "",
    value: 0,
  });

  const handlePurchase = () => {
    axios
      .post("https://localhost:5005/api/ShoppingCart/purchaseProduct", formData)
      .then((response) => {
        // Handle successful response
        console.log("Purchase successful", response.data);
        // ... Additional logic or UI updates ...
      })
      .catch((error) => {
        // Handle error
        console.error("Purchase failed", error);
        // ... Additional error handling or UI updates ...
      });
  };
  
  const handleInputChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  useEffect(() => {
    const user = JSON.parse(localStorage.getItem("user"));
    if (user != null) {
      axios
        .get("https://localhost:5005/api/ShoppingCart/" + user.id)
        .then((response) => {
          setCardProd(response.data);
          console.log(response.data);
        });
  console.log(cardProd);

    } else {
      alert("login first");
    }
  }, []);

  useEffect(() => {
    if (cardProd && cardProd.length > 0) {
      const prices = cardProd.map((p) => p.price);
      const totalPrice = prices.reduce((sum, price) => sum + price);
      setTotalPrice(totalPrice);
    }
  }, [cardProd]);
  
  return (
    <div className="container">
      <MDBContainer className="py-5 h-100">
        {/* ...existing JSX code... */}
        <div className="d-flex justify-content-between align-items-center mb-4">
          {/* ...existing JSX code... */}
          <div>
            {/* ...existing JSX code... */}
          </div>
        </div>
        {/* ...existing JSX code... */}

        {/* Total Price Card */}
        <MDBCard className="rounded-3 mb-4">
          <MDBCardBody>
            <h5 className="card-title">Total Price</h5>
            <h6 className="card-subtitle mb-2 text-muted">Products:</h6>
            {cardProd && cardProd.length > 0 ? (
              <ul className="list-group">
                {cardProd.map((p) => (
                  <li key={p.id} className="list-group-item">
                    {p.name}
                    <span className="float-end">${p.price}</span>
                  </li>
                ))}
              </ul>
            ) : (
              <p>No products in the cart</p>
            )}

            {/* Total Price */}
            <div className="text-end">
              <h6 className="mt-3">Total: ${totalPrice}</h6>
            </div>

            {/* Purchase Button */}
            <MDBBtn
              color="success"
              className="float-end mt-3"
              style={{ fontWeight: "bold", fontFamily: "Arial" }}
              onClick={() => setShowModal(true)}
            >
              Purchase
            </MDBBtn>
          </MDBCardBody>
        </MDBCard>
      </MDBContainer>

      {/* Purchase Modal */}
      <MDBModal
        show={showModal}
        tabIndex="-1"
        className="custom-modal"
      >
        <MDBModalHeader>Confirm Purchase</MDBModalHeader>
        <MDBModalBody>
          <MDBInput
            label="Card Number"
            name="cardNumber"
            type="text"
            value={formData.cardNumber}
            onChange={handleInputChange}
          />
          <MDBInput
            label="Month"
            name="month"
            type="text"
            value={formData.month}
            onChange={handleInputChange}
          />
          <MDBInput
            label="Year"
            name="year"
            type="text"
            value={formData.year}
            onChange={handleInputChange}
          />
          <MDBInput
            label="CVC"
            name="cvc"
            type="text"
            value={formData.cvc}
            onChange={handleInputChange}
          />
          <MDBInput
            label="Value"
            name="value"
            type="number"
            value={formData.value}
            onChange={handleInputChange}
          />
        </MDBModalBody>
        <MDBModalFooter>
          <MDBBtn color="secondary" onClick={() => setShowModal(false)}>
            Cancel
          </MDBBtn>
          <MDBBtn color="primary" onClick={handlePurchase}>
            Confirm
          </MDBBtn>
        </MDBModalFooter>
      </MDBModal>
    </div>
  );
}