import { Component } from "react";
import React, { useEffect, useState } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import { Route } from 'react-router'
import Register from "./Register"
import { Link } from "react-router-dom";
import { Button } from '@material-ui/core';

const useStyles = makeStyles((theme) => ({

    register: {
        marginLeft: "43%",
        marginTop: "10%",
        marginRight: "45%",
        background: "#C0C0C0",
    },
    dataInput: {
        marginTop: "2%",
        marginTop: "2%",
    },
    h2: {
        marginLeft: "12%",
        position: "static",
    },
        
}));

const Authentification = ({}) =>
{
    const [Email, Set_email] = useState("");
    const [Password, Set_password] = useState([]);    
    const [Errors, setErrors] = useState([]);
    const [Role, set_Role] = useState("Менеджер");
    const classes = useStyles();

    const get_Current_User = (data) => 
    {
        //data.preventDefault();
        fetch("http://localhost:36964/api/Account/isAuthenticated",
        {
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            credentials: 'include'            
        })
        .then(response=>
            response.json()//typeof response.data.error !== "undefined" && setErrors(response.data.error)
        )
        .then(answer=> {
            if (typeof (answer.error) === 'undefined') {
                set_Role(answer.message);
            }
            else {
                setErrors(answer.error);
            }
        })
        .catch(console.error);
    
    }

    const Log_in = (data) =>
    {
        data.preventDefault();
        fetch("http://localhost:36964/api/Account/Login",
        {
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                Email: Email,
                Password : Password,
            }),
            credentials: 'include'            
        })
        .then(response=>
            response.json()//typeof response.data.error !== "undefined" && setErrors(response.data.error)
            // console.log(response);
            // set_Role(response.status);   //Сменить
        )
        .then(answer=> {
            if (typeof (answer.error) === 'undefined') {
                set_Role(answer.message);
            }
            else {
                setErrors(answer.error);
            }
        })
        .catch(console.error);
    }

    const Log_off = (data) =>
    {
        data.preventDefault();
        fetch("http://localhost:36964/api/Account/LogOff",
        {
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            credentials: 'include'            
        })
        .then(response=>{
            response.json();//typeof response.data.error !== "undefined" && setErrors(response.data.error)
            console.log(response);
            set_Role("Менеджер");   
        })
        .catch(console.error);
    }

    useEffect(() => {
        get_Current_User();
        
    }, []);

    return(
        <div >
            <div className={classes.register} >
            <form style={{margin: "9.5%"}}>
                {Errors}
                {Errors.forEach(({errorValue, index}) => (
                    <div key={"error"+index}>
                        {errorValue}
                    </div>
                ))}
                <div className={classes.dataInput} >Email: </div>
                <input className="form1_input" value={Email} onChange={e=>Set_email(e.target.value)} type="text" id="Email" name="Email" /> <br />
                <div className={classes.dataInput}>Пароль: </div>
                <input className="form1_input" value={Password} onChange={e=>Set_password(e.target.value)} type="password" id="Password" name="Password" /><br />
                <Button id="loginBtn" variant="outlined" color="inherit" style={{marginBottom: "5%", marginTop: "5%"}} onClick={Log_in}>Войти</Button>
                <Button id="logoffBtn" variant="outlined" color="inherit" style={{marginLeft: "10.6%", marginBottom: "5%", marginTop: "5%"}} onClick={Log_off}>Выйти</Button>
            </form>
            </div> 
            <div style={{marginLeft: "44%", marginTop: "-1%"}}>
                Вы вошли как {Role}
            </div>
        </div>    
    )
} 

export default Authentification