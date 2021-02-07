<template>
  <div class="admin">
    <PopupWindow
      v-if="showPopup"
      @closePopup="closePopup()"
      @submit="saveProduct()"
      popupTitle="Создание товара"
      submitBtn="Сохранить"
      closeBtn="Закрыть без сохранения"
    >
      <label for="productName">Название товара</label>
      <input name="productName" type="text" v-model="newProduct.name" />
      <label for="productDescription">Описание товара</label>
      <textarea
        name="productDescription"
        type="text"
        v-model="newProduct.descriptoin"
        maxlength="650"
      />
      <label for="productCount">Колличество товара</label>
      <input
        name="productCount"
        type="number"
        min="0"
        v-model="newProduct.count"
      />

      <label for="productPrice">Цена</label>
      <input
        name="productPrice"
        type="number"
        min="0"
        v-model="newProduct.price"
      />
    </PopupWindow>
    <div class="productList">
      <div>
        <button class="add" @click="openPopup">Добавить новый товар</button>
      </div>
      <AdminProduct
        v-for="(product, id) in products"
        v-bind:key="id"
        :product="product"
      />
    </div>
  </div>
</template>

<script>
import AdminProduct from "./Product";
import PopupWindow from "../Popup/PopupWindow";
import { productService } from "@/services";

export default {
  name: "ProductList",
  components: {
    PopupWindow,
    AdminProduct
  },
  data: () => ({
    showPopup: false,
    newProduct: {
      name: "",
      description: "",
      price: 0,
      count: 1
    },
    products: []
  }),
  methods: {
    openPopup() {
      this.showPopup = true;
    },
    closePopup() {
      this.showPopup = false;
    },
    saveProduct() {
      productService.post(this.newProduct);
      this.showPopup = false;
    }
  },
  mounted() {
    productService.getAll().then(products => {
      this.products = products;
    });
  }
};
</script>

<style scoped>
.admin {
  widows: 100%;
  margin-top: 5px;
  padding: 2px;
}
.admin div {
  margin-top: 5px;
  padding: 5px;
}
textarea {
  resize: none;
  height: 170px;
  font-size: 14px;
}
.add {
  display: block;
  font-size: 18px;
  background: #fff;
  box-shadow: none;
  border: none;
  color: rgb(0, 200, 0);
  border: solid 1px rgb(0, 100, 0);
  border-radius: 2px;
}

.add:hover {
  color: rgb(255, 255, 255);
  background-color: rgb(0, 200, 0);
  border: solid 1px rgb(0, 100, 0);
  transition: 0.3s;
}
</style>
