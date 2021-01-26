import axios from "../plugins/axios/index";
import jwt_decode from "jwt-decode";

export const userService = {
  login,
  logout
};

function login(login) {
  console.log(login);
  axios
    .post("api/auth/login", {
      email: "admin@mail.com",
      password: "admin@mail.com"
    })
    .then(response => {
      console.log(jwt_decode(response.data.access_token));
      if (response.status === 200) {
        localStorage.setItem(
          "user",
          JSON.stringify(jwt_decode(response.data.access_token))
        );
      }
      console.log(response);
    })
    .catch(error => {
      console.log(error);
    });
}

function logout() {
  // remove user from local storage to log user out
  localStorage.removeItem("user");
}
