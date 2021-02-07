import Vue from "vue";
import Vuex from "vuex";
import auth from "./modules/auth";
import basket from "./modules/basket";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {},
  mutations: {},
  actions: {},
  modules: {
    auth,
    basket
  }
});
