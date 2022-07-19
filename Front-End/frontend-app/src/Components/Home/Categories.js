import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import CardMedia from "@mui/material/CardMedia";
import Typography from "@mui/material/Typography";
import { CardActionArea } from "@mui/material";
import "./../../Css/bootstrap.css";
import "../Home/home.css";
import { useState,useEffect } from "react";
import axios from 'axios';
export const Categories = () => {
  const [categories,setCategories]=useState();

  useEffect(()=> {
    axios.get("https://localhost:44303/api/category").then((response) => {
        setCategories(response.data)
        
    });
    //console.log("data");
    
},[]);
  return (
    <div>
      <div className="col p-4 w-100 categories">
        <h2 className="text-center">MOST POPULAR CATEGORIES</h2>
        <div className="row">
          <div className="col Back-1"></div>
          <div className="col Back-2"></div>
          <div className="col Back-3"></div>
        </div>
        <div className="row">
          {categories!=null && categories.map(c=>(
            <div className="col titull"><h4>{c.name}</h4></div>
        
          ))}
          
        </div>
      </div>
     
    </div>
  );
};