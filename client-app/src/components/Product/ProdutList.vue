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
      return this.$store.state.product.products;
    }
  },

  mounted() {
    this.$store.dispatch("product/getAll");
  }
};
</script>

<style scoped>
.productList {
  widows: 100%;
  margin-top: 5px;
  padding: 2px;
}
.toolbar {
  text-align: right;
}
</style>
