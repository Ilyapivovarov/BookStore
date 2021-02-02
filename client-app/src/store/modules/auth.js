import { userService } from "@/services";

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
        location.href = "/";
      });
    },
    logout({ commit }) {
      userService.logout();
      commit("logout");
      location.href = "/";
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
