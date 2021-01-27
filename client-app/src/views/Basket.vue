<template>
  <div class="basket">
    <div v-if="basketList !== null">
      <BasketItem v-for="(item, id) in basketList" :key="id" :item="item" />
      <button @click="createNewOrder()">Оформить заказ</button>
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
    }
  },
  methods: {
    createNewOrder() {
      console.log("newOrder");
    }
  }
};
</script>

<style scoped>
button {
  margin-left: 5px;
}
</style>
