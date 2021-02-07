<template>
  <div class="productList">
    <div class="productListWrapper">
      <h1>Каталог товаров</h1>
      <div
        class="productItemWrapper"
        v-for="(product, id) in paginatedData"
        v-bind:key="id"
      >
        <div class="productItem" v-if="product.count > 0">
          <Product v-bind:product="product" />
          <div class="productFotter">
            <button
              v-if="product.count > 0"
              class="addToBasket"
              @click="addToBasket(product)"
            >
              Добавить в корзину
            </button>
          </div>
        </div>
      </div>
      <div class="pagWrapper">
        <div class="pagination">
          <span class="pagBtnWrapper">
            <img
              class="paginationBtn"
              :src="leftArrow"
              @click="prevPage()"
              v-show="!pageNumber == 0"
            />
          </span>
          <span class="pagBtnWrapper"> {{ pageNumber + 1 }} </span>
          <span class="pagBtnWrapper">
            <img
              class="paginationBtn"
              :src="rightArrow"
              @click="nextPage()"
              v-show="pageNumber < pageCount - 1"
            />
          </span>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Product from "./Product";
import leftArrow from "../../assets/left-arrow.png";
import rightArrow from "../../assets/right-arrow.png";
import { productService } from "@/services";

export default {
  name: "ProductList",
  components: { Product },
  data: () => ({
    products: [],
    size: 5,
    pageNumber: 0,
    leftArrow,
    rightArrow
  }),
  computed: {
    pageCount() {
      let l = this.products.length,
        s = this.size;
      return Math.ceil(l / s);
    },
    paginatedData() {
      const start = this.pageNumber * this.size,
        end = start + this.size;
      return this.products.slice(start, end);
    }
  },
  methods: {
    addToBasket(product) {
      this.showPopup = false;
      this.$store.dispatch("basket/addItem", product);
    },
    nextPage() {
      this.pageNumber++;
    },
    prevPage() {
      this.pageNumber--;
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
.productList {
  margin-top: 5px;
  padding: 5px;
}
.productListWrapper {
  margin-top: 65px;
  border: solid 1px #e7e7e7;
  border-radius: 5px;
  position: relative;
}
h1 {
  position: absolute;
  top: -60px;
  left: -1px;
  border: solid 1px #e7e7e7;
  display: inline-block;
  border-bottom: solid #fff;
  border-radius: 5px;
  padding: 5px;
}

.addToBasket {
  display: block;
  margin-top: -45px;
  margin-right: 20px;
  float: right;
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
.pagWrapper {
  margin-top: 30px;
  margin-bottom: 30px;
}
.pagination {
  display: flex;
  justify-content: center;
}
.paginationBtn {
  margin-top: 5px;
  display: inline;
  height: 20px;
  padding: 5px;
}
.paginationBtn:hover {
  cursor: pointer;
  padding: 0px;
  height: 20px;
}
.pagBtnWrapper {
  font-size: 20px;
  text-align: center;
  flex-grow: 1;
  width: 100px;
}
</style>
