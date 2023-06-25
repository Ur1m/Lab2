import { Card, CardActionArea, CardContent, CardMedia, Typography, Button, Grid } from "@mui/material";
import "../Courses/courses.css";
import "./../../Css/bootstrap.css";
import { useState, useEffect } from "react";
import axios from "axios";
export const Courses = () => {
  const [prod, setProd] = useState();
  // const { user, setUser } = useContext(UserContext);

  useEffect(() => {
    axios.get("https://localhost:5002/api/Product").then((response) => {
      setProd(response.data);
    });
    //console.log("data");
  }, []);

  function addToCart(id) {
    const user = JSON.parse(localStorage.getItem("user"));
    console.log(user);

    if (user != null) {
      debugger;
      axios.post("https://localhost:5002/api/Product/sendProductToCart", {
        userId: user.id,
        productId: id,
      });
    } else {
      alert("login first");
    }
  }
  return (
    <div className="back">
      <Grid container spacing={3}>
        {prod != null &&
          prod.map((p) => (
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
                    <div style={{ marginTop: "1rem", display: "flex", justifyContent: "flex-end" }}>
                      <Button onClick={() => addToCart(p.id)} variant="contained" color="success" sx={{ mr: 1 }}>
                        Add to Cart
                      </Button>
                      <Button onClick={() => addToCart(p.id)} variant="contained" color="success" sx={{ mr: 1 }}>
                        Add to Wishlist
                      </Button>
                      <Button onClick={() => addToCart(p.id)} variant="contained" color="success">
                        Add to Compare
                      </Button>
                    </div>
                  </CardContent>
                </CardActionArea>
              </Card>
            </Grid>
          ))}
      </Grid>
    </div>
  );
};
