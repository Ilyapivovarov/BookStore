<template>
  <span id="auth">
    <router-link class="navLink" v-if="user === null" to="/login">
      Вход
    </router-link>

    <div class="user-info-wrapper" v-else>
      <p>{{ user.fullName }}</p>

      <router-link v-if="user.role === 'Admin'" class="navLink" to="/admin"
        >Администрирование</router-link
      >
      <button class="logout" @click="logOut()">Выход</button>
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
      this.$store.dispatch("auth/logout");
    }
  }
};
</script>

<style scoped>
p {
  display: inline;
  margin-right: 5px;
}
.user-info-wrapper {
  display: inline;
  float: right;
}
.logout {
  margin-left: 5px;
}
#auth {
  float: right;
}
.logout {
  background: blue;
  box-shadow: none;
  border: none;
  color: #ffffff;
}

.logout:hover {
  text-decoration: underline;
}
</style>
