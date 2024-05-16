import React, { useState, useEffect } from "react";
import axios from "axios";
import {
  MDBBtn,
  MDBCard,
  MDBCardBody,
  MDBModal,
  MDBModalHeader,
  MDBModalBody,
  MDBModalFooter,
  MDBInput,
  MDBContainer,
} from "mdb-react-ui-kit";

export default function AddToCart() {
  const [cartProducts, setCartProducts] = useState([]);
  const [totalPrice, setTotalPrice] = useState(0);
  const [showModal, setShowModal] = useState(false);
  const [formData, setFormData] = useState({
    cardNumber: "",
    month: "",
    year: "",
    cvc: "",
    value: 0,
  });
  const [purchaseSuccess, setPurchaseSuccess] = useState(false);

  useEffect(() => {
    const user = JSON.parse(localStorage.getItem("user"));
    if (user !== null) {
      axios
        .get(`https://localhost:5005/api/ShoppingCart/${user.id}`)
        .then((response) => {
          setCartProducts(response.data);
          calculateTotalPrice(response.data);
        })
        .catch((error) => console.error("Error fetching cart products:", error));
    } else {
      alert("Please log in first");
    }
  }, []);

  const calculateTotalPrice = (products) => {
    const totalPrice = products.reduce((sum, product) => sum + product.price, 0);
    setTotalPrice(totalPrice);
  };

  const handlePurchase = () => {
    axios
      .post("https://localhost:5005/api/ShoppingCart/purchaseProduct", formData)
      .then((response) => {
        // Handle successful purchase
        console.log("Purchase successful", response.data);
        setPurchaseSuccess(true);
        clearCart();
        setShowModal(false);
      })
      .catch((error) => {
        // Handle purchase failure
        console.error("Purchase failed", error);
        // Optionally, display an error message to the user
      });
  };

  const clearCart = () => {
    axios
      .delete("https://localhost:5005/api/ShoppingCart/clear")
      .then((response) => {
        console.log("Cart cleared successfully", response);
        // Clear the cart state in the front end
        setCartProducts([]);
        setTotalPrice(0);
      })
      .catch((error) => {
        console.error("Failed to clear cart", error);
      });
  };

  const handleInputChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleClearCart = () => {
    // Send a DELETE request to clear the cart
    axios
      .delete("https://localhost:5005/api/ShoppingCart/clear")
      .then((response) => {
        console.log("Cart cleared successfully", response);
        // Clear the cart state in the front end
        setCartProducts([]);
        setTotalPrice(0);
      })
      .catch((error) => {
        console.error("Failed to clear cart", error);
      });
  };

  return (
    <MDBContainer className="py-5">
      <div className="d-flex justify-content-between align-items-center mb-4">
        <h3>Shopping Cart</h3>
        <MDBBtn color="danger" onClick={handleClearCart}>
          Clear Cart
        </MDBBtn>
      </div>

      {cartProducts.length > 0 ? (
        <MDBCard className="rounded-3 mb-4">
          <MDBCardBody>
            <h5 className="card-title">Total Price</h5>
            <h6 className="card-subtitle mb-2 text-muted">Products:</h6>
            <ul className="list-group">
              {cartProducts.map((product) => (
                <li key={product.id} className="list-group-item">
                  {product.name}
                  <span className="float-end">${product.price}</span>
                </li>
              ))}
            </ul>

            <div className="text-end">
              <h6 className="mt-3">Total: ${totalPrice}</h6>
            </div>

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
      ) : (
        <p>No products in the cart</p>
      )}

      {/* Purchase Modal */}
      <MDBModal show={showModal} tabIndex="-1" className="custom-modal" backdrop={true}>
        <MDBModalHeader>Confirm Purchase</MDBModalHeader>
        <MDBModalBody>
          <div className="mb-3">
            <MDBInput
              label="Card Number"
              name="cardNumber"
              type="text"
              value={formData.cardNumber}
              onChange={handleInputChange}
            />
          </div>
          <div className="mb-3">
            <MDBInput
              label="Month"
              name="month"
              type="text"
              value={formData.month}
              onChange={handleInputChange}
            />
          </div>
          <div className="mb-3">
            <MDBInput
              label="Year"
              name="year"
              type="text"
              value={formData.year}
              onChange={handleInputChange}
            />
          </div>
          <div className="mb-3">
            <MDBInput
              label="CVC"
              name="cvc"
              type="text"
              value={formData.cvc}
              onChange={handleInputChange}
            />
          </div>
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

      {purchaseSuccess && (
        <div className="purchase-success-message">
          <p>Purchase successful!</p>
        </div>
      )}
    </MDBContainer>
  );
}
