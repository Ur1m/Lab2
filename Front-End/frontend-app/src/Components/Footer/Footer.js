import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import CardMedia from "@mui/material/CardMedia";
import Typography from "@mui/material/Typography";
import { CardActionArea } from "@mui/material";
import "./../../Css/bootstrap.css";
import "../Footer/footer.css";

export const Footer = () => {
  return (
    <div>
     <div className="footer">
         <div className="text-center p-3 fff">
                  © 2020 Copyright:
              <a className="text-darkk" href="https://google.com/">MDBootstrap.com</a>
         </div>
     </div>
    </div>
  );
};