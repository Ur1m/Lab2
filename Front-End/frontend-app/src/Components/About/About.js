import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import CardMedia from "@mui/material/CardMedia";
import Typography from "@mui/material/Typography";
import { useTheme } from "@mui/material/styles";
import { CardActionArea } from "@mui/material";
import "../About/about.css";
import Box from "@mui/material/Box";
import "./../../Css/bootstrap.css";
import { Link } from "react-router-dom";
import { useState, useEffect } from "react";
import axios from "axios";

export const About = () => {
  const theme = useTheme();
  const [prod, setProd] = useState();
  const [user, setUser] = useState(null);

  useEffect(() => {
    axios.get("https://localhost:5001/api/Product").then((response) => {
      setProd(response.data);
    });
    axios.get("https://localhost:5000/api/account").then((response) => {
      setUser(response.data);
      console.log(response.data);
    });
    //console.log("data");
  }, []);

  function addToCart(id) {
    if (user != null) {
      axios.post("https://localhost:44352/api/ShoppingCart", {
        userId: user.id,
        productId: id,
      });
    } else {
      alert("login first");
    }
  }
  return (
    <div>
      <div className="back">
        <div className="row back">
          <div className="col-5">
            <h1 className="textComeTeach">
              Inspire learners, <br></br> Teach what you know <br></br> and help
              learners explore their interests.
            </h1>
            <div className="row">
              <ul className="navbar-nav me-auto">
                <li className="nav-item">
                  <Link
                    className="btn btn-primary float-right bttn "
                    to="/register"
                  >
                    Sign up
                  </Link>
                </li>
              </ul>
            </div>
          </div>

          <div className="col-md-7">
            <Card sx={{ display: "flex" }}>
              <Box sx={{ display: "flex", flexDirection: "column" }}>
                <CardContent sx={{ width: 250, marginTop: 3 }}>
                  <Typography component="div" variant="h5">
                    Meet Sara
                  </Typography>
                  <Typography
                    variant="subtitle1"
                    color="text.secondary"
                    component="div"
                  >
                    CEO
                  </Typography>
                </CardContent>
                <Box
                  sx={{
                    display: "flex",
                    alignItems: "center",
                    pl: 1,
                    pb: 1,
                    maxWidth: 230,
                    textAlign: "center",
                    marginTop: 1,
                  }}
                >
                  <Typography component="div" variant="">
                    Sara is the CEO and co-founder of LearnNow, an online
                    learning platform that offers courses in a wide range of
                    topics, from programming and design to business and personal
                    development.
                  </Typography>
                </Box>
              </Box>
              <CardActionArea>
                <CardMedia
                  className="classes.media"
                  component="img"
                  height="350"
                  image="/img/girl.jpg"
                  alt="green iguana"
                />
              </CardActionArea>
            </Card>
          </div>
        </div>
      </div>
      <div>
        <div className="textKnowMore">
          <h1> Wanna know more ?</h1>
        </div>

        <div className="d-flex justify-content-around content">
          <div className="gifOne"></div>

          <div className="gifyText">
            <h5>
              You won’t have to do it alone, Our Instructor Support Team is here
              to answer your questions and review your test video, while our
              Teaching Center gives you plenty of resources to help you through
              the process. Plus, get the support of experienced instructors in
              our online community.
            </h5>
          </div>

          <div className="gifTwo"></div>
        </div>
      </div>

      <div className="d-flex justify-content-around statistics">
        <div className="stats">
          <div className="number">
            <h1>57M</h1>
          </div>
          <div className="paragraph">
            <h5>Students</h5>
          </div>
        </div>

        <div className="stats">
          <div className="number">
            <h1>73M +</h1>
          </div>
          <div className="paragraph">
            <h5>Enrollments</h5>
          </div>
        </div>

        <div className="stats">
          <div className="number">
            <h1>17M</h1>
          </div>
          <div className="paragraph">
            <h5>Countries</h5>
          </div>
        </div>

        <div className="stats">
          <div className="number">
            <h1>6</h1>
          </div>
          <div className="paragraph">
            <h5>Languages</h5>
          </div>
        </div>
      </div>
      <div className="sektor">
        <div className="compniesBox">
          <div className=" upCompanies">
            <div className="company1"></div>
            <div className="company2"></div>
            <div className="company3"></div>
          </div>

          <div className="downCompanies">
            <div className="company4"></div>
            <div className="company5"></div>
          </div>
        </div>

        <div className="companiesText">
          <h3>
            Our sponsors provide financial support, products, or services that
            help us to continue to offer high-quality courses to our millions of
            users around the world. In return, we work with our sponsors to
            promote their brands and products in a way that is meaningful and
            effective for both parties.
            <br />
            Together, we are making a difference in the lives of millions of
            people and helping to shape the future of education.
          </h3>
        </div>
      </div>
    </div>
  );
};
