<template>
  <span>
    <router-link v-if="user === null" to="/login"> Вход </router-link>

    <div class="user-info-wrapper" v-else>
      {{ user.family_name }}
      <button @click="logOut()">Выход</button>
    </div>
  </span>
</template>

<script>
export default {
  computed: {
    user() {
      return this.$store.state.auth.user;
    }
  },
  methods: {
    logOut() {
      const { dispatch } = this.$store;
      dispatch("auth/logout");
    }
  }
};
</script>

<style scoped>
span {
  float: right;
}

.user-info-wrapper {
  display: inline;
}
button {
  background: none !important;
  border: none;
  padding: 0 !important;
  /*optional*/
  font-family: arial, sans-serif;
  /*input has OS specific font-family*/
  color: #069;
  text-decoration: underline;
  cursor: pointer;
}
</style>
