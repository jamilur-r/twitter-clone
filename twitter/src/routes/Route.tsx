import React from "react";
import { BrowserRouter, Route, Switch } from "react-router-dom";
import SignInPage from "../pages/SignInPage";
import Navbar from "../widgets/Navbar";

const Router = () => {

  return (
    <BrowserRouter>
      <Navbar />
      <Switch>
        <Route path="/signin" component={SignInPage} exact/>
        <Route path="/signup" component={SignInPage} exact/>
      </Switch>
    </BrowserRouter>
  );
};

export default Router;
