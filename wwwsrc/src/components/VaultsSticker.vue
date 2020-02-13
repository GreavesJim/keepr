<template>
  <div class="vaults-sticker">
    <div class="card" style="width: 20vh; height: 28vh;">
      <div class="card-body">
        <h5 class="card-title text-wrap">{{ vaultData.name }}</h5>
        <p class="card-text text-left text-wrap">{{ vaultData.description }}</p>
      </div>
      <button @click.prevent="deleteVault(vaultData)">X</button>
    </div>
  </div>
</template>

<script>
import NewKeep from "@/components/NewKeep.vue";
export default {
  name: "VaultsSticker",
  mounted() {},
  data() {
    return {};
  },
  props: ["vaultData"],
  methods: {
    deleteVault(vaultData) {
      this.$store.dispatch("deleteVault", vaultData);
    }
  }
};
</script>

<style>
</style>