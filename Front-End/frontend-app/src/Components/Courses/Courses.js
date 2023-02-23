import { useContext } from 'react';
import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import CardMedia from "@mui/material/CardMedia";
import Typography from "@mui/material/Typography";
import { CardActionArea } from "@mui/material";
import "../Courses/courses.css";
import WalletCard from '../Metamask/WalletCard';
import "./../../Css/bootstrap.css";
import { useState,useEffect } from "react";
import axios from 'axios';
import UserContext from '../../UserContext';
import {Button} from 'semantic-ui-react';





export const Courses = () => {
  const[prod,setProd]=useState();
  const { user, setUser } = useContext(UserContext);


  useEffect(()=> {
    axios.get("https://localhost:5002/api/Product").then((response) => {
      setProd(response.data)
      });
      
      //console.log("data");
    
},[]);

function addToCart(id){  
console.log(user.userName)
console.log(user.id)
console.log(id)

  if(user !=null){
    axios.post("https://localhost:5002/api/ShoppingCart",{userId:user.id,productId:id});

  }
else{
   alert("login first")
  }

}
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
          {prod!=null && prod.map(p=>(
            <Card sx={{ maxWidth: 800 }}>
             <CardActionArea>
              {p.image ?(
               <CardMedia
                 className="classes.media"
                 component="img"
                 height="120"
                 image={p.image} 
                 alt="green iguana"
                 />
                  ) : (
               <CardMedia
                 className="classes.media"
                 component="img"
                 height="120"
                 image="/img/code.jpg"
                 alt="green ss"
                />
                )}
               <CardContent>
                 <Typography gutterBottom variant="h4" component="div">
                   {p.name}
                 </Typography>
                 <Typography variant="body2" color="text.secondary">
                  {p.description}
                 </Typography>
                 <Typography variant="h7" color="text.secondary">
                   Price : {p.price}$
                 </Typography>
                 <Typography variant="body2" color="text.primary">
                   <Button floated="right" onClick={()=> addToCart(p.id)} content={"AddTOCart"} color="green"/>
                   <Button floated="right" onClick={()=> addToCart(p.id)} content={"AddWishList"} color="green"/>
                   <Button floated="right" onClick={()=> addToCart(p.id)} content={"AddToCompare"} color="green"/>
                 </Typography>
               </CardContent>
             </CardActionArea>
           </Card>

          ))}
        
         
        </div>
      </div>
      </div>
  );
};