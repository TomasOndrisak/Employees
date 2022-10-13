<template>
<div>
  <br>


<div class="container">
  <br><br><br>
  <button v-b-modal="'ZamestnanecModal'" class="btn btn-secondary btn-square-md float-end">Pridať nového zamestnanca</button>
  <table class="table">
    <thead class="thead-light">
    <tr>
      <th scope="col">Meno priezvisko</th>
      <th scope="col">Pozícia</th>
      <th scope="col"></th>
    </tr>
    </thead>
  <tbody>
        <tr v-for="(zam, index) in zamestnanci" v-bind:key="index">
        <td><a v-b-modal="'modalZamestnanec' + zam.zamestnanecId">{{zam.meno}} {{zam.priezvisko}}</a></td>
        <td>{{zam.pozicie.nazovPozicie}}</td> 
        <td><button v-b-modal="'modalZamestnanecEdit'" v-on:click="SetZamestnanec(zam.zamestnanecId)" class="btn btn-warning">Editovať</button></td>
    
        <td><button type="button" class="btn btn-danger" v-on:click="Delete(zam.zamestnanecId)">Zmazať</button></td> 
      </tr>
  </tbody>
</table>

</div>
</div>
<Modal_edit @refresh="Get" :zamestnanec="zamestnanec"></Modal_edit>
<Modal_post @ref="Get" :zamestnanci="zamestnanci"></Modal_post>
<Modal_pop :Zamestnanci="zamestnanci"></Modal_pop>

</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import Zamestnanci from '../Types/Zamestnanci';
import ResponseData from "../Types/ResponseData";
import Zamestnanec from "../services/Zamestnanec";
import Modal_pop from '../modal/Modal-Popup.vue';
import Modal_post from '../modal/Modal-PutPost.vue';
import Modal_edit from '../modal/Modal-edit.vue';

export default defineComponent({

    
    name: "Zamestnanci-list",

    components: {
        Modal_pop,
        Modal_post,
        Modal_edit
    },
    data() {

        return {
            zamestnanci: [] as Zamestnanci[],
            zamestnanec: {} as any
        };
    },
    methods: {
     
        // GET ALL
        Get() {
            Zamestnanec.getAll().then((response: ResponseData) => {
                this.zamestnanci = response.data;
                
                console.log(response.data);})
                .catch((e: Error) => {
                console.log(e); });
        },

        SetZamestnanec(id: number){
          this.zamestnanec = this.zamestnanci.find(z => z.zamestnanecId === id);
        },  

        // GET ID 
        GetId(id: any) {
            Zamestnanec.getId(id).then((response: ResponseData) => {
                this.zamestnanci = response.data;
                console.log(response.data);}).catch((e: Error) => {
                console.log(e);});
        },

        Delete(zamestnanecId:number){
            if(confirm("chcete archivovať zamestnanca ?")){
              Zamestnanec.getId(zamestnanecId).then((response:ResponseData) =>
              {console.log(response.data)

              Zamestnanec.archivuj(zamestnanecId, response.data).then((response:ResponseData) =>
              {console.log(console.error(response.data))
               this.Get();});
              }).catch((e: Error) => {
          console.log(e);
        });}

          else if (confirm("Chcete trvalo zmazat zamestnanca ?")){
          Zamestnanec.delete(zamestnanecId).then((response: ResponseData) => {
          console.log(response.data);
          this.Get();
        }).catch((e: Error) => {
          console.log(e);
        });
        }   
    },
  },
    
    created() {
     this.Get();
    },
})
</script>
     