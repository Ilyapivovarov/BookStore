<template>
  <div class="orderList">
    <div class="order" v-for="order in orders" :key="order.id">
      {{ order.name }}
    </div>
  </div>
</template>

<script>
import { orderService } from "@/services";

export default {
  name: "OrderList",
  data: () => ({
    orders: ""
  }),
  mounted() {
    orderService.getAll().then(respone => {
      this.orders = respone;
    });
  }
};
</script>
