<template>
  <div class="container col-5">
    <br /><br /><br /><br />
    <div class="Pozicie">
      <button
        v-b-modal="'ModalPosition'"
        class="btn btn-secondary btn-square-md float-end"
      >
        Create position
      </button>
      <table class="table">
        <thead class="thead-light">
          <tr>
            <th scope="col">Position name</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="position in positions" :key="position.positionId">
            <td>{{ position.positionName }}</td>

            <th></th>
            <td>
              <button
                type="button"
                class="btn btn-danger"
                v-on:click="Delete(position.positionId)"
              >
                Delete
              </button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <Modal_Position @refresh="Get"/>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import Positions from "../Models/IPositions";
import ResponseData from "../Models/IResponseData";
import PositionsRepository from "../Repository/PositionsRepository";
import Modal_Position from "../modal/Modal-Position.vue";

export default defineComponent({
  components: {
    Modal_Position: Modal_Position,
  },

  data() {
    return {
      positions: [] as Positions[],
    };
  },

  methods: {
    Get() {
      PositionsRepository.getAll()
        .then((response: ResponseData) => {
          this.positions = response.data;
          console.log(response.data);
        })
        .catch((e: Error) => {
          confirm("Server is offline");
          console.log(e);
        });
    },

    Delete(positionId: number) {
      if (confirm("Do you want permanently delete this position?")) {
        PositionsRepository.delete(positionId)
          .then((response: ResponseData) => {
            console.log(response.data);
            this.Get();
          })
          .catch((e: Error) => {
            confirm(
              "You can't delte this position. The position is assigned to an employee."
            );
            console.log(e);
          });
      }
    },
  },

  mounted() {
    this.Get();
  },
});
</script>

