<template>
  <div class="VaultView container-fluid">
    <div class="row">
      <div class="col">
        <h1>{{yourVault.name}}</h1>
      </div>
    </div>
    <div class="row">
      <keep-sticker class="col" v-for="keeps in yourVaultKeeps" :key="keeps.id" :keepData="keeps"></keep-sticker>
    </div>
  </div>
</template>

<script>
import KeepSticker from "@/components/KeepSticker.vue";

export default {
  name: "VaultView",
  computed: {
    yourVault() {
      return this.$store.state.activeVault;
    },
    yourVaultKeeps() {
      return this.$store.state.VaultKeeps;
    }
  },
  mounted() {
    this.$store.dispatch("getVaultbyId", this.$route.params.id);

    this.$store.dispatch("getVaultKeeps", this.$route.params.id);
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

<style>
</style>
