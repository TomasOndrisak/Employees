<template>
  <br />
  <div class="container">
    <br /><br /><br />
    <button
      v-b-modal="'ModalEmployee'"
      class="btn btn-secondary btn-square-md float-end"
    >
      Add new employee
    </button>
    <table class="table">
      <thead class="thead-light">
        <tr>
          <th scope="col">Name Surname</th>
          <th scope="col">Position</th>
          <th scope="col"></th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(emp, index) in employees" v-bind:key="index">
          <td>
            <a v-b-modal="'ModalEmployee' + emp.employeeId"
              >{{ emp.name }} {{ emp.lastName }}</a
            >
          </td>
          <td>{{ emp.positions.positionName }}</td>
          <td>
            <button
              v-b-modal="'ModalEditEmployee'"
              v-on:click="SetEmployee(emp.employeeId)"
              class="btn btn-warning"
            >
              Edit
            </button>
          </td>

          <td>
            <button
              type="button"
              class="btn btn-danger"
              v-on:click="Delete(emp.employeeId)"
            >
              Delete
            </button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>

  <Modal_edit @refresh="Get" :employee="employee" />
  <Modal_post @ref="Get" :zamestnanci="employees" />
  <Modal_pop :Employees="employees" />
</template>

<script lang="ts">
import { defineComponent } from "vue";
import IEmployees from "../Models/IEmployees";
import ResponseData from "../Models/IResponseData";
import EmployeeRepository from "../Repository/EmployeesRepository";
import Modal_pop from "../modal/Modal-Popup.vue";
import Modal_post from "../modal/Modal-PutPost.vue";
import Modal_edit from "../modal/Modal-edit.vue";

export default defineComponent({
  name: "Zamestnanci-list",

  components: {
    Modal_pop,
    Modal_post,
    Modal_edit,
  },
  data() {
    return {
      employees: [] as IEmployees[],
      employee: {} as any,
    };
  },
  methods: {
    Get() {
      EmployeeRepository.getAll()
        .then((response: ResponseData) => {
          this.employees = response.data;

          console.log(response.data);
        })
        .catch((e: Error) => {
          console.log(e);
        });
    },

    SetEmployee(id: number) {
      this.employee = this.employees.find((emp) => emp.employeeId === id);
    },

    async GetId(id: any) {
      await EmployeeRepository.getId(id)
        .then((response: ResponseData) => {
          this.employees = response.data;
          console.log(response.data);
        })
        .catch((e: Error) => {
          console.log(e);
        });
    },

    Delete(employeeId: number) {
      if (confirm("Do you want to archive the employee?")) {
        EmployeeRepository.getId(employeeId)
          .then((response: ResponseData) => {
            console.log(response.data);

            EmployeeRepository.archive(employeeId, response.data).then(
              (ResponseData) => {
                console.log(console.error(ResponseData));
                this.Get();
              }
            );
          })
          .catch((e: Error) => {
            return console.log(e);
          });
      } else if (confirm("Do you want to permanently delete the employee?")) {
        EmployeeRepository.delete(employeeId)
          .then((ResponseData) => {
            console.log(ResponseData);
            this.Get();
          })
          .catch((e: Error) => {
            console.log(e);
          });
      }
    },
  },

  created() {
    this.Get();
  },
});
</script>
     