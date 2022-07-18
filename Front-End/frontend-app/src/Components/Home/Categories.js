import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import CardMedia from "@mui/material/CardMedia";
import Typography from "@mui/material/Typography";
import { CardActionArea } from "@mui/material";
import "./../../Css/bootstrap.css";
import "../Home/home.css";

export const Categories = () => {
  return (
    <div>
      <div className="col p-4 w-100 categories">
        <h3 className="text-center">MOST POPULAR CATEGORIES</h3>
        <div className="row">
          <div className="col Back-1"></div>
          <div className="col Back-2"></div>
          <div className="col Back-3"></div>
        </div>
      </div>
    </div>
  );
};