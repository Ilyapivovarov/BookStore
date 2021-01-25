<template>
  <div id="app">
    <div id="nav">
      <router-link to="/">Home</router-link> |
      <router-link to="/about">About</router-link> |
      <router-link v-if="authorized" to="/login">Вход</router-link>
      <button @click="logout" v-else>Выход</button>
    </div>
    <router-view />
  </div>
</template>

<script>
import { mapGetters } from "vuex";
import { mapActions } from "vuex";

export default {
  name: "App",
  data: () => ({
    authorized: false
  }),

  methods: {
    ...mapGetters("auth", ["IsAuthorized"]),
    ...mapActions("auth", ["Logout"]),
    logout() {
      console.log(this.authorized);
      this.Logout();
    }
  },
  mounted() {
    this.authorized = this.IsAuthorized;
  }
};
</script>
