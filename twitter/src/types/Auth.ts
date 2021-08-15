export interface Auth {
  isAuth: boolean;
}

const SIGNIN = "SIGNIN";
const SIGNUP = "SIGNUP";
const LOGOUT = "LOGOUT";
const GETUSER = "GETUSER";

interface SigninAction {
  type: typeof SIGNIN;
}

interface SignupAction {
  type: typeof SIGNUP;
}

interface LogoutAction {
  type: typeof LOGOUT;
}

interface GetUserAction {
  type: typeof GETUSER;
}

export type AuthAction =
  | SigninAction
  | SignupAction
  | LogoutAction
  | GetUserAction;
