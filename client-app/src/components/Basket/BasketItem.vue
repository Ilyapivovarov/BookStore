<template>
  <div class="prductItem">
    <div class="productShortInfo">
      Название: {{ item.product.name }}
      <div class="shortInfo">
        Краткое описание:
        {{ item.product.descriptoin.substr(0, 100) }}...
      </div>
      <router-link class="link" to="/"> Подробнее </router-link>
    </div>
    <div calss="productFooter">
      <div class="countBtn">
        <p>Колличество</p>
        <img class="arrow" @click="removeItem()" :src="leftArrow" />
        {{ item.count }}
        <img class="arrow" @click="addItem()" :src="rightArrow" />
        <span class="error">{{ errorMsg }}</span>
      </div>
      <div class="remove">
        <img class="rubbish" :src="rubbish" @click="removeFromBasket()" />
      </div>
    </div>
  </div>
</template>

<script>
import leftArrow from "../../assets/left-arrow.png";
import rightArrow from "../../assets/right-arrow.png";
import rubbish from "../../assets/rubbish.png";

export default {
  data: () => ({
    errorMsg: " ",
    leftArrow,
    rightArrow,
    rubbish
  }),
  name: "BasketItem",
  props: {
    item: Object
  },
  methods: {
    addItem() {
      if (this.item.count + 1 <= this.item.product.count) {
        this.item.count++;
        this.errorMsg = " ";
        this.$store.dispatch("basket/addElem", this.item);
      } else this.errorMsg = "Максимально колличество товара";
    },
    removeItem() {
      if (this.item.count - 1 !== 0) {
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
.prductItem {
  border: solid 1px;
  margin: 5px;
  padding: 10px;
  height: 190px;
}

.countBtn {
  margin-top: 15px;
  margin-left: 5px;
}

.productFooter {
  padding-left: 5px;
}
.error {
  height: 10px;
  margin-top: 3px;
  display: block;
  color: red;
}
.arrow {
  display: inline;
  position: relative;
  top: 5px;
  height: 20px;
  padding: 3px;
}

.arrow:hover {
  cursor: pointer;
  border-radius: 100%;
  box-shadow: 0 0 0 1pt #000;
  transition: 0.3s;
}
.rubbish {
  position: relative;
  margin-right: 20px;
  top: -35px;
  float: right;
  width: 30px;
}

.rubbish:hover {
  cursor: pointer;
}
</style>
