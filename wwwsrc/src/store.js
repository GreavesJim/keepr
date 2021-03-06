import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "./router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    publicKeeps: [],
    yourKeeps: [],
    user: {},
    Vaults: [],
    activeVault: {},
    VaultKeeps: []
  },
  mutations: {
    setPublicKeeps(state, payload) {
      state.publicKeeps = payload;
    },
    setResource(state, payload) {
      state[payload.name] = payload.data;
    },
    addUserKeep(state, payload) {
      state.yourKeeps.push(payload);
    },
    addUserVault(state, payload) {
      state.Vaults.push(payload);
    }
  },
  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.Authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    async getPublicKeeps({ commit, dispatch }) {
      try {
        let res = await api.get("keeps");
        commit("setResource", { name: "publicKeeps", data: res.data });
      } catch (e) {
        console.warn(e.message);
      }
    },
    async getYourKeeps({ commit, dispatch }) {
      try {
        debugger;
        let res = await api.get("keeps/users");
        commit("setResource", { name: "yourKeeps", data: res.data });
        console.log(res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async getYourVaults({ commit, dispatch }) {
      try {
        let res = await api.get("vaults");
        commit("setResource", { name: "Vaults", data: res.data });
      } catch (error) {
        console.error(error);
      }
    },
    async deleteKeep({ commit, dispatch }, keepData) {
      await api.delete("keeps/" + keepData.id);
      dispatch("getPublicKeeps");
      dispatch("YourKeeps");
    },
    async deleteVault({ commit, dispatch }, vaultData) {
      await api.delete("vaults/" + vaultData.id);
      dispatch("getYourVaults");
    },
    async addKeep({ commit, dispatch }, keep) {
      let res = await api.post("keeps", keep);
      commit("addUserKeep", res.data);
    },
    async addVault({ commit, dispatch }, vault) {
      let res = await api.post("vaults", vault);
      commit("addUserVault", res.data);
    },
    async getVaultKeeps({ commit, dispatch }, id) {
      try {
        let res = await api.get("vaultkeeps/" + id + "/keeps");
        console.log(res.data);

        commit("setResource", { name: "VaultKeeps", data: res.data });
      } catch (error) {
        console.error(error);
      }
    },
    async getVaultbyId({ commit, dispatch }, id) {
      try {
        let res = await api.get("vaults/" + id);
        commit("setResource", { name: "activeVault", data: res.data });
      } catch (error) {
        console.error(error);
      }
    },
    // async viewVault({ commit, dispatch }, vaultId) {

    //   router.push({ name: "VaultView", params: { id: vaultId } });
    // },
    async addKeeptoVault({ commit, dispatch }, VaultKeep) {
      try {
        let res = await api.post("vaultkeeps", {
          vaultId: VaultKeep.vaultId,
          keepId: VaultKeep.keepId
        });
        commit("setResource", { name: "VaultKeeps", data: res.data });
      } catch (error) {
        console.error(error);
      }
    }
  }
});
