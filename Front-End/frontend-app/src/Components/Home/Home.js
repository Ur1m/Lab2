import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Typography from '@mui/material/Typography';
import { CardActionArea } from '@mui/material';

import './../../Css/bootstrap.css';


export const Home = () =>{
    return <div className='container'> 
     <div class="row back">
            <div class="col-6 text-center">
                 <h1>LEARNOW THE NR.1 ONLINE TEACHING PLATFORM </h1>
                 <div  class="row m-5">
                     <p>“THE MAN ON TOP OF THE MOUNTAIN DIDN’T FALL THERE, START MAKING YOUR WAY UP”</p>
                </div>
            </div>
            
            <div class="col-md-5 offset-md-1">
            <Card sx={{ maxWidth: 1000 }}>
            <CardActionArea>
                <CardMedia
                className='classes.media'
                component="img"
                height="140"
                image="/img/course.jpg"
                alt="green iguana"
                />
                <CardContent>
                <Typography gutterBottom variant="h5" component="div">
                    Programing Full-stack course 
                </Typography>
                <Typography variant="body2" color="text.secondary">
                    This course provides one of the best section of web development with intereactive examples

                </Typography>
                </CardContent>
            </CardActionArea>
            </Card>
            </div>
            
         </div>
   
    <div className='d-flex mt-5 text-center xxx'>
        <p>
            We help organizations of all types and sizes prepare for the path ahead — wherever it leads. 
            Our curated collection of business and technical courses help companies, 
            governments, and nonprofits go further by placing learning at the center of their strategies.
       </p>
    </div>
</div>
}