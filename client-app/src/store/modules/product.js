import { productService } from "@/services";

const productStore = {
  namespaced: true,
  state: {
    products: [],
    product: {},
    success: false,
    msg: ""
  },
  actions: {
    getAll({ commit }) {
      productService.getAll().then(products => {
        commit("getAll", products);
      });
    },
    get({ commit }, id) {
      productService.get(id).then(product => {
        commit("getProduct", product);
      });
    },
    create({ commit }, product) {
      commit("createProduct", product);
    },
    update({ commit }, product) {
      productService.put(product).then(response => {
        commit("updateProduct", response);
      });
    },
    remove({ commit }, id) {
      productService.remove(id).then(success => {
        commit("removeProduct", success);
      });
    }
  },
  mutations: {
    getAll(state, products) {
      state.products = products;
    },
    getProduct(state, product) {
      state.product = product;
    },
    createProduct(state, product) {
      state.products.push(product);
      productService.post(product);
    },
    updateProduct(state, success) {
      state.success = success;
      if (success) {
        state.msg = "Обновлен";
      } else state.msg = "Не обновлен";
    },
    removeProduct(state, success) {
      state.success = success;
      if (success) {
        state.msg = "Удален";
      } else state.msg = "Не удален";
    }
  },
  getters: {
    getAllProducts: state => {
      return state.products;
    }
  }
};

export default productStore;
