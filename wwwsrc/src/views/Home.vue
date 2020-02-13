<template>
  <div class="container-fluid home">
    <div class="row">
      <div class="col">
        <h1>Welcome Home</h1>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <h2>Public Keeps</h2>
      </div>
      <keep-sticker class="col-2" v-for="keep in publicKeeps" :key="keep.Id" :keepData="keep"></keep-sticker>
    </div>
    <div class="row">
      <div class="col-12">
        <h2>Your Keeps</h2>
      </div>
      <keep-sticker class="col-2" v-for="keep in yourKeeps" :key="keep.Id" :keepData="keep"></keep-sticker>
    </div>
  </div>
</template>

<script>
import KeepSticker from "@/components/KeepSticker.vue";

export default {
  name: "home",
  computed: {
    user() {
      return this.$store.state.user;
    },
    publicKeeps() {
      return this.$store.state.publicKeeps;
    },
    yourKeeps() {
      return this.$store.state.yourKeeps;
    }
  },
  mounted() {
    this.$store.dispatch("getPublicKeeps");
    this.$store.dispatch("getYourKeeps");
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components: {
    KeepSticker
  }
};
</script>
