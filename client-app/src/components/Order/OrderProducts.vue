<template>
  <div class="basketItem">
    <div class="productTitle">{{ count }}. {{ product.name }}</div>
    <div class="productCountInfo">
      <div>{{ basketItem.count }} ед.</div>

      <div>{{ product.price * basketItem.count }} р.</div>
    </div>
  </div>
</template>

<script>
import { productService } from "@/services";
export default {
  props: {
    basketItem: Object,
    count: Number
  },
  data: () => ({
    product: Object
  }),

  mounted() {
    productService.get(this.basketItem.productId).then(response => {
      this.product = response;
    });
  }
};
</script>

<style scoped>
.basketItem {
  display: flex;
  justify-content: space-between;
  border-bottom: solid 1px rgb(46, 46, 46);
}
</style>
