import { Routes, Route, Navigate } from "react-router-dom";
import React from "react";
import NavBar from "./components/NavBar/NavBar";
import Home from "./pages/Home";
import Properties from "./pages/Properties";
import Search from "./pages/Search";
import Signin from "./pages/Signin";
import Signup from "./pages/Signup";
import { useSelector } from "react-redux";

function App() {
  const { isAuthenticated } = useSelector(state => state.auth);
  return (
    <>
      <NavBar />
      <Routes>
        <Route exact path='/' element={<Home />} />
        <Route path='/properties' element={<Properties />} />
        <Route path='/search' element={<Search />} />
        <Route
          path='/signin'
          element={
            isAuthenticated ? <Navigate replace to='/properties' /> : <Signin />
          }
        />
        <Route
          path='/signup'
          element={
            isAuthenticated ? <Navigate replace to='/properties' /> : <Signup />
          }
        />
      </Routes>
    </>
  );
}

export default App;
