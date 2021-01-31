<template>
  <div class="home">
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

<style scoped>
.home {
  height: 100%;
}
</style>
