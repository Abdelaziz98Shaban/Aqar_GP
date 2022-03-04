import { Routes, Route } from "react-router-dom";
import React from "react";
import NavBar from "./components/NavBar/NavBar";
import Home from "./pages/Home";
import Property from "./components/Property";
function App() {
  return (
    <>
      <NavBar />
      <Routes>
        <Route exact path='/' element={<Home />} />
        <Route path='/property' element={<Property/>}/>
      </Routes>
    </>
  );
}

export default App;
