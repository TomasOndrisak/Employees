<template>



<div class="container">
       <br><br><br><br><br><br>
  
  <table class="table">
    <thead class="thead-light">
    <tr>
      <th scope="col">Meno priezvisko</th>
      <th scope="col">Posledná Pozícia</th>
      <th scope="col"></th>
    </tr>
    </thead>
  <tbody>
        <tr v-for="(zam, index) in zamestnanci" v-bind:key="index">
        <td><a v-b-modal="'modalZamestnanec' + zam.zamestnanecId">{{zam.meno}} {{zam.priezvisko}}</a></td>
        <td>{{zam.pozicie.nazovPozicie}}</td> 
        <td> </td>
        <td><button type="button" class="btn btn-danger" v-on:click="Delete(zam.zamestnanecId)">Zmazať</button></td> 
      </tr>
  </tbody>
</table>
</div>


<Modal_pop :Zamestnanci="zamestnanci">
</Modal_pop>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import Zamestnanci from '../Types/Zamestnanci';
import ResponseData from "../Types/ResponseData";
import Zamestnanec from "../services/Zamestnanec";
import Modal_pop from '../modal/Modal-Popup.vue';

export default defineComponent({

    
    name: "Zamestnanci-list",

    components: {
        Modal_pop
    },
    
    

    
        //popup
    data() {
        return {
            zamestnanci: [] as Zamestnanci[],
            
        
            
        };
    },
    methods: {

        
        // GET ALL
        Get() {
            Zamestnanec.getArchivovany().then((response: ResponseData) => {
                this.zamestnanci = response.data;
                console.log(response.data);
            })
                .catch((e: Error) => {
                confirm("Server nie je zapnuty");
                console.log(e);
            });
        },
        // GET ID 
        GetId(id: any) {
            Zamestnanec.getId(id).then((response: ResponseData) => {
                this.zamestnanci = response.data;
                console.log(response.data);
            })
                .catch((e: Error) => {
                console.log(e);
            });
        },

        Delete(id:number){
          if(confirm("Chcete určite trvalo zmazať zamestnanca ?")){
          Zamestnanec.delete(id).then((response: ResponseData) => {
          console.log(response.data);
          this.Get();
        })
        .catch((e: Error) => {
          console.log(e);
        });
        
        Zamestnanec.getArchivovany();}
        
    },

    },
    mounted() {
        this.Get();
    },
    
})
</script>