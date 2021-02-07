<template>
  <div class="basketItem">
    <div class="productTitle">
      {{ count }}.
      <h4>{{ product.name }}</h4>
    </div>
    <div class="productCountInfo">
      <div>
        <span>{{ basketItem.count }} ед.</span>
        <span> {{ product.price * basketItem.count }} р.</span>
      </div>
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
h4 {
  display: inline;
}
span {
  margin-left: 5px;
}
</style>
