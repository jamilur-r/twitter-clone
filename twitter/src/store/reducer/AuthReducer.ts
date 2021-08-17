import { Auth, AuthAction, User } from "../../types/Auth";

const initSate: Auth = {
  isAuth: false,
  user: undefined,
  users: new Array<User>(),
  otherUser: undefined,
};

export const authReducer = (state = initSate, action: AuthAction): Auth => {
  switch (action.type) {
    case "SIGNIN":
      return {
        ...state,
        isAuth: true,
        user: action.payload,
      };
    case "SIGNUP":
      return {
        ...state,
        isAuth: true,
        user: action.payload,
      };
    case "LOGOUT":
      return {
        ...state,
        users: new Array<User>(),
        user: undefined,
        isAuth: false,
      };
    case "GETUSER":
      return {
        ...state,
        otherUser: action.payload,
      };
    case "GETUSERS":
      return {
        ...state,
        users: [...state.users, ...action.payload],
      };
    default:
      return state;
  }
};
