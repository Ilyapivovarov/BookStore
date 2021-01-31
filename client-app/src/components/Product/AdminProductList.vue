<template>
  <div>
    <div>
      <button class="add">Добавить</button>
    </div>
    <div v-for="(product, id) in products" v-bind:key="id" class="prduct-item">
      <div class="toolbar">
        <button class="edit">Редактировать</button>
        <button class="remove">Удалить</button>
      </div>
      <div class="product-title">
        {{ product.name }} Колличество: {{ product.count }}
      </div>
      <div class="product-short-info">
        <div class="short-info">
          {{ product.descriptoin.substr(0, 100) }}...
        </div>
      </div>
      <div calss="product-footer"></div>
    </div>
  </div>
</template>

<script>
export default {
  name: "ProductList",

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
.product-title {
  border-bottom: solid 1px grey;
  padding-bottom: 6px;
}

.prduct-item {
  border: solid 1px;
  margin: 5px;
  padding: 10px;
}
.add {
  margin: 5px;
}
.edit,
.remove {
  margin-right: 2px;
  float: right;
}
.product-short-info {
  padding-top: 7px;
}
</style>
