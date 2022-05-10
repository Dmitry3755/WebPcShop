import { Component } from "react";
import { Modal, Button, AppBar, Toolbar, List, ListItem, ListItemText, Container } from '@material-ui/core'
import React, { useEffect, useState } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import {
  BrowserRouter,
  Routes,
  Route
} from "react-router-dom";
import Products from "./Products";
import Register from "./Register";
import Authentification from "./Authentification";
import Suppliers from "./Suppliers";

const useStyles = makeStyles({
  navDisplayFlex: {
    display: `flex`,
    justifyContent: `space-between`,
  },
  linkText: {
    color: `#F0E68C`,
  },
  colorNavBar: {
    background: `#320b35`,
    color: `#7FFFD4`
  },
});
const navLinks = [
  { title: `Поставщики`, path: `/suppliers` },
  { title: `Продукты`, path: `/products` },
  { title: `Регистрация`, path: `/register` },
  { title: `Войти`, path: `/authentification` },
]

const NavBar = () => {

  const classes = useStyles();

  return (
    <div>
      <AppBar position="static" className= {classes.colorNavBar}>
        <Toolbar >
          <Container maxWidth="xl">
            <List className={classes.navDisplayFlex}>
              <ListItem>
                <ListItemText primary="Wish Master"></ListItemText>
              </ListItem>
              {navLinks.map(({ title, path }) => (
                <a href={path} key={title} className={classes.linkText} style={{ textDecoration: 'none' , width: "20%" }}>
                  <ListItem button className = {classes.linkText} style={{textAlign: "center"}}>
                    <ListItemText primary={title} />
                  </ListItem>
                </a>
              ))}
            </List>
          </Container>
        </Toolbar>
      </AppBar>
      <Routes>
        <Route path="/suppliers" element={<Suppliers />}/>
        <Route path="/register" element={<Register />}/>
        <Route path="/authentification" element={<Authentification />}/>
        <Route path="/products" element={<Products />}/>
      </Routes>
    </div>
  )
}
export default NavBar
