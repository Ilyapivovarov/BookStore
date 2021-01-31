<template>
  <div class="prduct-item">
    <div class="product-title">
      {{ product.name }}
    </div>
    <div class="product-short-info">
      <div class="short-info">
        Описание: <br />
        {{ product.descriptoin.substr(0, 100) }}...
      </div>
      <div class="count">Колличество: {{ product.count }}</div>
    </div>
    <div calss="product-footer">
      <router-link class="link" to="/"> Подробнее </router-link>
      <button class="link" @click="addToBasket()">
        Добавить в корзину
      </button>
    </div>
  </div>
</template>

<script>
export default {
  name: "ProductItem",
  props: {
    product: Object
  },
  methods: {
    addToBasket() {
      this.$store.dispatch("basket/addItem", this.product);
    },
    removeFromBasket() {
      this.$store.dispatch("basket/removeItem", this.product);
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
button {
  display: block;
  float: right;
}
.product-short-info div {
  margin: 7px;
}
</style>
