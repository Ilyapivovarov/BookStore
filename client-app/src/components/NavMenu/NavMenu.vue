<template>
  <nav>
    <router-link class="navLink" to="/"> Главная страница </router-link> |
    <router-link class="navLink" to="/my-orders"> Мои заказы </router-link> |
    <router-link class="navLink" to="/about"> About </router-link> |
    <router-link class="navLink" to="/basket">
      Корзина ({{ count }})
    </router-link>
    <Auth class="navLink" />
  </nav>
</template>

<script>
import Auth from "./Auth";

export default {
  components: {
    Auth
  },
  computed: {
    count() {
      if (this.$store.state.basket.basket === null) {
        return 0;
      } else return this.$store.state.basket.basket.length;
    }
  }
};
</script>

<style>
nav {
  padding: 1px 2px;
  background: blue;
  min-height: 41px;
}
.navLink {
  font-family: "Gill Sans", "Gill Sans MT", Calibri, "Trebuchet MS", sans-serif;
  font-size: 22px;
  text-decoration: none;
  color: white;
}

.navLink:hover {
  text-decoration: underline;
}
</style>
