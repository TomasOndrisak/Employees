<template>
  <b-modal
    :hide-footer="true"
    class="modal"
    id="ModalEmployee"
    title="Create"
  >
    <!-- zac -->
    <div>
      <form
        ref="anyName"
        @submit.prevent="Post()"
        class="container form-inline"
      >
        <br />
        <div class="mb-2">
          <th>Name</th>
          <input
            type="text"
            class="form-control"
            id="name"
            v-model="Employee.name"
            placeholder="name"
            required
          />
        </div>
        <th>Surname</th>
        <div class="mb-2">
          <input
            type="text"
            class="form-control"
            id="Surname"
            v-model="Employee.lastName"
            placeholder="Surname"
            required
          />
        </div>
        <th>Adress</th>
        <div class="mb-2">
          <input
            type="text"
            class="form-control"
            id="adress"
            v-model="Employee.adress"
            placeholder="adress"
          />
        </div>
        <th>Date of Birth</th>
        <div class="mb-2">
          <input
            v-model="Employee.dateOfBirth"
            type="date"
            placeholder="Date of Birth"
            required
          />
        </div>
        <th>Date of Entry</th>
        <div class="mb-2">
          <input
            v-model="Employee.dateOfEntry"
            type="date"
            placeholder="Date of Entry"
            required
          />
        </div>
        <th>Positions</th>
        <div class="input-group mb-3">
          <select class="form-select" v-model="Employee.positionId" required>
            <option value="" selected disabled hidden>Position</option>
            <option
              v-for="(pos, index) in positions"
              :key="index"
              placeholder="Positions"
              :value="pos.positionId"
            >
              {{ positions[index].positionName }}
            </option>
          </select>
        </div>

        <button
          type="submit"
          class="close-modal btn btn-success btn-square-md float-end m-1"
        >
          Create
        </button>
      </form>
    </div>
    <!-- koniec -->
  </b-modal>
</template>
<script lang="ts">
import { defineComponent, PropType } from "vue";
import Employees from "../Models/IEmployees";
import Positions from "../Models/IPositions";
import EmployeeRepository from "../Repository/EmployeesRepository";
import PositionsRepository from "../Repository/PositionsRepository";

import ResponseData from "../Models/IResponseData";

export default defineComponent({
  name: "Modal_pop",

  data() {
    return {
      positions: [] as Positions[],

      Employee: {
        employeeId: 0,
        name: "",
        lastName: "",
        adress: "",
        dateOfBirth: "",
        dateOfEntry: "",
        archived: false,
        positionId: "",
      },
    };
  },
  methods: {
    ref() {
      this.$emit("ref");
    },

    get() {
      PositionsRepository.getAll()
        .then((response: ResponseData) => {
          this.positions = response.data;
          console.log(response.data);
        })
        .catch((e: Error) => {
          console.log(e);
        });
    },
    Post() {
      EmployeeRepository.Post(this.Employee)
        .then((response: ResponseData) => {
          console.log(response.data);
          this.ref();
          (this.Employee.name = ""),
            (this.Employee.lastName = ""),
            (this.Employee.adress = ""),
            (this.Employee.dateOfBirth = ""),
            (this.Employee.dateOfEntry = ""),
            (this.Employee.positionId = "");
        })
        .catch((e: Error) => {
          console.log(e);
        });
    },
  },

  mounted() {
    this.get();
  },
});
</script>