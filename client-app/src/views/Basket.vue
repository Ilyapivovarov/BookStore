<template>
  <div class="basket">
    <div v-if="basketList !== null">
      <BasketItem v-for="(item, id) in basketList" :key="id" :item="item" />
      <button @click="createNewOrder()">Оформить заказ</button>
      <span class="totalPrice"> Итого: {{ totalPrice }} р</span>
    </div>

    <div v-else>
      Корзина пуста
    </div>
  </div>
</template>

<script>
import BasketItem from "../components/Basket/BasketItem";
export default {
  components: {
    BasketItem
  },
  computed: {
    basketList() {
      return this.$store.state.basket.basket.map(item => {
        return item;
      });
    },
    totalPrice() {
      var totalPrice = 0;

      this.$store.state.basket.basket.map(item => {
        totalPrice = totalPrice + item.product.price * item.count;
      });

      return totalPrice;
    }
  },
  methods: {
    createNewOrder() {}
  }
};
</script>

<style scoped>
button {
  margin-left: 5px;
}
.totalPrice {
  float: right;
  font-size: 24px;
}
</style>
