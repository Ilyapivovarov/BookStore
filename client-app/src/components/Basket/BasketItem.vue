<template>
  <div class="prductItem">
    <div class="productShortInfo">
      Название: {{ item.product.name }}
      <div class="shortInfo">
        Описание:
        {{ item.product.descriptoin }}
      </div>
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
  name: "BasketItem",

  props: {
    item: Object
  },
  data: () => ({
    errorMsg: " ",
    leftArrow,
    rightArrow,
    rubbish
  }),
  methods: {
    addItem() {
      if (this.item.count + 1 <= this.item.product.count) {
        this.item.count++;
        this.errorMsg = " ";
        this.$store.dispatch("basket/addElem", this.item);
      } else this.errorMsg = "Максимальное количество товара";
    },
    removeItem() {
      if (this.item.count - 1 !== 0) {
        this.item.count--;
        this.errorMsg = "";
        this.$store.dispatch("basket/removeElem", this.item);
      } else this.errorMsg = "Количество товара должно быть больше 0";
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
  height: auto;
  margin: 5px;
  padding: 10px;
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
