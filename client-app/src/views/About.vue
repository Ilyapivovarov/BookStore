<template>
  <div>
    <h1 v-if="user !== null">Hi, {{ user.email }}!</h1>
    <h1 v-else>Не авторизованный пользователь</h1>
  </div>
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
