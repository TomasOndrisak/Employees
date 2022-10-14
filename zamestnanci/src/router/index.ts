import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'
import EmployeesView from '../views/EmployeesView.vue'
import PositionsView from '../views/PositionsView.vue'
import ArchivedEmployeesViewVue from '../views/ArchivedEmployeesView.vue'
const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'employees',
    component: EmployeesView
  },
   {
     path: '/positions',
     name: 'positions',
     component: PositionsView
  },
  {
    path: '/archived',
    name: 'archived',
    component: ArchivedEmployeesViewVue
  },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
