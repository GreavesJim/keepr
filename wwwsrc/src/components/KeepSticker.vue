<template>
  <div class="keep-sticker">
    <div class="card" style="width: 20vh; height: 28vh;">
      <div class="card-body">
        <h5 class="card-title text-wrap">{{ keepData.name }}</h5>
        <p class="card-text text-left text-wrap">{{ keepData.description }}</p>
        <img :src="keepData.img" alt style="max-height: 4rem; max-width: 4.7rem;" />
        <button @click.prevent="deleteKeep(keepData)">X</button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "KeepSticker",
  mounted() {},
  data() {
    return {};
  },
  props: ["keepData"],
  methods: {
    deleteKeep(keepData) {
      this.$store.dispatch("deleteKeep", keepData);
      console.log(keepData);
    }
  }
};
</script>

<style>
</style>