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
        <tr v-for="(emp, index) in employees" v-bind:key="index">
        <td><a v-b-modal="'modalZamestnanec' + emp.employeeId">{{emp.name}} {{emp.lastName}}</a></td>
        <td>{{emp.positions.positionName}}</td> 
        <td> </td>
        <td><button type="button" class="btn btn-danger" v-on:click="Delete(emp.employeeId)">Zmazať</button></td> 
      </tr>
  </tbody>
</table>
</div>


<Modal_pop :Employees="employees">
</Modal_pop>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import Employees from '../Models/IEmployees';
import ResponseData from "../Models/IResponseData";
import EmployeesRepository from "../Repository/EmployeesRepository";
import Modal_pop from '../modal/Modal-Popup.vue';

export default defineComponent({

    
    name: "Zamestnanci-list",

    components: {
        Modal_pop
    },
   //popup
    data() {
        return {
            employees: [] as Employees[],
       
        };
    },
    methods: {

        
        // GET ALL
        Get() {
            EmployeesRepository.getArchived().then((response: ResponseData) => {
                this.employees = response.data;
                console.log(response.data);
            })
                .catch((e: Error) => {
                confirm("Server is offline");
                console.log(e);
            });
        },
        // GET ID 
        GetId(id: any) {
            EmployeesRepository.getId(id).then((response: ResponseData) => {
                this.employees = response.data;
                console.log(response.data);
            })
                .catch((e: Error) => {
                console.log(e);
            });
        },

        Delete(id:number){
          if(confirm("The employee will be permanently deleted")){
          EmployeesRepository.delete(id).then((response: ResponseData) => {
          console.log(response.data);
          this.Get();
        })
        .catch((e: Error) => {
          console.log(e);
        });
        
        EmployeesRepository.getArchived();}
        
    },

    },
    mounted() {
        this.Get();
    },
    
})
</script>