import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import CardMedia from "@mui/material/CardMedia";
import Typography from "@mui/material/Typography";
import { CardActionArea } from "@mui/material";
import { Welcome } from "./Welcome";
import { Categories } from "./Categories";
import "./../../Css/bootstrap.css";

export const Home = () => {
  return (
    <div className="container">
      <Welcome />
      <Categories />
    </div>
  );
};