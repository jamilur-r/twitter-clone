import React from "react";
import { useState } from "react";
import { Bell, Bookmark, Hash, Home, Mail, Twitter, User } from "react-feather";
import { connect, ConnectedProps } from "react-redux";
import { Link, useLocation } from "react-router-dom";
import { AppState } from "../store/Store";
import {
  Container,
  Nav,
  NavItem,
  TweetButton,
  UserWidget,
} from "../styles/Navbar.stc";
import LogoutWidget from "./LogoutWidget";

interface Props extends RXProps {}

const Navbar = ({ user }: Props) => {
  const location = useLocation();
  const [show, setShow] = useState<boolean>(false);

  if (location.pathname === "/signin" || location.pathname === "/signup") {
    return <div></div>;
  } else {
    return (
      <Nav>
        <Container>
          <NavItem>
            <Link to="/">
              <Twitter size={30} color="#fff" />
            </Link>
          </NavItem>
          <NavItem>
            <Link to="/">
              <Home size={30} color="#fff" /> <span>Home</span>
            </Link>
          </NavItem>
          <NavItem>
            <Link to="/">
              <Hash size={30} color="#fff" /> <span>Explore</span>
            </Link>
          </NavItem>
          <NavItem>
            <Link to="/">
              <Bell size={30} color="#fff" /> <span>Notification</span>
            </Link>
          </NavItem>
          <NavItem>
            <Link to="/">
              <Mail size={30} color="#fff" /> <span>Message</span>
            </Link>
          </NavItem>
          <NavItem>
            <Link to="/">
              <Bookmark size={30} color="#fff" /> <span>Bookmark</span>
            </Link>
          </NavItem>
          <NavItem>
            <Link to="/">
              <User size={30} color="#fff" /> <span>Profile</span>
            </Link>
          </NavItem>
          <TweetButton>Tweet</TweetButton>

          <UserWidget onClick={() => setShow(!show)}>
            {user && user.profilePic ? (
              <img
                src={"https://localhost:5001" + user?.profilePic}
                alt={user?.email}
                width="50px"
                height="50px"
                style={{ borderRadius: "100%" }}
              />
            ) : (
              <div className="initial">
                {user && user.firstName[0] + user.lastName[0]}
              </div>
            )}
            <div className="info">
              <p className="name">
                {user && user.firstName} {user && user.lastName}
              </p>
              <p className="username">
                @{user && user.firstName + user.lastName}
              </p>
            </div>
          </UserWidget>
          <LogoutWidget
            setShow={setShow}
            show={show}
            username={user && user.firstName + user.lastName}
          />
        </Container>
      </Nav>
    );
  }
};

const mapState = (state: AppState) => ({
  user: state.auth.user,
});
const connector = connect(mapState);

type RXProps = ConnectedProps<typeof connector>;

export default connector(Navbar);
