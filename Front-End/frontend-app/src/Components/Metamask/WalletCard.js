import React, { useState } from "react";
import { ethers } from "ethers";
import "./WalletCard.css";
import "./../../Css/bootstrap.css";
import Box from "@mui/material/Box";
import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import CardMedia from "@mui/material/CardMedia";
import Typography from "@mui/material/Typography";

<script
  src="https://cdn.ethers.io/lib/ethers-5.0.umd.min.js"
  type="text/javascript"
></script>;

const WalletCard = () => {
  const [errorMessage, setErrorMessage] = useState(null);
  const [defaultAccount, setDefaultAccount] = useState(null);
  const [userBalance, setUserBalance] = useState(null);
  const [connButtonText, setConnButtonText] = useState("Connect Wallet");

  const connectWalletHandler = () => {
    if (window.ethereum && window.ethereum.isMetaMask) {
      console.log("MetaMask Here!");

      window.ethereum
        .request({ method: "eth_requestAccounts" })
        .then((result) => {
          accountChangedHandler(result[0]);
          setConnButtonText("Wallet Connected");
          getAccountBalance(result[0]);
        })
        .catch((error) => {
          setErrorMessage(error.message);
        });
    } else {
      console.log("Need to install MetaMask");
      setErrorMessage("Please install MetaMask browser extension to interact");
    }
  };

  // update account, will cause component re-render
  const accountChangedHandler = (newAccount) => {
    setDefaultAccount(newAccount);
    getAccountBalance(newAccount.toString());
  };

  const getAccountBalance = (account) => {
    window.ethereum
      .request({ method: "eth_getBalance", params: [account, "latest"] })
      .then((balance) => {
        setUserBalance(ethers.utils.formatEther(balance));
      })
      .catch((error) => {
        setErrorMessage(error.message);
      });
  };

  const chainChangedHandler = () => {
    // reload the page to avoid any errors with chain change mid use of application
    window.location.reload();
  };

  // listen for account changes
  window.ethereum.on("accountsChanged", accountChangedHandler);

  window.ethereum.on("chainChanged", chainChangedHandler);

  return (
    <div className="walletCard">
      <Card sx={{ display: "flex" }}>
        <Box sx={{ display: "flex", flexDirection: "column" }}>
          <CardContent sx={{ flex: "1 0 auto" }}>
            <Typography component="div" variant="h5">
              <h4> Connect to Metamask wallet </h4>
            </Typography>
            <Typography
              variant="subtitle1"
              color="text.secondary"
              component="div"
            >
              <button
                className="btn btn-btn btn-outline-primary"
                onClick={connectWalletHandler}
              >
                {connButtonText}
              </button>
              <div className="accountDisplay">
                <p>Address: {defaultAccount}</p>
              </div>
              <div className="balanceDisplay">
                <p>Balance: {userBalance}</p>
              </div>
            </Typography>
          </CardContent>
        </Box>
        <CardMedia
          className="classes.media"
          component="img"
          height="400px"
          image="/img/metamask1.png"
          alt="green iguana"
        />
      </Card>
    </div>
  );
};

export default WalletCard;
