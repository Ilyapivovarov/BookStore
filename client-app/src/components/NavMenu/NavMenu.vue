<template>
  <nav>
    <router-link to="/"> Главная страница </router-link> |
    <router-link to="/my-orders"> Мои заказы </router-link> |
    <router-link to="/about"> About </router-link> |
    <Auth />
  </nav>
</template>

<script>
import Auth from "./Auth";

export default {
  components: {
    Auth
  }
};
</script>
