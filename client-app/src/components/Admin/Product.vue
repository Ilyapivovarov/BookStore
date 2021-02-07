<template>
  <div class="adminProduct">
    <PopupWindow
      v-if="showPopup"
      popupTitle="Редактирование товара"
      submitBtn="Сохранить"
      closeBtn="Закрыть без сохранения"
      @closePopup="closePopup()"
      @submit="saveProduct()"
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

    <div class="productItemWrapper">
      <div class="toolbar">
        <img
          class="edit"
          :src="edit"
          alt="Редактировать"
          @click="openPopup()"
        />
      </div>
      <div class="productTitle">
        <div>
          <h2>{{ product.name }}</h2>
        </div>

        <div>
          <h3>Колличество на складе: {{ product.count }}</h3>
        </div>
      </div>
      <div class="productShortInfo">
        <div class="shortInfo">
          <h3>
            Краткое описание:
          </h3>
          {{ product.descriptoin.substr(0, 100) }}
          <span v-if="product.descriptoin.length > 100">...</span>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import PopupWindow from "../Popup/PopupWindow";
import edit from "../../assets/edit.png";
import { productService } from "@/services";

export default {
  components: {
    PopupWindow
  },
  props: {
    product: Object
  },
  data: () => ({
    edit,
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
      productService.put(this.product);
      this.showPopup = false;
    }
  }
};
</script>

<style scoped>
.productItemWrapper {
  padding: 5px;
}
.productItemWrapper div {
  margin: 5px;
}

.productTitle {
  border-bottom: solid 1px grey;
  padding-bottom: 6px;
}

textarea {
  resize: none;
  height: 170px;
  font-size: 14px;
}
.adminProduct {
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
.productShortInfo {
  padding-top: 7px;
}

.toolbar {
  margin-top: 10px;
}
.edit {
  height: 25px;
  margin-right: 20px;
}
.edit:hover {
  transition: 0.3s;
  cursor: pointer;
  height: 30px;
}
</style>
