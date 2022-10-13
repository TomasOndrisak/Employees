<template>
  <div class="container col-5">
    <br><br><br><br>
    <div class="Pozicie">
      <button v-b-modal="'poziciaPost'" class="btn btn-secondary btn-square-md float-end">Vytvorit pozíciu</button>
      <table class="table">
        <thead class="thead-light">
          <tr>
            <th scope="col">Názov pozície</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="poz in pozicie" :key="poz.poziciaId">
            <td>{{ poz.nazovPozicie }}</td>

            <th></th>
            <td><button type="button" class="btn btn-danger" v-on:click="Delete(poz.poziciaId)">Zmazať</button></td>
          </tr>

        </tbody>
      </table>
    </div>
    </div>
  <Modal_Pozicia @refresh="Get"></Modal_Pozicia>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import Pozicie from '../Types/Pozicie';
import ResponseData from "../Types/ResponseData";
import pozicie from "../services/Pozicie";
import Modal_Pozicia from '../modal/Modal-Pozicia.vue';


export default defineComponent({

  components: {
    Modal_Pozicia
  },
  //popup
  data() {
    return {
      pozicie: [] as Pozicie[],
    };
  },

  methods: {


    // GET ALL
    Get() {
      pozicie.getAll().then((response: ResponseData) => {
        this.pozicie = response.data;
        console.log(response.data);
      })
        .catch((e: Error) => {
          confirm("Server nie je zapnuty");
          console.log(e);
        });
    },


    Delete(poziciaId: number) {
      if (confirm("Chcete určite trvalo zmazať poziciu ?")) {
        pozicie.delete(poziciaId).then((response: ResponseData) => {
          console.log(response.data);
          this.Get();
        }).catch((e: Error) => {
          confirm("Poziciu ma pridelenu niektori zo zamestnancov, nemozete tuto poziciu zmazat.")
          console.log(e);
        });
      }
    },
  },

  mounted() {
    this.Get();
  },

})




</script>

