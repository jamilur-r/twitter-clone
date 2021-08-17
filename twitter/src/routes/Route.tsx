import React from "react";
import { BrowserRouter, Route, Switch } from "react-router-dom";
import Feed from "../pages/Feed";
import SignInPage from "../pages/SignInPage";
import Navbar from "../widgets/Navbar";
import ProtectedRoute from "./ProtectedRoute";

const Router = () => {
  return (
    <BrowserRouter>
      <Navbar />
      <Switch>
        <ProtectedRoute path="/" exact component={Feed} />
        <Route path="/signin" component={SignInPage} exact />
        <Route path="/signup" component={SignInPage} exact />
      </Switch>
    </BrowserRouter>
  );
};

export default Router;
