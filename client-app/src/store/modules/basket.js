import { orderService } from "@/services";
import router from "@/router";

const stateInit = JSON.parse(localStorage.getItem("basket"));
const basketStore = {
  namespaced: true,
  state: {
    basket: stateInit
  },
  actions: {
    addItem({ commit }, product) {
      commit("addItem", product);
    },
    removeItem({ commit }, product) {
      commit("removeItem", product);
    },
    addElem({ commit }, item) {
      commit("addElem", item);
    },
    removeElem({ commit }, item) {
      commit("removeElem", item);
    },
    createOrder({ commit }) {
      commit("createOrder");
    }
  },
  mutations: {
    addItem(state, product) {
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
    removeItem(state, product) {
      state.basket = state.basket.filter(
        item => item.product.id !== product.id
      );
      localStorage.setItem("basket", JSON.stringify(state.basket));
    },
    addElem(state, item) {
      let result = state.basket.filter(
        stateItem => stateItem.product.id === item.product.id
      );
      result.map(item => {
        state.item = item.count;
      });
    },
    removeElem(state, item) {
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
      state.basket = [];
      router.push("/");
    }
  }
};

export default basketStore;
