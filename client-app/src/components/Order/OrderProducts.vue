<template>
  <tr>
    <td>{{ product.name }}</td>
    <td>{{ basketItem.count }}</td>
  </tr>
</template>

<script>
import { productService } from "@/services";
export default {
  props: {
    basketItem: Object
  },
  data: () => ({
    product: Object
  }),

  beforeCreate() {
    productService.get(this.basketItem.productId).then(response => {
      this.product = response;
    });
  }
};
</script>
