<template>
  <div class="productList">
    <ProductItem
      v-for="(product, id) in products"
      v-bind:key="id"
      v-bind:product="product"
    />
  </div>
</template>

<script>
import ProductItem from "./ProductItem";

export default {
  name: "ProductList",
  components: { ProductItem },
  computed: {
    products() {
      return [
        { id: 1, name: "product1" },
        { id: 1, name: "product2" }
      ];
    }
  }
};
</script>

<style scoped>
.productList {
  widows: 100%;
  border: solid 1px;
}
</style>
