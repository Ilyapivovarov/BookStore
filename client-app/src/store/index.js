import Vue from "vue";
import Vuex from "vuex";
import users from "./modules/users";
import products from "./modules/products";
import auth from "./modules/auth";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {},
  mutations: {},
  actions: {},
  modules: {
    users,
    products,
    auth
  }
});
