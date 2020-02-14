<template>
  <div class="vaults-sticker">
    <div class="card" style="width: 20vh; height: 28vh;">
      <div class="card-body">
        <h5 class="card-title text-wrap">{{ vaultData.name }}</h5>
        <p class="card-text text-left text-wrap">{{ vaultData.description }}</p>
      </div>
      <div>
        <router-link :to="{name: 'VaultView', params: { id: vaultData.id} }">
          <!-- <button @click.prevent="viewKeeps(vaultData.id)">View Keeps</button> -->
          <p>View Keeps</p>
        </router-link>
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
    // viewKeeps(vaultData) {
    //   this.$store.dispatch("viewVault", vaultData);
    // }
  }
};
</script>

<style>
</style>