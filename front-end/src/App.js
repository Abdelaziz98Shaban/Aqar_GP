import { Routes, Route } from "react-router-dom";
import React from "react";
import NavBar from "./components/NavBar/NavBar";
import Home from "./pages/Home";
import Properties from "./pages/Properties";
import Search from "./pages/Search";
function App() {
  return (
    <>
      <NavBar />
      <Routes>
        <Route exact path='/' element={<Home />} />
        <Route path='/properties' element={<Properties />} />
        <Route path='/search' element={<Search />} />
      </Routes>
    </>
  );
}

export default App;
