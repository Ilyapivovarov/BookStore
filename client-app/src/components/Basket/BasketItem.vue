<template>
  <div class="prduct-item">
    <div class="product-title">
      {{ item.product.name }}
    </div>
    <div class="product-short-info">
      <div class="short-info">
        {{ item.product.descriptoin.substr(0, 100) }}...
      </div>
    </div>
    <div calss="product-footer">
      <router-link class="link" to="/"> Подробнее </router-link>
      <span>{{ item.count }}</span>
      <button @click="removeFromBasket()">Удалить</button>
    </div>
  </div>
</template>

<script>
export default {
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
button {
  display: block;
  float: right;
}
</style>
