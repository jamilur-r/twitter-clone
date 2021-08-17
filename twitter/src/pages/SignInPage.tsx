import React from "react";
import { useState } from "react";
import { Eye, EyeOff } from "react-feather";
import { connect, ConnectedProps } from "react-redux";
import { Link, Redirect } from "react-router-dom";
import { SignIn } from "../store/action/AuthAction";
import { AppState } from "../store/Store";
import {
  Form,
  FormSection,
  PageContainer,
  SectionHeader,
} from "../styles/SignIn.stc";
import { User } from "../types/Auth";

interface Identity {
  email: string;
  password: string;
}

interface Props extends RXProps {}

const SignInPage = ({ auth, dispatchSignin }: Props) => {
  const [identity, setIdentity] = useState<Identity>({
    email: "",
    password: "",
  });

  const [isPass, setIsPass] = useState<boolean>(true);

  const handleChange = (e: any) =>
    setIdentity({ ...identity, [e.target.name]: e.target.value });

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    const data = await SignIn(identity.email, identity.password);
    if (data !== undefined) {
      dispatchSignin(data);
    }
  };

  if (auth === true) {
    return <Redirect to="/" />;
  }

  return (
    <PageContainer>
      <SectionHeader>
        <h1>Twitter Clone</h1>
        <h2>Sign In</h2>
      </SectionHeader>
      <FormSection>
        <Form onSubmit={(e) => handleSubmit(e)}>
          <input
            required
            type="email"
            name="email"
            value={identity.email}
            onChange={(e) => handleChange(e)}
          />
          <div className="password">
            <input
              required
              type={isPass ? "password" : "text"}
              name="password"
              value={identity.password}
              onChange={(e) => handleChange(e)}
            />
            <button
              onClick={(e) => {
                e.preventDefault();
                setIsPass(!isPass);
              }}
            >
              {isPass ? (
                <EyeOff size={20} color="#272739" />
              ) : (
                <Eye size={20} color="#272739" />
              )}
            </button>
          </div>
          <input type="submit" value="SIGN IN" />
          <p
            style={{
              fontSize: 14,
              color: "white",
            }}
          >
            Not a member?{" "}
            <Link to="/signup" style={{ color: "#1DA1F2" }}>
              Create an account
            </Link>
          </p>
        </Form>
      </FormSection>
    </PageContainer>
  );
};

const mapState = (state: AppState) => ({
  auth: state.auth.isAuth,
});

const mapDispatch = {
  dispatchSignin: (data: User) => ({
    type: "SIGNIN",
    payload: data,
  }),
};

const connector = connect(mapState, mapDispatch);

type RXProps = ConnectedProps<typeof connector>;

export default connector(SignInPage);
