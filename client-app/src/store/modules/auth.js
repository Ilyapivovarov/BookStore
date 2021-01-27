import { userService } from "@/services";
import router from "@/router";

const user = JSON.parse(localStorage.getItem("user"));
const initialState = user
  ? { status: { loggedIn: true }, user }
  : { status: { loggedIn: false }, user: null };

const authStore = {
  namespaced: true,
  state: initialState,
  actions: {
    login({ commit }, login) {
      userService.login(login).then(user => {
        commit("loginSuccess", user);
        router.push("/about");
      });
    },
    logout({ commit }) {
      userService.logout();
      commit("logout");
      router.push("/");
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
      state.status = { loggedIn: false };
      state.user = null;
    },
    logout(state) {
      state.status = { loggedIn: false };
      state.user = null;
    }
  }
};

export default authStore;
