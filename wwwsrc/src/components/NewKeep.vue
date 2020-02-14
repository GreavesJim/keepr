<template>
  <div class="new-keep">
    <div class="card-body">
      <h5 class="card-title mt-2">New Keep</h5>

      <button
        type="button"
        class="btn btn-primary"
        data-target="#newKeepForm"
        data-toggle="modal"
      >Create</button>
    </div>
    <!-- modal code -->
    <div
      class="modal fade"
      data-backdrop="static"
      id="newKeepForm"
      tabindex="-1"
      role="dialog"
      aria-labelledby="newKeepLabel"
      aria-hidden="true"
    >
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="newKeepLabel">Create a Keep</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>

          <form @submit.prevent="createKeep">
            <div class="modal-body">
              <div class="form-group text-left">
                <label for="newKeepTitle">Name</label>
                <input
                  v-model="newKeepr.name"
                  type="text"
                  class="form-control"
                  id="newKeepName"
                  placeholder="Name your keep"
                  required
                />
              </div>
              <div class="form-group text-left">
                <label for="newKeepDesc">Keep description</label>
                <textarea
                  v-model="newKeepr.description"
                  class="form-control"
                  id="newKeepDesc"
                  placeholder="Share some details about your keep..."
                  required
                ></textarea>
              </div>
              <div class="form-group text-left">
                <label for="newKeepImg">Keep Image</label>
                <input
                  v-model="newKeepr.img"
                  type="text"
                  class="form-control"
                  id="keepImg"
                  placeholder="paste URL here..."
                />
                <label class="form-group-label" for="keepImg">Choose file, optional</label>
              </div>

              <div class="custom-control custom-switch text-left mt-3">
                <input
                  v-model="newKeepr.isPrivate"
                  type="checkbox"
                  class="custom-control-input"
                  id="privacySwitch"
                />
                <p>Privacy settings:</p>
                <label
                  v-if="this.newKeepr.isPrivate"
                  class="custom-control-label"
                  for="privacySwitch"
                >Private</label>
                <label
                  v-else-if="!this.newKeepr.isPrivate"
                  class="custom-control-label"
                  for="privacySwitch"
                >Public</label>
              </div>
            </div>
            <div class="modal-footer d-flex justify-content-center">
              <button type="submit" class="btn btn-primary d-flex justify-content-left">Create Keep!</button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "newKeep",
  mounted() {},
  data() {
    return {
      newKeepr: {
        name: "",
        description: "",
        isPrivate: true,
        img: ""
      }
    };
  },
  methods: {
    createKeep() {
      $("#newKeepForm").modal("hide");
      let keep = { ...this.newKeepr };
      console.log(keep);

      this.$store.dispatch("addKeep", keep);
      this.newKeepr.name = "";
      this.newKeepr.description = "";
      this.newKeepr.isPrivate = true;
      this.newKeepr.img = "";
    }
  }
};
</script>



<style>
</style>