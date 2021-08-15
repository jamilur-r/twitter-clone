import React from "react";
import { useLocation } from "react-router-dom";
import { Nav } from "../styles/Navbar.stc";

const Navbar = () => {
  const location = useLocation();

  if (location.pathname === "/signin" || location.pathname === "/signup") {
    return <div></div>;
  } else {
    return <Nav></Nav>;
  }
};

export default Navbar;
