import jwtDecode from "jwt-decode";
import axios from "../plugins/axios/index";

export const userService = {
  login,
  logout
};

function login(login) {
  return axios
    .post("api/auth/login", login)
    .then(response => {
      var user = jwtDecode(response.data.access_token);
      if (response.status === 200) {
        localStorage.setItem("user", JSON.stringify(user));
        localStorage.setItem("token", response.data.access_token);
      }
      return user;
    })
    .catch(() => {
      localStorage.removeItem("user");
    });
}

function logout() {
  localStorage.removeItem("user");
  localStorage.removeItem("token");
  return false;
}
