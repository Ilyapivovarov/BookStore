<template>
  <div class="order">
    <OrderList v-if="this.$store.state.auth.status.loggedIn" />
    <div v-else>
      <h2>Вы не авторизованы</h2>
    </div>
  </div>
</template>

<script>
import OrderList from "../components/Order/OrderList";

export default {
  name: "MyOrders",
  components: { OrderList }
};
</script>
