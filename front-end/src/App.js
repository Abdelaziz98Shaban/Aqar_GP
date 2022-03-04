import { Routes, Route } from "react-router-dom";
import React from "react";
import NavBar from "./components/NavBar/NavBar";
import Home from "./pages/Home";
import Properties from "./pages/Properties";
function App() {
  return (
    <>
      <NavBar />
      <Routes>
        <Route exact path='/' element={<Home />} />
        <Route path='/properties' element={<Properties />} />
      </Routes>
    </>
  );
}

export default App;
