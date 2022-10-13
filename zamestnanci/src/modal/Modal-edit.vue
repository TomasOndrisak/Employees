<template>

  <b-modal :hide-footer="true" class="modal" :id="'modalZamestnanecEdit'" title="Upravit Zamestnanca">
    <div class="container col-12">
   
      <form @submit.prevent="Edit()" class="border container form-inline"><br>
        <div class="mb-2">
          <th>Meno</th>
          <input v-model="post.name" type="text" class="form-control" id="meno">
        </div>
        <th>Priezvisko</th>
        <div class="mb-2">
         <input type="text" class="form-control" v-model="post.lastName">
        </div>
        <th>Adresa</th>
        <div class="mb-2">
          <input type="text" class="form-control" v-model="post.adress">
        </div>
        <th>Dátum narodenia</th>
        <div class="mb-2">
        <input type="text" class="form-control" v-model="post.dateOfBirth">
        </div>
        <th> Dátum nastupu</th>
        <div class="mb-2">
          <input type="text" class="form-control" v-model="post.dateOfEntry">
        </div>
        <th>Pozícia</th>
        <div class="input-group mb-3">
            <select class="form-select" v-model="post.positionId" required>
            <option value="" selected disabled hidden>Pozícia</option>
            <option v-for="(pos, index) in positions" :key="index" placeholder="Pozície" :value="pos.positionId">
              {{(positions, index, pos.positionId)}}</option>
          </select>
        </div>

        <!-- <button type="submit" class="btn btn-success btn-square-md float-end m-1">Uložiť zmenu</button> -->
        <div class="modal-footer">
  <!-- <button type="button" class="btn btn-default" data-dismiss="modal">Close</button> -->
  <button class="btn btn-default btn-success" type="submit" name="submit" value="Submit" data-bs-dismiss="modal">Save</button>
</div>
      </form>
      
      <table class="table">

        <thead class="thead-light">
          <tr>
            <th scope="col">Predosla Pozicia</th>
            <th scope="col">Datum Nastupu</th>
            <th scope="col">Datum Ukoncenia</th>
          </tr>
        </thead>


        <tbody>
          <tr v-for="(poz, index) in lastPositions" v-bind:key="index">
            <td>{{ poz.position.positionName }}</td>
            <td>{{ poz.dateOfEntry }}</td>
            <td>{{ poz.dateOfLeave }}</td>
          </tr>
        </tbody>
      </table>
    

    </div>
    <!-- koniec -->
  </b-modal>

</template>

<script lang="ts">

import { defineComponent, PropType, ref } from 'vue';

import EmployeeRepository from '../Repository/EmployeesRepository';
import PositionsRepository from '../Repository/PositionsRepository';
import LastPositionsRepository from '../Repository/LastPositionsRepository';
import Employees from '../Models/IEmployees';
import ResponseData from '../Models/IResponseData';
import LastPositions from '../Models/ILastPositions';
import Positions from '../Models/IPositions';



export default defineComponent({
  name: "Modal_edit",
  updated(){
  this.GetLastPositions(this.$props.employee.employeeId);
  
  
  },
  beforeUpdate(){
  this.GetId();
  },
  mounted(){
      this.getPositions();
  },

  data() {

    return {

  lastPositions: [] as LastPositions[],
  positions: [] as Positions[],

  Employee: {} as Employees,
  post: {} as Employees
};
  },

  props: {
    employee: {
      required: true,
      type: Object as PropType<Employees>
    }

  },

  watch: {
    
    employee: function (newVal, oldVal) {
      console.log('Prop changed: ', newVal, ' | was: ', oldVal)
    }
  },

  methods: {


    
       refresh(){
        this.$emit("refresh");
      },
     GetLastPositions(id: number) {

        LastPositionsRepository.getAll(id).then((response: ResponseData) => {
        this.lastPositions = response.data;

        console.log(response.data);
      }).catch((e: Error) => {
        console.log(e);
      });
    },

    GetId(){
      EmployeeRepository.getId(this.employee.employeeId).then((response: ResponseData) => {
        this.post = response.data;
        console.log(response.data);
      }).catch((e: Error) => {
        console.log(e);
      });
    },


    Edit() {
      EmployeeRepository.Edit(this.post.employeeId, this.post).then((response: ResponseData) => {
        console.log(response.data);
        this.refresh();
      }).catch((e: Error) => { console.log(e); });
    },

    getPositions() {
      PositionsRepository.getAll().then((response: ResponseData) => {
        this.positions = response.data;
        console.log(response.data);
      }).catch((e: Error) => {
        console.log(e);
      });
    },
  }
});
</script>
<style>
.modal-body {
    max-height: calc(100vh - 210px);
    overflow-y: auto;
    
}
</style>