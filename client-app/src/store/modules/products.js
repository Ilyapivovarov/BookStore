import axios from "@/plugins/axios";

const produtsStore = {
  namespaced: true,
  state: {},
  getters: {},
  mutations: {},
  actions: {
    fetchProduct() {
      axios.get("api/product/", {}).then(function(response) {
        console.log(response.data);
      });
    }
  }
};

export default produtsStore;
