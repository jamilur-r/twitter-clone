import styled from "styled-components";

export const Nav = styled.nav`
  position: fixed;
  top: 0;
  left: 0;
  width: 25%;
  height: 100vh;
  background-color: #000;

  display: flex;
  flex-direction: row;
  align-items: flex-start;
  justify-content: flex-end;

  @media (max-width: 768px) {
    width: 10%;
    align-items: flex-start;
    justify-content: flex-end;
  }
  @media (max-width: 430px) {
    display: none;
  }
`;

export const Container = styled.div`
  width: 80%;
  height: 100%;
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  justify-content: space-around;
  @media (max-width: 768px) {
    width: 100%;
    align-items: center;
  }
`;

export const NavItem = styled.div`
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: center;

  a {
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: center;
    color: white;
  }
  padding: 15px;
  border-radius: 50px;
  &:hover {
    background-color: #222;
  }
  span {
    margin-left: 20px;
    font-size: 20px;
    font-weight: bold;
  }
  @media (max-width: 768px) {
    span {
      display: none;
    }
  }
`;

export const TweetButton = styled.button`
  background-color: #1da1f2;
  color: white;
  border: none;
  box-shadow: none;
  border-radius: 50px;
  padding: 15px;
  font-weight: bold;
  font-size: 20px;
  width: 80%;

  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: center;

  @media (max-width: 768px) {
    display: none;
  }
`;

export const UserWidget = styled.div`
  width: 80%;
  padding: 5px;
  border-radius: 50px;
  margin-top: 20px;

  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: flex-start;
  cursor: pointer;
  .initial {
    width: 50px;
    height: 50px;
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: center;
    background-color: #272739;
    color: #fff;
    border-radius: 100%;
  }

  .info {
    display: flex;
    flex-direction: column;
    align-items: flex-start;
    justify-content: flex-start;
    margin-left: 10px;
    .name {
      color: #fff;
      font-size: 15px;
      font-weight: 600;
      margin: 0;
      text-transform: capitalize;
    }
    .username {
      color: #fff;
      font-size: 12px;
      font-weight: 200;
      margin: 0;
    }
    @media (max-width: 1024px) {
      display: none;
    }
  }
  &:hover {
    background-color: #222;
  }
  @media (max-width: 768px) {
    justify-content: center;
  }
`;

export const LogoutContainer = styled.div`
  cursor: pointer;
  position: absolute;
  bottom: 100px;
  width: 260px;
  height: 80px;
  border-radius: 10px;
  background-color: #272739;

  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: center;

  p {
    font-size: 14px;
    font-weight: 400;
    color: white;
    padding: 0;
    margin: 0;
  }
  @media (max-width: 430px) {
    display: none;
  }
`;
