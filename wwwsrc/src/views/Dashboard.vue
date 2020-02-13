<template>
  <div class="dashboard container-fluid">
    <div class="row">
      <div class="col">
        <h1>WELCOME TO THE DASHBOARD</h1>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <h4>make a new Keep</h4>
        <new-keep></new-keep>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <h1>Your Vaults</h1>
      </div>

      <vaults-sticker class="col-2" v-for="vault in yourVaults" :key="vault.Id" :vaultData="vault"></vaults-sticker>
    </div>
  </div>
</template>

<script>
import VaultsSticker from "@/components/VaultsSticker.vue";
import NewKeep from "@/components/NewKeep.vue";
export default {
  name: "dashboard",
  computed: {
    yourVaults() {
      return this.$store.state.Vaults;
    }
  },
  mounted() {
    this.$store.dispatch("getYourVaults");
    this.$store.dispatch("getYourKeeps");
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components: {
    VaultsSticker,
    NewKeep
  }
};
</script>

<style>
</style>
