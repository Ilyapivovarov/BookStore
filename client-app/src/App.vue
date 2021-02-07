<template>
  <div id="app">
    <div id="nav">
      <NavMenu />
    </div>
    <router-view />
  </div>
</template>

<script>
import NavMenu from "./components/NavMenu/NavMenu";

export default {
  name: "App",
  components: {
    NavMenu
  }
};
</script>

<style scoped>
#app {
  position: relative;
  left: 0;
  right: 0;
  top: 0;
  bottom: 0;
  min-height: 100vh;
  height: auto;
  margin-left: 5%;
  margin-right: 5%;
  margin-top: 10px;
  min-width: 680px;
  border: solid 1px blue;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.5); /* Параметры тени */
  padding: 10px;
}
</style>
