import { userService } from "@/services";
import router from "@/router";

var user = JSON.parse(localStorage.getItem("user"));

if (user) {
  var exp = new Date(0);
  exp.setUTCSeconds(user.exp);

  var now = new Date();

  if (exp < now) {
    userService.logout();
    user = null;
  }
}

const initialState = user
  ? { status: { loggedIn: true }, user }
  : { status: { loggedIn: false }, user: null };

const authStore = {
  namespaced: true,
  state: initialState,
  actions: {
    login({ commit }, login) {
      return userService.login(login).then(user => {
        if (user) {
          commit("login", user);
          return true;
        } else {
          return false;
        }
      });
    },
    logout({ commit }) {
      userService.logout();
      commit("logout");
    }
  },
  mutations: {
    login(state, user) {
      state.status = { loggedIn: true };
      state.user = user;
      router.push("/");
      //location.href = "/";
    },
    logout(state) {
      state.status = { loggedIn: false };
      state.user = null;

      //location.href = "/";
    },
    loginFailed(state) {
      state.status = { loggedIn: false };
    }
  }
};

export default authStore;
