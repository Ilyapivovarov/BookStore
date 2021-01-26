import axios from "../plugins/axios/index";
import jwt_decode from "jwt-decode";

export const userService = {
  login,
  logout
};

function login(login) {
  return axios
    .post("api/auth/login", login)
    .then(response => {
      if (response.status === 200) {
        localStorage.setItem(
          "user",
          JSON.stringify(jwt_decode(response.data.access_token))
        );
      }
      return jwt_decode(response.data.access_token);
    })
    .catch(error => {
      console.log(error);
    });
}

function logout() {
  localStorage.removeItem("user");
  return false;
}
