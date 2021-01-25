import axios from "@/plugins/axios";
import jwt_decode from "jwt-decode";

const authStore = {
  namespaced: true,
  state: {
    authorized: false,
    curUser: {
      id: 0,
      firstName: "",
      lastName: "",
      email: "",
      isAdmin: false
    }
  },
  getters: {
    isAuthorized: ({ authorized }) => authorized,
    getCurUser: ({ curUser }) => curUser
  },
  mutations: {
    SAVE_USER_INFO(state, token) {
      console.log("SAVE USER INFO");

      var decoded = jwt_decode(token);
      console.log(decoded);

      axios.get("api/auth/profile/" + token).then(response => {
        let user = response.data;
        state.authorized = true;
        state.curUser.id = user.id;
        state.curUser.firstName = user.firstName;
        state.curUser.lastName = user.lastName;
        state.curUser.email = user.email;
      });

      localStorage.setItem("token", token);
    }
  },
  actions: {
    authUser({ commit }, login) {
      axios
        .post("api/auth/login", login)
        .then(response => {
          console.log(response.data.access_token);
          commit("SAVE_USER_INFO", response.data.access_token);
        })
        .catch(error => {
          console.log(error);
        });
    },

    Logout({ commit }) {
      console.log(commit);
    }
  }
};

export default authStore;
