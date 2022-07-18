import React, {useState, useEffect} from "react";
import { Header } from "semantic-ui-react";
import { observer } from "mobx-react-lite";

export default observer(function LoginComponent(){
    const[email,setEmail]=useState("");
    const[password,setPassword]=useState("");
    useEffect(() =>{
    }, [])

    async function login(){
        console.warn(email,password);
        let item = {email,password};
        let result = await fetch("http://localhost:5000/api/Account/login",{
            method:'POST',
            headers: { 'Content-Type': 'application/json',
                    "Accept":'application/json'},
            body:JSON.stringify(item)
        });
        result = await result.json();
        localStorage.setItem(JSON.stringify(result));
    }
    

    return(
        <div>
            <Header></Header>
            <h1>Login</h1>
            <div className="col-sm-6 offset-sm-3">
                <input type="text" placeholder="email" onChange={(e) => setEmail(e.target.value)} className="form-control"/>
                <br/>
                <input type="password" placeholder="password" onChange={(e) => setPassword(e.target.value)} className="form-control"/>
                <br/>
                <button onClick={login} className="btn btn-primary">Login</button>
            </div>
        </div>
    )
}
)
