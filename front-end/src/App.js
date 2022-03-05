import { Routes, Route } from "react-router-dom";
import React from "react";
import NavBar from "./components/NavBar/NavBar";
import Home from "./pages/Home";
import Properties from "./pages/Properties";
import Search from "./pages/Search";
import Signin from "./pages/Signin";
import Signup from "./pages/Signup";

function App() {
  console.log(JSON.parse(localStorage.getItem("persist:root")));
  return (
    <>
      <NavBar />
      <Routes>
        <Route exact path='/' element={<Home />} />
        <Route path='/properties' element={<Properties />} />
        <Route path='/search' element={<Search />} />
        <Route path='/signin' element={<Signin />} />
        <Route path='/signup' element={<Signup />} />
      </Routes>
    </>
  );
}

export default App;
