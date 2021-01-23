<template>
  <div class="home">
    as
    {{ usersList }}
    1
  </div>
</template>

<script>
import { mapGetters } from "vuex";

export default {
  name: "Home",
  components: {},
  data: () => ({}),
  computed: {
    ...mapGetters("users", ["usersList"])
  }
};
</script>
