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
