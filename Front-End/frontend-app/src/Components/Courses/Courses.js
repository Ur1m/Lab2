import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import CardMedia from "@mui/material/CardMedia";
import Typography from "@mui/material/Typography";
import { CardActionArea } from "@mui/material";
import "../Courses/courses.css";
import WalletCard from '../Metamask/WalletCard';
import "./../../Css/bootstrap.css";




export const Courses = () => {
  return (
    <div className="back">
      <div className="row back">
        <div className="col-5 text-center">
          <h1>Our Best selling Courses</h1>
          <div className="row m-5">
            <p className="p-4">
              Get your self into bussnis, start making your way up and get your Course now!
              Discount only avaliable for Today!
            </p>
          </div>

          <div className="row m-6 icona">
            
          </div>

        </div>

        <div className="col-md-7">
          <Card sx={{ maxWidth: 800 }}>
            <CardActionArea>
              <CardMedia
                className="classes.media"
                component="img"
                height="120"
                image="/img/code.jpg"
                alt="green iguana"
              />
              <CardContent>
                <Typography gutterBottom variant="h5" component="div">
                  Programing Full-stack course
                </Typography>
                <Typography variant="body2" color="text.secondary">
                  This course provides one of the best section of web
                  development with intereactive examples
                </Typography>
                <Typography variant="body2" color="text.primary">
                  Price : 23$
                </Typography>
              </CardContent>
            </CardActionArea>
          </Card>

          <Card sx={{ maxWidth: 800 }}>
            <CardActionArea>
              <CardMedia
                className="classes.media"
                component="img"
                height="120"
                image="/img/backend.jpg"
                alt="green iguana"
              />
              <CardContent>
                <Typography gutterBottom variant="h5" component="div">
                  Programing Back-End Course
                </Typography>
                <Typography variant="body2" color="text.secondary">
                ou have a basic working knowledge of the Python programming language, which will be used in this course.

If you're looking to learn or refresh your knowledge of Python and programming, take a look at our courses Introduction to Computer Science and Programming Foundations with Python.
                </Typography>
                <Typography variant="body2" color="text.primary">
                  Price : 23$
                </Typography>
              </CardContent>
            </CardActionArea>
          </Card>
        </div>
      </div>
      </div>
  );
};