import React, { useState, useEffect } from "react";
import axios from "axios";
import {
  Card,
  CardActionArea,
  CardContent,
  CardMedia,
  Typography,
  Button,
  Grid,
  Snackbar,
} from "@mui/material";
import "../Courses/courses.css";
import "./../../Css/bootstrap.css";

export const Courses = () => {
  const [prod, setProd] = useState([]);
  const [showSnackbar, setShowSnackbar] = useState(false);
  const [snackbarMessage, setSnackbarMessage] = useState("");

  useEffect(() => {
    axios.get("https://localhost:5002/api/Product").then((response) => {
      setProd(response.data);
    });
  }, []);

  function addToCart(id) {
    const user = JSON.parse(localStorage.getItem("user"));
    if (user != null) {
      axios
        .post("https://localhost:5002/api/Product/sendProductToCart", {
          userId: user.id,
          productId: id,
        })
        .then((response) => {
          setShowSnackbar(true);
          setSnackbarMessage("Course added to cart successfully");
        })
        .catch((error) => {
          console.error("Error adding course to cart:", error);
        });
    } else {
      alert("Please log in first");
    }
  }

  const handleSnackbarClose = () => {
    setShowSnackbar(false);
  };

  return (
    <div className="back">
      <Grid container spacing={3}>
        {prod.map((p) => (
          <Grid item xs={6} sm={4} md={3} key={p.id}>
            <Card sx={{ maxWidth: 345 }}>
              <CardActionArea>
                {p.image ? (
                  <CardMedia
                    component="img"
                    height="140"
                    image={p.image}
                    alt="Product Image"
                  />
                ) : (
                  <CardMedia
                    component="img"
                    height="140"
                    image="/img/code.jpg"
                    alt="Placeholder Image"
                  />
                )}
                <CardContent>
                  <Typography gutterBottom variant="h5" component="div">
                    {p.name}
                  </Typography>
                  <Typography variant="body2" color="text.secondary">
                    {p.description}
                  </Typography>
                  <Typography variant="h6" color="text.secondary">
                    Price: {p.price}$
                  </Typography>
                  <div
                    style={{
                      marginTop: "1rem",
                      display: "flex",
                      justifyContent: "flex-end",
                    }}
                  >
                    <Button
                      onClick={() => addToCart(p.id)}
                      variant="contained"
                      color="success"
                      sx={{ mr: 1 }}
                    >
                      Add to Cart
                    </Button>
                  </div>
                </CardContent>
              </CardActionArea>
            </Card>
          </Grid>
        ))}
      </Grid>
      <Snackbar
        open={showSnackbar}
        autoHideDuration={4000}
        onClose={handleSnackbarClose}
        message={snackbarMessage}
      />
    </div>
  );
};
