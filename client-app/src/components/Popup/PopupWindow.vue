<template>
  <div class="popupWrapper" ref="popupWrapper">
    <div class="popupWindow">
      <div class="popupHeader">
        <span>
          {{ popupTitle }}
        </span>
      </div>
      <div class="popupContent">
        <slot> </slot>
      </div>
      <div class="popupFooter">
        <button @click="submit()">{{ submitBtn }}</button>
        <button @click="close()">{{ closeBtn }}</button>
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
.popupContent {
  display: grid;
  width: 100%;
}
.popupFooter {
  margin-top: 10px;
  display: flex;
  justify-content: space-between;
  align-items: center;
}
</style>
