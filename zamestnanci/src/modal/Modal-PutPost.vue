<template>

 <b-modal :hide-footer="true" class="modal"  id="ZamestnanecModal" title="Vytvorit">
          <!-- zac -->
        <div>
    <form ref="anyName" @submit.prevent="Post()" class="container form-inline"><br>
  <div class="mb-2">
<th>Meno</th>
    <input type="text" class="form-control" id="meno" v-model="Employee.name" placeholder="meno" required> 
  </div>
    <th>Priezvisko</th>
  <div class="mb-2">
    <input type="text" class="form-control" id="priezvisko" v-model="Employee.lastName" placeholder="priezvisko" required>
 </div>
    <th>Adresa</th>
  <div class="mb-2">
    <input type="text" class="form-control" id="adresa" v-model="Employee.adress" placeholder="adresa">
  </div>
  <th>Dátum narodenia</th>  
<div class="mb-2">
  <input v-model="Employee.dateOfBirth" type="date" placeholder="dátum narodenia" required  />
</div>
  <th> Dátum nastupu</th>
<div class="mb-2">
  <input v-model="Employee.dateOfEntry" type="date" placeholder="dátum nástupu" required/>
</div>
  <th>Pozícia</th>
<div class="input-group mb-3">
                
                <select class="form-select" v-model="Employee.positionId" required>
                    <option value="" selected disabled hidden>Pozícia</option>
                    <option v-for="(pos, index) in positions" :key="index" placeholder="Positions" :value="pos.positionId">{{(positions[index].positionName)}}</option>
                </select>
            </div>

<button type="submit"  class="close-modal btn btn-success btn-square-md float-end m-1" >Create</button>

</form>
</div>           
 <!-- koniec -->
</b-modal>
</template>
<script lang="ts">
import { defineComponent, PropType } from 'vue';
import Employees from '../Models/IEmployees';
import Positions from '../Models/IPositions'
import EmployeeRepository from '../Repository/EmployeesRepository';
import PositionsRepository from '../Repository/PositionsRepository';


import ResponseData from '../Models/IResponseData';

export default defineComponent({
    name: "Modal_pop",
    
   data(){

     return {

       positions: [] as Positions[],
      
       Employee: {
         zamestnanecId: 0,
         name: "",
         lastName: "",
         adress: "",
         dateOfBirth: "",
         dateOfEntry: "",
         archivovany: false,
         positionId: "",
       },
     };
   },
   methods: {

     

      ref(){
        this.$emit("ref");
      },

     get(){
      PositionsRepository.getAll().then((response: ResponseData) => {
               this.positions = response.data;
                console.log(response.data);
            })
                .catch((e: Error) => {
                console.log(e);
            });
     },
     Post(){
       EmployeeRepository.Post(this.Employee).then((response: ResponseData) => {
                console.log(response.data)
                      this.ref();
                      this.Employee.name = "",
                      this.Employee.lastName = "",
                      this.Employee.adress = "",
                      this.Employee.dateOfBirth= "",
                      this.Employee.dateOfEntry = "",
                      this.Employee.positionId = ""

                      
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