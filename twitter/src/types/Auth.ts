import { Tweet } from "./Tweet";

export interface Follower {
  id: string;
  uid: string;
  followerid: string;
}

export interface Following {
  id: string;
  uid: string;
  followingid: string;
}

export interface User {
  firstName: string;
  lastName: string;
  profilePic: string;
  profileBanner: string;
  tweets?: Tweet[];
  followeings?: Following[];
  followers?: Follower[];
  id: string;
  userName: string;
  email: string;
}
export interface Auth {
  isAuth: boolean;
  user?: User;
  users: User[];
  otherUser?: User;
}

const SIGNIN = "SIGNIN";
const SIGNUP = "SIGNUP";
const LOGOUT = "LOGOUT";
const GETUSER = "GETUSER";
const GETUSERS = "GETUSERS";

interface SigninAction {
  type: typeof SIGNIN;
  payload: User;
}

interface SignupAction {
  type: typeof SIGNUP;
  payload: User;
}

interface LogoutAction {
  type: typeof LOGOUT;
}

interface GetUserAction {
  type: typeof GETUSER;
  payload: User;
}

interface GetUsersAction {
  type: typeof GETUSERS;
  payload: [User];
}

export type AuthAction =
  | SigninAction
  | SignupAction
  | LogoutAction
  | GetUsersAction
  | GetUserAction;
