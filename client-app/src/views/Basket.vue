<template>
  <div class="basket">
    <div class="basketAny" v-if="basketList !== null && basketList.length > 0">
      <p class="title">Ваш заказ:</p>
      <BasketItem v-for="(item, id) in basketList" :key="id" :item="item" />
      <div class="orderFooter">
        <button @click="createNewOrder()">Оформить заказ</button>
        <span class="totalPrice"> Итого: {{ totalPrice }} р</span>
        <span class="error">{{ error }}</span>
      </div>
    </div>

    <div class="basketEmpty" v-else>
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
  data: () => ({
    error: ""
  }),
  computed: {
    basketList() {
      if (this.$store.state.basket.basket !== null) {
        return this.$store.state.basket.basket.map(item => {
          this.totalPrice = this.totalPrice + item.product.price * item.count;
          return item;
        });
      } else {
        return null;
      }
    },
    totalPrice() {
      var a = 0;
      this.$store.state.basket.basket.map(item => {
        a = a + item.product.price * item.count;
      });
      return a;
    }
  },
  methods: {
    createNewOrder() {
      if (this.basketList !== null && this.basketList.length > 0) {
        this.$store.dispatch("basket/createOrder");
      } else {
        this.error = "Корзина ничего нет";
      }
    }
  }
};
</script>

<style scoped>
.basket {
  border: solid 1px #e7e7e7;
  margin-top: 20px;
}
.basketAny {
  margin-top: 20px;
  margin-left: 5px;
}
.title {
  font-size: 25px;
}
.totalPrice {
  float: right;
  font-size: 24px;
}
.orderFooter {
  margin-top: 20px;
  margin-left: 5px;
}
.basketEmpty {
  text-align: center;
  font-size: 25px;
  color: gray;
}
</style>
