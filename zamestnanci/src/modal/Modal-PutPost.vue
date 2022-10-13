<template>

 <b-modal :hide-footer="true" class="modal"  id="ZamestnanecModal" title="Vytvorit">
          <!-- zac -->
        <div>
    <form ref="anyName" @submit.prevent="Post()" class="container form-inline"><br>
  <div class="mb-2">
<th>Meno</th>
    <input type="text" class="form-control" id="meno" v-model="Zamestnanec.meno" placeholder="meno" required> 
  </div>
    <th>Priezvisko</th>
  <div class="mb-2">
    <input type="text" class="form-control" id="priezvisko" v-model="Zamestnanec.priezvisko" placeholder="priezvisko" required>
 </div>
    <th>Adresa</th>
  <div class="mb-2">
    <input type="text" class="form-control" id="adresa" v-model="Zamestnanec.adresa" placeholder="adresa">
  </div>
  <th>Dátum narodenia</th>  
<div class="mb-2">
  <input v-model="Zamestnanec.datumNarodenia" type="date" placeholder="dátum narodenia" required  />
</div>
  <th> Dátum nastupu</th>
<div class="mb-2">
  <input v-model="Zamestnanec.datumNastupu" type="date" placeholder="dátum nástupu" required/>
</div>
  <th>Pozícia</th>
<div class="input-group mb-3">
                
                <select class="form-select" v-model="Zamestnanec.poziciaId" required>
                    <option value="" selected disabled hidden>Pozícia</option>
                    <option v-for="(poz, index) in pozicie" :key="index" placeholder="Pozície" :value="poz.poziciaId">{{(pozicie[index].nazovPozicie)}}</option>
                </select>
            </div>

<button type="submit"  class="close-modal btn btn-success btn-square-md float-end m-1" >Vytvoriť</button>

</form>
</div>
  



           
           
           
           <!-- koniec -->
           </b-modal>
</template>
<script lang="ts">
import { defineComponent, PropType } from 'vue';
import Zamestnanec from '../Types/Zamestnanci';
import Pozicie from '../Types/Pozicie'
import api from '../services/Zamestnanec';
import poz from '../services/Pozicie';
import ResponseData from '../Types/ResponseData';

export default defineComponent({
    name: "Modal_pop",
    
   data(){

     return {

       pozicie: [] as Pozicie[],
      
       Zamestnanec: {
         zamestnanecId: 0,
         meno: "",
         priezvisko: "",
         adresa: "",
         datumNarodenia: "",
         datumNastupu: "",
         archivovany: false,
         poziciaId: "",
       },
     };
   },
   methods: {

     

      ref(){
        this.$emit("ref");
      },

     get(){
       poz.getAll().then((response: ResponseData) => {
               this.pozicie = response.data;
                console.log(response.data);
            })
                .catch((e: Error) => {
                console.log(e);
            });
     },
     Post(){
       api.Post(this.Zamestnanec).then((response: ResponseData) => {
                console.log(response.data)
                      this.ref();
                      this.Zamestnanec.meno = "",
                      this.Zamestnanec.priezvisko = "",
                      this.Zamestnanec.adresa = "",
                      this.Zamestnanec.datumNarodenia= "",
                      this.Zamestnanec.datumNastupu = "",
                      this.Zamestnanec.poziciaId = ""

                      
                })
                .catch((e: Error) => {
                console.log(e);
                 
            });   
          
     },



   },

    mounted() {
        this.get();
    }
    

});
</script>