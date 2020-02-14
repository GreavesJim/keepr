<template>
  <div class="new-vault">
    <div class="card-body">
      <h5 class="card-title mt-2">New Vault</h5>

      <button
        type="button"
        class="btn btn-primary"
        data-target="#newVaultForm"
        data-toggle="modal"
      >Create</button>
    </div>
    <!-- modal code -->
    <div
      class="modal fade"
      data-backdrop="static"
      id="newVaultForm"
      tabindex="-1"
      role="dialog"
      aria-labelledby="newVaultLabel"
      aria-hidden="true"
    >
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="newVaultLabel">Create a Vault</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>

          <form @submit.prevent="createVault">
            <div class="modal-body">
              <div class="form-group text-left">
                <label for="newVaultTitle">Name</label>
                <input
                  v-model="newVault.name"
                  type="text"
                  class="form-control"
                  id="newVaultName"
                  placeholder="Name your vault"
                  required
                />
              </div>
              <div class="form-group text-left">
                <label for="newKeepDesc">Vault description</label>
                <textarea
                  v-model="newVault.description"
                  class="form-control"
                  id="newVaultDesc"
                  placeholder="Share some details about your vault..."
                  required
                ></textarea>
              </div>
            </div>
            <div class="modal-footer d-flex justify-content-center">
              <button
                type="submit"
                class="btn btn-primary d-flex justify-content-left"
              >Create Vault!</button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "newVault",
  mounted() {},
  data() {
    return {
      newVault: {
        name: "",
        description: "",
        isPrivate: true,
        img: ""
      }
    };
  },
  methods: {
    createVault() {
      $("#newVaultForm").modal("hide");
      let vault = { ...this.newVault };
      console.log(vault);

      this.$store.dispatch("addVault", vault);
      this.newVault.name = "";
      this.newVault.description = "";
    }
  }
};
</script>



<style>
</style>