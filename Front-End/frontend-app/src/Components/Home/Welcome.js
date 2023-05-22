import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import CardMedia from "@mui/material/CardMedia";
import Typography from "@mui/material/Typography";
import { CardActionArea } from "@mui/material";
import "../Home/home.css";
import WalletCard from "../Metamask/WalletCard";
import "./../../Css/bootstrap.css";

export const Welcome = () => {
  return (
    <div className="back">
      <div className="row back">
        <div className="col-5 text-center">
          <h1>LEARNOW THE NR.1 ONLINE TEACHING PLATFORM </h1>
          <div className="row m-5">
            <p className="p-4">
              “THE MAN ON TOP OF THE MOUNTAIN DIDN’T FALL THERE, START MAKING
              YOUR WAY UP”
            </p>
          </div>
        </div>

        <div className="col-md-7">
          <Card sx={{ maxWidth: 1000 }}>
            <CardActionArea>
              <CardMedia
                className="classes.media"
                component="img"
                height="140"
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
              </CardContent>
            </CardActionArea>
          </Card>
        </div>
      </div>

      <div className="d-flex mt-5 text-center xxx">
        <p className="paragraf">
          We help organizations of all types and sizes prepare for the path
          ahead — wherever it leads. Our curated collection of business and
          technical courses help companies, governments, and nonprofits go
          further by placing learning at the center of their strategies.
        </p>
      </div>
      <div className="d-flex justify-content-center Metamask"></div>
      <WalletCard />
      <p className="paragraf1">
        {" "}
        MetaMask allows users to store and manage account keys, broadcast
        transactions, send and receive Ethereum-based cryptocurrencies and
        tokens, and securely connect to decentralized applications through a
        compatible web browser or the mobile app's built-in browser. <br />
        Developers achieve a connection between Metamask and their decentralized
        applications by using a JavaScript plugin such as Web3js or Ethers to
        define interactions between Metamask and Smart Contracts. The Metamask
        application includes an integrated service for exchanging Ethereum
        tokens by aggregating several decentralized exchanges to find the best
        exchange rate. This feature, branded as MetaMask Swaps, charges a
        service fee of 0.875% of the transaction amount.
      </p>
    </div>
  );
};
