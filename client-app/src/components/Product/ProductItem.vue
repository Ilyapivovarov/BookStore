<template>
  <div class="prduct-item">
    <div class="product-title">
      {{ product.name }}
    </div>
    <div class="product-short-info">
      <div class="short-info">{{ product.descriptoin.substr(0, 100) }}...</div>
    </div>
    <div calss="product-footer">
      <router-link class="link" to="/"> Подробнее </router-link>
      <button class="link">Добавить в корзину</button>
    </div>
  </div>
</template>

<script>
export default {
  name: "ProductItem",
  props: {
    product: Object
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
