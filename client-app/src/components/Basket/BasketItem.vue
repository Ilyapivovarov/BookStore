<template>
  <div class="prduct-item">
    <div class="product-short-info">
      {{ item.product.name }}
      <div class="short-info">
        {{ item.product.descriptoin.substr(0, 100) }}...
      </div>
      <router-link class="link" to="/"> Подробнее </router-link>
    </div>
    <div calss="product-footer">
      <div class="count-btn">
        <button>-</button> {{ item.count }} <button>+</button>
      </div>
      <div class="remove-btn">
        <button @click="removeFromBasket()">Удалить</button>
      </div>
    </div>
  </div>
</template>

<script>
import image from "../../assets/rubbish.png";
export default {
  data() {
    return {
      image
    };
  },
  name: "BasketItem",
  props: {
    item: Object
  },
  methods: {
    removeFromBasket() {
      this.$store.dispatch("basket/removeItem", this.item.product);
    }
  }
};
</script>

<style scoped>
.prduct-item {
  border: solid 1px;
  margin: 5px;
  padding: 10px;
}
.remove-btn {
  text-align: right;
}
.count-btn {
  margin-top: 15px;
}
.product-footer {
  padding-left: 5px;
}
</style>
