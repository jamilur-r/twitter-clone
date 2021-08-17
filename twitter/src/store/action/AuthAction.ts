import axios from "axios";
import { User } from "../../types/Auth";

export const SignIn = async (
  email: string,
  password: string
): Promise<User | undefined> => {
  try {
    const url = "https://localhost:5001/auth/signin";
    const data = await axios.post(url, {
      email: email,
      password: password,
    });
    return {
      firstName: data.data.firstName,
      lastName: data.data.lastName,
      profilePic: data.data.profilePic,
      profileBanner: data.data.profileBanner,
      email: data.data.email,
      id: data.data.id,
      userName: data.data.userName,
    };
  } catch (error) {
    console.log(error);
    return undefined;
  }
};

export const LogoutUser = async () => {
  const url: string = "https://localhost:5001/auth/logout";
  const data = await axios.post(url);
  return data;
};
