<template>
  <div class="basket">
    <div class="basketAny" v-if="basketList !== null && basketList.length > 0">
      <p class="title">Ваш заказ:</p>
      <BasketItem v-for="(item, id) in basketList" :key="id" :item="item" />
      <div class="orderFooter">
        <button class="createOrder" @click="createNewOrder()">
          Оформить заказ
        </button>
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
    error: "",
    totalPrice: 0
  }),
  computed: {
    basketList() {
      if (this.$store.state.basket.basket !== null) {
        var vm = this;
        vm.totalPrice = 0;
        return this.$store.state.basket.basket.map(item => {
          this.totalPrice = this.totalPrice + item.product.price * item.count;
          return item;
        });
      } else {
        return null;
      }
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
  border-left: solid 1px #e7e7e7;
  border-right: solid 1px #e7e7e7;

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

.createOrder {
  font-size: 23px;
  background: #fff;
  box-shadow: none;
  border: none;
  color: rgb(0, 200, 0);
  border: solid 1px rgb(0, 100, 0);
  border-radius: 2px;
}

.createOrder:hover {
  color: rgb(255, 255, 255);
  background-color: rgb(0, 200, 0);
  border: solid 1px rgb(0, 100, 0);
  transition: 0.3s;
}
</style>
