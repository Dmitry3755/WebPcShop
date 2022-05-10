import React, { useEffect, useState } from 'react';
import { makeStyles } from '@material-ui/core/styles';
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
    backgroung: {
            background: "#C0C0C0",
    },
        
}));

const Register = () =>
{
    const [Email, Set_Email] = useState([]);
    const [Password, Set_Password] = useState([]);
    const [Password_confirm, Set_Password_confirm] = useState([]);
    const classes = useStyles();

    const Add_new_user = (data) =>
    {
        data.preventDefault();
        fetch("http://localhost:36964/api/Account/Register",
        {
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                Email: Email,
                Password : Password,
                PasswordConfirm : Password_confirm,
            }),
            credentials: 'include'            
        })
        .then(response=>{
            response.json();//typeof response.data.error !== "undefined" && setErrors(response.data.error)
            console.log(response);
            alert("Добавлен новый пользователь");
        })
        .catch(console.error);
        
    }

    return(
        <div className={classes.register}>
            <form style={{margin: "9.5%"}}>
                <h2 className={classes.h2}>Регистрация</h2>
                <div >Введите email:</div><input value={Email} onChange={e=>Set_Email(e.target.value)} type="text" placeholder="Введите email" />
                <div className={classes.dataInput}>Введите пароль:</div><input value={Password} onChange={e=>Set_Password(e.target.value)} type="password" placeholder="Введите пароль" />
                <div className={classes.dataInput}>Подтвердите пароль:</div><input value={Password_confirm} onChange={e=>Set_Password_confirm(e.target.value)} type="password" placeholder="Подтвердите пароль"/><br/>
                <br></br>
                <Button style={{width: "190px", marginBottom: "7%"}} variant="outlined" color="inherit" onClick={Add_new_user}>Зарегистрироваться</Button>
            </form>
        </div>
    );
}
export default Register