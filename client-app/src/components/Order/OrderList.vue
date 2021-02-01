<template>
  <div class="orderList">
    <h2>Мои заказы</h2>
    <div
      class="order"
      v-for="order in orders"
      :key="order.id"
      v-bind:order="order"
    >
      <div class="orderName">
        {{ order.name }}
      </div>
      <div>
        Дата завершения заказа
        {{ order.dateOfCompletion.split("T")[0] }}
        <span v-if="order.status === 1">
          Статус: "В процессе"
        </span>
        <span v-else> Статус: "Выполнен"</span>
      </div>
      <div class="orderProducts">
        <table>
          <thead>
            <tr>
              <td>
                Название
              </td>
              <td>
                Количество
              </td>
            </tr>
          </thead>
          <OrderProducts
            v-for="item in order.products"
            :key="item.id"
            v-bind:basketItem="item"
          />
        </table>
      </div>

      <div>Итого: {{ order.totalPrice }}р</div>
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
    orders: Object
  }),
  mounted() {
    orderService.getAll().then(respone => {
      this.orders = respone;
    });
  }
};
</script>

<style scoped>
.order {
  border: solid 1px;
  margin: 10px;
  padding: 5px;
}
.order div {
  margin: 10px;
  padding: 5px;
}
table {
  width: 100%;
}
</style>
