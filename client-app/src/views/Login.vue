<template>
  <div>
    <h1>Вход</h1>
    <form class="loginForm" @submit.prevent="submit">
      <div class="form-group">
        <label for="email">Email</label>
        <input type="text" v-model="email" name="email" />
        <div v-show="submitted && !email" class="erros">
          Введите Email
        </div>
      </div>
      <div class="form-group">
        <label htmlFor="password">Пароль</label>
        <input type="password" v-model="password" name="password" />
        <div v-show="submitted && !password" class="erros">
          Введите пароль
        </div>
        <div v-show="submitted && loginError" class="erros">
          {{ loginError }}
        </div>
      </div>
      <div class="form-group">
        <button :disabled="loggingIn">Вход</button>
      </div>
    </form>
  </div>
</template>

<script>
import router from "@/router";

export default {
  data: () => ({
    email: "",
    password: "",
    submitted: false,
    loginError: ""
  }),
  computed: {
    loggingIn() {
      return this.$store.state.auth.status.loggedIn;
    }
  },
  created() {
    if (this.$store.state.auth.status.loggedIn) {
      router.push("/");
    }
  },
  methods: {
    submit() {
      this.submitted = true;
      if (this.email && this.password) {
        this.$store.dispatch("auth/login", {
          email: this.email,
          password: this.password
        });
        if (!this.$store.state.auth.status.loggedIn) {
          this.loginError = "Пользователь не найден";
        }
      }
    }
  }
};
</script>

<style scoped>
.loginForm {
  width: 400px;
}
.loginForm * {
  display: grid;
  margin: 3px;
  width: 100%;
}
button {
  margin-top: 5px;
  background-color: rgb(0, 0, 255);
  color: #ffffff;
  border: none;
  height: 30px;
  padding-top: 3px;
}
button:hover {
  background-color: rgb(0, 57, 255);
}
.erros {
  color: red;
}
</style>
