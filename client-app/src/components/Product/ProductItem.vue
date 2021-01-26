<template>
  <div class="prduct-item">
    <div class="product-title">
      title
    </div>
    <div class="product-short-info">
      <div class="product-img">img</div>
      <div class="short-info">
        short-if
      </div>
    </div>
    <div>
      <router-link to="/"> Подробнее </router-link>
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
  padding: 7px;
}
.product-short-info {
  display: flex;
}
</style>
