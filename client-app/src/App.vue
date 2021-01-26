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
  height: 100%;
  margin-left: 5%;
  margin-right: 5%;
  margin-top: 2%;
  margin-bottom: 7%;
  min-width: 680px;
}
</style>
