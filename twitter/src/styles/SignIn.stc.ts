import styled from "styled-components";

export const PageContainer = styled.section`
  width: 100%;
  height: 100vh;
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: center;
  background-color: #272739;

  @media (max-width: 768px) {
    flex-direction: column;
  }
`;

export const SectionHeader = styled.div`
  width: 50%;
  height: 100%;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  color: white;
  h1,
  h2 {
    margin: 20px 0;
    text-transform: uppercase;
  }
  @media (max-width: 768px) {
    width: 100%;
  }
`;

export const FormSection = styled.div`
  width: 50%;
  height: 100%;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  color: white;
  @media (max-width: 768px) {
    width: 100%;
  }
`;

export const Form = styled.form`
  width: 320px;
  input{
    width: 100%;
    box-sizing: border-box;
    padding: 10px 15px;
    margin: 10px 0;
    font-family: "Poppins", sans-serif;
    font-size: 16px;
    font-weight: 700;
  }
  input[type=submit]{
    background-color: #1DA1F2;
    border: none;
    color: white;
  }
  .password{
    width: 100%;
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: center;
    input{
      width: 80%;
    }
    button{
      background-color: white;
      border: none;
      padding: 11px;
      width: 20%;
    }
  }
`;
