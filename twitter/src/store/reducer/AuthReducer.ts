import { Auth, AuthAction } from "../../types/Auth";

const initSate: Auth = {
  isAuth: false,
};

export const authReducer = (state = initSate, action: AuthAction): Auth => {
  switch (action.type) {
    case "SIGNIN":
      return state;

    default:
      return state;
  }
};
