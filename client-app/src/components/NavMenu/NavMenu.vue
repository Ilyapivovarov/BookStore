<template>
  <nav>
    <router-link to="/"> Главная страница </router-link> |
    <router-link to="/my-orders"> Мои заказы </router-link> |
    <router-link to="/about"> About </router-link> |
    <router-link to="/basket"> Корзина ({{ count }}) </router-link>
    <Auth />
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
