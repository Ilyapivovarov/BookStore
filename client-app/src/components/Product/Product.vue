<template>
  <div class="prductItem">
    <div class="productTitle">
      <h2>{{ product.name }}</h2>
    </div>
    <div class="productShortInfo">
      <div class="shortInfo">
        <h3>Краткое описание:</h3>
        {{ product.descriptoin.substr(0, 100) }}
        <span v-if="product.descriptoin.length > 100">...</span>
      </div>
      <div class="count">
        <h3>Количество на складе:</h3>
        {{ product.count }} шт.
      </div>
      <div class="count">
        <h3>Цена</h3>
        {{ product.price }} руб.
      </div>
    </div>
    <div calss="productFooter">
      <button class="showInfoBtn" @click="openPopup()">Подробнее</button>
    </div>

    <Popup
      v-if="showPopup"
      submitBtn="Добавить в корзину"
      closeBtn="Закрыть"
      @closePopup="closePopup()"
      @submit="addToBasket()"
    >
      <div class="infoWrpaper">
        <h4>Название</h4>
        <div class="infoValue">{{ product.name }}</div>
      </div>

      <div class="infoWrpaper">
        <h4>Количество</h4>
        <div class="infoValue">{{ product.count }} шт.</div>
      </div>

      <div class="infoWrpaper">
        <h4>Цена</h4>
        <div class="infoValue">{{ product.price }}.00 р</div>
      </div>

      <div class="descriptoinWrapper">
        <h4>Описание:</h4>
        <div class="descriptoinValue">{{ product.descriptoin }}</div>
      </div>
    </Popup>
  </div>
</template>

<script>
import Popup from "../Popup/PopupWindow";

export default {
  name: "ProductItem",
  components: {
    Popup
  },
  props: {
    product: Object
  },
  data: () => ({
    showPopup: false
  }),
  methods: {
    openPopup() {
      this.showPopup = true;
    },
    closePopup() {
      this.showPopup = false;
    },
    addToBasket() {
      this.showPopup = false;
      this.$store.dispatch("basket/addBook", this.product);
    }
  }
};
</script>

<style scoped>
.prductItem {
  border-bottom: 1px solid #e7e7e7;
  margin: 5px;
  padding: 10px;
}
.addToBasket {
  display: block;
  float: right;
  margin-bottom: 10px;
  font-size: 18px;
  background: #fff;
  box-shadow: none;
  border: none;
  color: rgb(0, 200, 0);
  border: solid 1px rgb(0, 100, 0);
  border-radius: 2px;
}

.addToBasket:hover {
  color: rgb(255, 255, 255);
  background-color: rgb(0, 200, 0);
  border: solid 1px rgb(0, 100, 0);
  transition: 0.3s;
}

.productShortInfo div {
  margin: 7px;
}
.infoWrpaper {
  padding: 4px;
  margin: 7px;
  display: flex;
  flex: content;
  flex-basis: 50px;
  justify-content: space-between;
}

.infoWrpaper:hover {
  background-color: #e7e7e7;
  transform: 0.3s;
}

.infoWrpaper div {
  width: 50%;
}

.infoValue {
  text-align: center;
}
.descriptoinWrapper {
  padding: 4px;
  margin: 7px;
}
.descriptoinValue {
  padding: 5px;
}
.descriptoinValue:hover {
  background-color: #e7e7e7;
  transform: 0.3s;
}
.showInfoBtn {
  background-color: #fff;
  box-shadow: none;
  border: none;
  color: blue;
  text-decoration: underline;
  outline: none;
}
.showInfoBtn:hover {
  cursor: pointer;
}
</style>
