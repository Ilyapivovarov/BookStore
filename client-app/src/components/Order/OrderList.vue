<template>
  <div class="orderList">
    <h2>Мои заказы</h2>
    <div>
      <select class="filter" v-model="filters">
        <option>Все заказы</option>
        <option>Только не выполненные заказы</option>
        <option>Только выполненные заказы</option>
      </select>
    </div>
    <div
      class="order"
      v-for="order in orders"
      :key="order.id"
      v-bind:order="order.products"
      :class="selectStyle(order)"
    >
      <div class="orderName">
        {{ order.name }}
      </div>

      <div class="orderInfo">
        Дата завершения заказа
        {{ order.dateOfCompletion.split("T")[0] }}
        <div v-if="order.status === 1">
          Статус: "В процессе"
        </div>
        <div v-else>Статус: "Выполнен"</div>
      </div>

      <div class="orderProducts">
        <OrderProducts
          v-for="(item, id) in order.products"
          :key="id"
          :count="id + 1"
          v-bind:basketItem="item"
        />
      </div>

      <div class="orderFooter">
        <div>Итого: {{ order.totalPrice }}р</div>
      </div>
    </div>
  </div>
</template>

<script>
import { orderService } from "@/services";
import OrderProducts from "./OrderProducts";

export default {
  name: "OrderList",
  components: {
    OrderProducts
  },
  data: () => ({
    orders: Object,
    filters: "Только не выполненные заказы",
    ordersStore: Object
  }),
  watch: {
    filters(value) {
      if (value === "Все заказы") {
        this.orders = this.ordersStore;
      }
      if (value === "Только не выполненные заказы") {
        this.orders = this.ordersStore.filter(order => order.status === 1);
      }
      if (value === "Только выполненные заказы") {
        this.orders = this.ordersStore.filter(order => order.status === 0);
      }
    }
  },
  methods: {
    selectStyle(order) {
      if (order.status === 1) {
        return "orderInprocess";
      } else return "orderCompleted";
    }
  },
  beforeCreate() {
    orderService.getAll().then(response => {
      this.ordersStore = response;
      this.orders = this.ordersStore.filter(order => order.status === 1);
    });
  }
};
</script>

<style scoped>
.order {
  border: solid 1px;
  margin: 10px;
  padding: 5px;
  height: auto;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);
}
.order div {
  margin: 10px;
  padding: 5px;
}
.orderInprocess {
  background-color: rgb(252, 251, 195);
}
.orderCompleted {
  background-color: rgb(208, 252, 195);
}
.orderFooter {
  text-align: right;
}
.filter:hover {
  box-shadow: 0 0 10px rgba(0, 0, 255, 1);
}
</style>
