<template>
  <div class="admin">
    <AdminProductList />
  </div>
</template>

<script>
import AdminProductList from "../components/Product/AdminProductList";
import router from "@/router";
export default {
  beforeCreate() {
    if (!this.$store.state.auth.status.loggedIn) {
      router.push("/login");
    } else if (this.$store.state.auth.user.role !== "Admin") {
      router.push("/");
    }
  },
  components: {
    AdminProductList
  }
};
</script>
