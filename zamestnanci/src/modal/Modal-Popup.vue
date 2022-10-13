<template>
  <b-modal
    :hide-footer="true"
    class="modal"
    :id="'ModalEmployee' + emp.employeeId"
    title="Employee"
    v-for="emp in Employees"
    v-bind:key="emp.employeeId"
  >
    <h1>
      <p>{{ emp.name }} {{ emp.lastName }}<br /></p>
    </h1>
    <p class="my-4">
      <b>Adress:</b> <a>{{ emp.adress }}</a> <br />
      <b>Position:</b> <a>{{ emp.positions.positionName }}</a
      ><br />
      <b>Salary:</b> <a>12 345 €</a><br />
      <b>Date of Birth:</b> <a>{{ emp.dateOfBirth }}</a
      ><br />
      <b>Date of Entry:</b> <a>{{ emp.dateOfEntry }}</a>
    </p></b-modal
  >
</template>
<script lang="ts">
import { defineComponent, PropType } from "vue";
import Employees from "../Models/IEmployees";
export default defineComponent({
  name: "Modal_pop",

  props: {
    Employees: {
      required: true,
      type: Array as PropType<Employees[]>,
    },
  },
});
</script>