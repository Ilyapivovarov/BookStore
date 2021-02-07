<template>
  <div class="popupWrapper" ref="popupWrapper">
    <div class="popupWindow">
      <div class="popupHeader">
        <span>
          <h2>{{ popupTitle }}</h2>
        </span>
      </div>
      <div class="popupContent">
        <slot> </slot>
      </div>
      <div class="popupFooter">
        <button class="submint" @click="submit()">{{ submitBtn }}</button>
        <button class="cancel" @click="close()">{{ closeBtn }}</button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "popupWindow",
  props: {
    popupTitle: String,
    submitBtn: String,
    closeBtn: String
  },
  mounted() {
    let vm = this;
    document.addEventListener("click", function(item) {
      if (item.target === vm.$refs["popupWrapper"]) {
        vm.close();
      }
    });
  },
  methods: {
    close() {
      this.$emit("closePopup");
    },
    submit() {
      this.$emit("submit");
    }
  }
};
</script>

<style scoped>
.popupWrapper {
  display: flex;
  justify-content: center;
  align-items: center;
  position: fixed;
  right: 0px;
  left: 0px;
  top: 0px;
  bottom: 0px;
  background: rgba(64, 64, 64, 0.3);
}
.popupWindow {
  padding: 16px;
  position: fixed;
  z-index: 10;
  width: 600px;
  background: #ffffff;
  box-shadow: 0 0 17px 0 #e7e7e7;
}

.popupHeader {
  display: flex;
  justify-content: space-between;
  align-items: right;
}
.popupContent > * {
  display: grid;
  width: 100%;
}
.popupFooter {
  margin-top: 10px;
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.submint {
  font-size: 18px;
  background: #fff;
  box-shadow: none;
  border: none;
  color: rgb(0, 200, 0);
  border: solid 1px rgb(0, 100, 0);
  border-radius: 2px;
}

.submint:hover {
  color: rgb(255, 255, 255);
  background-color: rgb(0, 200, 0);
  border: solid 1px rgb(0, 100, 0);
  transition: 0.3s;
}

.cancel {
  font-size: 18px;
  background: #fff;
  box-shadow: none;
  border: none;
  color: rgb(255, 0, 0);
  border: solid 1px rgb(100, 0, 0);
  border-radius: 2px;
}

.cancel:hover {
  color: rgb(255, 255, 255);
  background-color: rgb(255, 0, 0);
  border: solid 1px rgb(100, 0, 0);
  transition: 0.3s;
}
</style>
