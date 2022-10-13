<template>

  <b-modal :hide-footer="true"  class="modal" id="poziciaPost" title="Vytvorit pozíciu">
    <!-- zac -->
    <div>
      <form @submit.prevent="Post()" class="container form-inline"><br>
        <div class="mb-2">
          <th>Názov pozície</th>
          <input type="text" class="form-control" id="meno" v-model="position.positionName" placeholder="nazov pozicie"
            required>
        </div>

        <button type="submit" class="btn btn-success btn-square-md float-end m-1" data-bs-dismiss="modal">Vytvoriť</button>

      </form>
    </div>

    <!-- koniec -->
  </b-modal>
</template>
<script lang="ts">
import { defineComponent, PropType } from 'vue';
import api from '../Repository/PositionsRepository';
import ResponseData from '../Models/IResponseData';

export default defineComponent({
    name: "Modal_poz",
    
   data(){
     return {

       position: {
         positionId: 0,
         positionName: "",
       },

     };


   },
   methods: {

        refresh(){
        this.$emit("refresh");
      },

     Post(){
       api.PostData(this.position).then((response: ResponseData) => {
               this.refresh();
               this.position.positionName="";
                console.log(response.data);
            })
                .catch((e: Error) => {
                console.log(e);                  
            });
     }



   }
    

});
</script>