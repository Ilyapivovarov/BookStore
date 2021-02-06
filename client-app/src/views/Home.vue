<template>
  <div class="home">
    <div></div>
    <ProductList />
  </div>
</template>

<script>
import ProductList from "../components/Product/ProdutList";

export default {
  name: "Home",
  components: { ProductList },
  mounted() {},
  computed: {}
};
</script>

<style scoped></style>
