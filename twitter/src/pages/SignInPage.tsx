import React from "react";
import { useState } from "react";
import {
  Form,
  FormSection,
  PageContainer,
  SectionHeader,
} from "../styles/SignIn.stc";

interface Identity {
  email: string;
  password: string;
}
const SignInPage = () => {
  const [identity, setIdentity] = useState<Identity>({
    email: "",
    password: "",
  });
  const [isPass, setIsPass] = useState<boolean>(true);

  const handleChange = (e: any) =>
    setIdentity({ ...identity, [e.target.name]: e.target.value });
  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
  };
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
          <div>
            <input
              required
              type={isPass ? "password" : "text"}
              name="password"
              value={identity.password}
              onChange={(e) => handleChange(e)}
            />
            <button></button>
          </div>
          <input type="submit" value="SIGNIN" />
        </Form>
      </FormSection>
    </PageContainer>
  );
};

export default SignInPage;
