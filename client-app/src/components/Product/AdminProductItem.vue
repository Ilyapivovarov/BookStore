<template>
  <div class="prduct-item">
    <PopupWindow
      v-if="showPopup"
      @closePopup="closePopup()"
      popupTitle="Редактирование товара"
      @saveProduct="saveProduct()"
    >
      <label for="productName">Название товара</label>
      <input name="productName" type="text" v-model="product.name" />

      <label for="productDescription">Описание товара</label>
      <textarea
        name="productDescription"
        type="text"
        v-model="product.descriptoin"
      />

      <label for="productCount">Колличество товара</label>
      <input name="productCount" type="number" v-model="product.count" />

      <label for="productPrice">Колличество товара</label>
      <input name="productPrice" type="number" v-model="product.price" />

      <span v-for="(error, id) in errors" :key="id"> {{ error }} </span>
    </PopupWindow>

    <div class="toolbar">
      <button class="edit" @click="openPopup()">Редактировать</button>
    </div>
    <div class="product-title">
      {{ product.name }} Колличество: {{ product.count }}
    </div>
    <div class="product-short-info">
      <div class="short-info">{{ product.descriptoin.substr(0, 100) }}...</div>
    </div>
    <div calss="product-footer"></div>
  </div>
</template>

<script>
import PopupWindow from "../Popup/PopupWindow";

export default {
  components: {
    PopupWindow
  },
  props: {
    product: Object
  },
  data: () => ({
    showPopup: false,
    errors: []
  }),
  methods: {
    openPopup() {
      this.showPopup = true;
    },
    closePopup() {
      this.showPopup = false;
    },
    saveProduct() {
      this.$store.dispatch("product/update", this.product);
      this.showPopup = false;
    }
  }
};
</script>

<style scoped>
.product-title {
  border-bottom: solid 1px grey;
  padding-bottom: 6px;
}

textarea {
  resize: none;
  height: 170px;
  font-size: 14px;
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
