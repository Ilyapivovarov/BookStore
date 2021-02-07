import { orderService } from "@/services";
import router from "@/router";

const stateInit = JSON.parse(localStorage.getItem("basket"));
const basketStore = {
  namespaced: true,
  state: {
    basket: stateInit
  },
  actions: {
    addBook({ commit }, product) {
      commit("addBook", product);
    },
    removeBook({ commit }, product) {
      commit("removeBook", product);
    },
    addBookItem({ commit }, item) {
      commit("addBookItem", item);
    },
    removeBookItem({ commit }, item) {
      commit("removeBookItem", item);
    },
    createOrder({ commit }) {
      commit("createOrder");
    }
  },
  mutations: {
    addBook(state, product) {
      if (state.basket !== null) {
        let result = state.basket.filter(
          item => item.product.id === product.id
        );
        if (result.length > 0) {
          result.map(item => {
            item.count++;
          });
        } else if (result.length === 0) {
          state.basket.push({ product, count: 1 });
        }
      } else {
        state.basket = [{ product, count: 1 }];
      }
      localStorage.setItem("basket", JSON.stringify(state.basket));
    },
    removeBook(state, product) {
      state.basket = state.basket.filter(
        item => item.product.id !== product.id
      );
      if (state.basket.length === 0) {
        localStorage.removeItem("basket");
        state.basket = null;
      } else localStorage.setItem("basket", JSON.stringify(state.basket));
    },
    addBookItem(state, item) {
      let result = state.basket.filter(
        stateItem => stateItem.product.id === item.product.id
      );
      result.map(item => {
        state.item = item.count;
      });
    },
    removeBookItem(state, item) {
      let result = state.basket.filter(
        stateItem => stateItem.product.id === item.product.id
      );
      result.map(item => {
        state.item = item.count;
      });
    },
    createOrder(state) {
      var products = [];
      state.basket.forEach(element => {
        products.push({ count: element.count, productId: element.product.id });
      });
      orderService.post(products);
      state.basket = null;
      router.push("/");
    }
  }
};

export default basketStore;
