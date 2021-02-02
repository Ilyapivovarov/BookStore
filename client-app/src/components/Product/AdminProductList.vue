<template>
  <div class="productList">
    <PopupWindow
      v-if="showPopup"
      @closePopup="closePopup()"
      popupTitle="Создание товара"
      @saveProduct="saveProduct()"
    >
      <label for="productName">Название товара</label>
      <input name="productName" type="text" v-model="newProduct.name" />
      <label for="productDescription">Описание товара</label>
      <textarea
        name="productDescription"
        type="text"
        v-model="newProduct.descriptoin"
      />
      <label for="productCount">Колличество товара</label>
      <input name="productCount" type="number" v-model="newProduct.count" />

      <label for="productPrice">Цена</label>
      <input name="productPrice" type="number" v-model="newProduct.price" />
    </PopupWindow>

    <div>
      <button class="add" @click="openPopup">Добавить</button>
    </div>
    <AdminProductitem
      v-for="product in products"
      v-bind:key="product.id"
      :product="product"
    />
  </div>
</template>

<script>
import AdminProductitem from "./AdminProductItem";
import PopupWindow from "../Popup/PopupWindow";

export default {
  name: "ProductList",
  components: {
    AdminProductitem,
    PopupWindow
  },
  data: () => ({
    showPopup: false,

    newProduct: {
      name: "",
      description: "",
      price: 0,
      count: 1
    }
  }),
  methods: {
    openPopup() {
      this.showPopup = true;
    },
    closePopup() {
      this.showPopup = false;
    },
    saveProduct() {
      this.$store.dispatch("product/create", this.newProduct);
      this.showPopup = false;
    }
  },
  computed: {
    products() {
      return this.$store.state.product.products;
    }
  },
  beforeCreate() {
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
.productList div {
  margin-top: 5px;
}
textarea {
  resize: none;
  height: 170px;
  font-size: 14px;
}
</style>
