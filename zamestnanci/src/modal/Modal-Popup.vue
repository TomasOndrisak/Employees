<template>

 <b-modal :hide-footer="true"  class="modal" :id="'modalZamestnanec'+zam.zamestnanecId" title="Zamestnanec" v-for="zam in Zamestnanci" v-bind:key="zam.zamestnanecId">
           <h1><p> {{zam.meno}} {{zam.priezvisko}}<br></p></h1>   
           <p class="my-4">
                           <b>Adresa:</b> <a>{{zam.adresa}}</a> <br>
                           <b>Pozicia:</b> <a>{{zam.pozicie.nazovPozicie}}</a><br>
                           <b>Plat:</b> <a>12 345 €</a><br>
                           <b>Datum Narodenia:</b> <a>{{zam.datumNarodenia}}</a><br>
                            <b>Datum Nastupu:</b> <a>{{zam.datumNastupu}}</a>
      
                </p></b-modal>
</template>
<script lang="ts">
import { defineComponent, PropType } from 'vue';
import Zamestnanci from '../Types/Zamestnanci';
export default defineComponent({
    name: "Modal_pop",

    props: {   
       Zamestnanci : {
            required: true,
             type: Array as PropType<Zamestnanci[]>
        }
    },



    

});
</script>