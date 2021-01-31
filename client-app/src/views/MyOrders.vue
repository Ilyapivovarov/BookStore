<template>
  <div class="order">
    <OrderList />
  </div>
</template>

<script>
import OrderList from "../components/Order/OrderList";

export default {
  name: "MyOrders",
  components: { OrderList }
};
</script>
