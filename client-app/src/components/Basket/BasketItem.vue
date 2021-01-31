<template>
  <div class="prduct-item">
    <div class="product-short-info">
      {{ item.product.name }}
      <div class="short-info">
        {{ item.product.descriptoin.substr(0, 100) }}...
      </div>
      <router-link class="link" to="/"> Подробнее </router-link>
    </div>
    <div calss="product-footer">
      <div class="count-btn">
        <button @click="removeItem()">-</button> {{ item.count }}
        <button @click="addItem()">+</button>
        <span class="error">{{ errorMsg }}</span>
      </div>
      <div class="remove-btn">
        <button @click="removeFromBasket()">Удалить</button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data: () => ({
    errorMsg: ""
  }),
  name: "BasketItem",
  props: {
    item: Object
  },
  methods: {
    addItem() {
      if (this.item.count + 1 < this.item.product.count) {
        this.item.count++;
        this.errorMsg = "";
        this.$store.dispatch("basket/addElem", this.item);
      } else this.errorMsg = "Превышенно максимальное кол-во товара";
    },
    removeItem() {
      if (this.item.count - 1 >= 1) {
        this.item.count--;
        this.errorMsg = "";
        this.$store.dispatch("basket/removeElem", this.item);
      } else this.errorMsg = "Колличество товара должно быть больше 0";
    },
    removeFromBasket() {
      this.$store.dispatch("basket/removeItem", this.item.product);
    }
  }
};
</script>

<style scoped>
.prduct-item {
  border: solid 1px;
  margin: 5px;
  padding: 10px;
}
.remove-btn {
  text-align: right;
}
.count-btn {
  margin-top: 15px;
}
.product-footer {
  padding-left: 5px;
}
.error {
  display: block;
  color: red;
}
</style>
