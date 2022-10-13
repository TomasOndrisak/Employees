<template>

 <b-modal :hide-footer="true"  class="modal" :id="'modalZamestnanec'+emp.employeeId" title="Zamestnanec" v-for="emp in Employees" v-bind:key="emp.employeeId">
           <h1><p> {{emp.name}} {{emp.lastName}}<br></p></h1>   
           <p class="my-4">
                           <b>Adresa:</b> <a>{{emp.adress}}</a> <br>
                           <b>Pozicia:</b> <a>{{emp.positions.positionName}}</a><br>
                           <b>Plat:</b> <a>12 345 €</a><br>
                           <b>Datum Narodenia:</b> <a>{{emp.dateOfBirth}}</a><br>
                            <b>Datum Nastupu:</b> <a>{{emp.dateOfEntry}}</a>
      
                </p></b-modal>
</template>
<script lang="ts">
import { defineComponent, PropType } from 'vue';
import Employees from '../Models/IEmployees';
export default defineComponent({
    name: "Modal_pop",

    props: {   
       Employees : {
            required: true,
             type: Array as PropType<Employees[]>
        }
    },



    

});
</script>