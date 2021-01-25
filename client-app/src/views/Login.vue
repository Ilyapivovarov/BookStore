<template>
  <div id="login">
    <form @submit.prevent="handleSubmit">
      <div class="form-group">
        <label for="email">Username</label>
        <input type="text" v-model="email" name="email" class="form-control" />
      </div>
      <div class="form-group">
        <label htmlFor="password">Password</label>
        <input
          type="password"
          v-model="password"
          name="password"
          class="form-control"
        />
      </div>
      <div class="form-group">
        <button class="btn btn-primary" @click="loginTest">Login</button>
      </div>
    </form>
  </div>
</template>

<script>
import { mapActions } from "vuex";
import axios from "@/plugins/axios";

localStorage.setItem("token", "sdasd");
console.log(localStorage.getItem("token"));

export default {
  name: "Login",
  data: () => ({
    email: "",
    password: "",
    error: ""
  }),
  methods: {
    ...mapActions("auth", ["authUser"]),
    handleSubmit() {},

    loginTest() {
      this.authUser({
        email: this.email,
        password: this.password
      });
    },

    loggingIn() {
      axios
        .post("api/auth/login", {
          email: this.email,
          password: this.password
        })
        .then(response => {
          console.log(response);
          localStorage.setItem("token", response.data.access_token);
          this.authUser();
        })
        .catch(function(error) {
          console.log(error);
        });
    }
  }
};
</script>

<style scoped>
#login {
  width: 100%;
}
.login-form {
  width: 400px;
}
.login-form * {
  display: grid;
  width: 100%;
}
button {
  margin-top: 5px;
}
</style>
