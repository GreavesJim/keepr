<template>
  <div class="keep-sticker">
    <div class="card" style="width: 20vh; height: 28vh;">
      <div class="card-body">
        <h5 class="card-title text-wrap">{{ keepData.name }}</h5>
        <p class="card-text text-left text-wrap">{{ keepData.description }}</p>
        <img :src="keepData.img" alt style="max-height: 4rem; max-width: 4.7rem;" />
      </div>
      <div class="buttons">
        <button>Views</button>
        {{keepData.views}}
        <button>Shares</button>
        {{keepData.shares}}
      </div>
      <div>
        <div class="dropdown dropDown">
          <button
            class="btn btn-sm dropdown-toggle"
            type="button"
            id="dropdownMenuButton"
            data-toggle="dropdown"
          >Keep</button>
          <div class="dropdown-menu">
            <p
              v-for="vault in yourVaults"
              :key="vault.id"
              class="dropdown-item"
              @click="addKeeptoVault(vault.id,keepData.id)"
            >{{vault.name}}</p>
          </div>
        </div>
        {{keepData.keeps}}
      </div>

      <button @click.prevent="deleteKeep(keepData)">X</button>
    </div>
  </div>
</template>

<script>
export default {
  name: "KeepSticker",
  mounted() {
    this.$store.dispatch("getYourVaults");
  },
  data() {
    return {};
  },
  props: ["keepData"],
  methods: {
    deleteKeep(keepData) {
      this.$store.dispatch("deleteKeep", keepData);
      console.log(keepData);
    },
    addKeeptoVault(vaultId, keepId) {
      let VaultKeep = { vaultId, keepId };
      this.$store.dispatch("addKeeptoVault", VaultKeep);
      console.log(VaultKeep);
    }
  },
  computed: {
    yourVaults() {
      return this.$store.state.Vaults;
    }
  }
};
</script>

<style>
.buttons {
  display: flex;
  justify-content: center;
}
</style>