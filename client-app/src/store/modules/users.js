const usersStore = {
  namespaced: true,
  state: {
    n: 1
  },
  getters: {
    usersList: ({ n }) => n
  },
  mutations: {},
  actions: {}
};

export default usersStore;
