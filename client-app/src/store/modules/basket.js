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
    }
  },
  mutations: {
    addItem(state, product) {
      if (state.basket !== null) {
        let result = state.basket.filter(
          item => item.product.id === product.id
        );
        if (result.length > 0) {
          result.map(a => {
            a.count++;
          });
        } else if (result.length === 0) {
          state.basket.push({ product: product, count: 1 });
        }
      } else {
        state.basket = [{ product, count: 1 }];
      }
      localStorage.setItem("basket", JSON.stringify(state.basket));
    },
    removeItem(state, product) {
      state.basket = state.basket.filter(item => item.product !== product);
      localStorage.setItem("basket", JSON.stringify(state.basket));
    }
  }
};

export default basketStore;
