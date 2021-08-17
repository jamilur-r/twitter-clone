import React from "react";
import { connect } from "react-redux";
import { Route, Redirect } from "react-router-dom";
import { AppState } from "../store/Store";

const ProtectedRoute = ({ component, auth, ...rest }: any) => {
  const routeComponent = (props: any) =>
    auth ? (
      React.createElement(component, props)
    ) : (
      <Redirect to={{ pathname: "/signin" }} />
    );
  return <Route {...rest} render={routeComponent} />;
};

const mapState = (state: AppState) => ({
  auth: state.auth.isAuth,
});

const connetor = connect(mapState);
export default connetor(ProtectedRoute);
