<template>
  <div class="about">
    <h1>auth: {{ auth }}</h1>
    <h3>{{ curUser }}</h3>
    <h3>{{ test }}</h3>
  </div>
</template>

<script>
import { mapGetters } from "vuex";

export default {
  name: "About",

  data: () => ({
    auth: false,
    curUser: Object,
    test: ""
  }),
  methods: {
    ...mapGetters("auth", ["isAuthorized", "getCurUser"])
  },
  mounted() {
    this.curUser = this.getCurUser();
    this.test = localStorage.getItem("token");
  }
};
</script>
