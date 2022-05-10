import React, { useEffect, useState } from 'react';
import { Component } from "react";


var style ={
    background: "#D8BFD8",
    color: "#000000",
    borderTop: "1px solid #E7E7E7",
    textAlign: "center",
    padding: "1%",
    position: "fixed",
    left: "0",
    bottom: "0",
    height: "4%",
    width: "100%",
    
}

var phantom = {
    display: 'block',
    padding: '0',
    height: '15%',
    width: '100%',
    }

function footer() {
        return ( 
            <div>
                <div style={phantom} />
                <div style={style}>
                © 2022 ОАО 'Wish Master' Россия, Ивановская обл., г. Иваново.
                </div>
            </div>
        )
    }

   export class Footer extends Component
   {   
    render(){
        return(
            <div>{footer()}</div>
        )
    }
    }

export default Footer
