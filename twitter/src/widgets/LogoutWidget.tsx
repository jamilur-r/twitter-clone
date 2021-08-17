import React from "react";
import { connect, ConnectedProps } from "react-redux";
import { LogoutUser } from "../store/action/AuthAction";
import { LogoutContainer } from "../styles/Navbar.stc";

interface Props extends RXProps {
  show: boolean;
  username: string | undefined;
  setShow: any;
}

const LogoutWidget = ({ logout, show, username, setShow }: Props) => {
  const handleClick = async () => {
    const data = await LogoutUser();
    if (data.status === 200) {
      logout();
      setShow(false);
    }
  };

  return (
    <LogoutContainer
      onClick={handleClick}
      style={{ display: show ? "flex" : "none" }}
    >
      <p>Logout @{username}</p>
    </LogoutContainer>
  );
};

const mapDispatch = {
  logout: () => ({ type: "LOGOUT" }),
};

const connector = connect(null, mapDispatch);

type RXProps = ConnectedProps<typeof connector>;

export default connector(LogoutWidget);
