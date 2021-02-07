<template>
  <div class="basket">
    <div class="basketAny">
      <h1>Корзина товаров</h1>
      <div class="basketWrapper">
        <BasketItem
          v-for="(item, id) in basketList"
          :key="id"
          :item="item"
          :count="id"
        />
        <div class="orderFooter">
          <button
            class="createOrder"
            :disabled="!basketList"
            @click="openPopup()"
          >
            Оформить заказ
          </button>
          <div class="totalPrice">
            <span> Итого: {{ totalPrice }} руб.</span>
          </div>
        </div>
        <Popup
          v-if="showPopup"
          submitBtn="Да"
          closeBtn="Нет"
          @closePopup="closePopup()"
          @submit="createNewOrder()"
        >
          <h2>Вы уверенны что хотите сделать заказ?</h2>
        </Popup>
      </div>
      <div class="basketEmpty" v-if="!basketList">
        Корзина пуста
      </div>
    </div>
  </div>
</template>

<script>
import BasketItem from "../components/Basket/BasketItem";
import Popup from "../components/Popup/PopupWindow";

export default {
  components: {
    BasketItem,
    Popup
  },
  data: () => ({
    error: "",
    totalPrice: 0,
    showPopup: false
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
    },
    openPopup() {
      this.showPopup = true;
    },
    closePopup() {
      this.showPopup = false;
    }
  }
};
</script>

<style scoped>
.basket {
  border-top: none;
  margin-top: 20px;
  padding: 7px;
  position: relative;
}
.basketWrapper {
  border: solid 1px #e7e7e7;
  margin-top: 48px;
  border-radius: 5px;
  padding: 5px;
}
h1 {
  position: absolute;
  top: -5px;
  left: 7px;
  border: solid 1px #e7e7e7;
  display: inline-block;
  border-bottom: solid #fff;
  border-radius: 5px;
  padding: 5px;
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
  margin-top: 50px;
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
.createOrder:disabled {
  display: none;
}
</style>
