import logo from './logo.svg';
import './App.css';
import React, { useEffect, useState } from 'react';
import NavBar from './components/NavBar'
import Footer from './components/Footer'

function App() {
  const [hidden, Set_hidden] = useState(true);
  const handleClick = () =>{
    Set_hidden(!hidden);
  
  }

return (
<div>
      <NavBar></NavBar>
      <Footer></Footer>
    </div>
       );
}
export default App;
