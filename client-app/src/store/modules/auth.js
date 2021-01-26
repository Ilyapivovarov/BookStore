//import router from "@/router";
import { userService } from "@/services";

//localStorage.setItem("user", JSON.stringify({ name: "test" }));
var a = localStorage.getItem("user");

const user = JSON.parse(a);
const initialState = user
  ? { status: { loggedIn: true }, user }
  : { status: { loggedIn: false }, user: null };

const authStore = {
  namespaced: true,
  state: initialState,
  actions: {
    login(state, login) {
      console.log("auth/login");
      console.log(state);
      console.log(login);
      userService.login(login);
    },
    logout({ commit }) {
      console.log("auth/logout");
      userService.logout();
      commit("logout");
    }
  },
  mutations: {
    loginRequest(state, user) {
      state.status = { loggingIn: true };
      state.user = user;
    },
    loginSuccess(state, user) {
      state.status = { loggedIn: true };
      state.user = user;
    },
    loginFailure(state) {
      state.status = {};
      state.user = null;
    },
    logout(state) {
      state.status = {};
      state.user = null;
    }
  }
};

export default authStore;
