<template>
  <div>
    <h1>Hi {{ user.email }}!</h1>
    <p>
      <router-link to="/login">Logout</router-link>
      <button @click="logOut">Logout</button>
    </p>
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
  // created() {
  //   this.$store.dispatch("users/getAll");
  // }
};
</script>
