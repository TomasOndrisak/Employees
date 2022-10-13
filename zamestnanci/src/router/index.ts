import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'
import ZamestnanciView from '../views/ZamestnanciView.vue'
import PozicieView from '../views/PozicieView.vue'
import ArchivovanyViewVue from '../views/ArchivovanyView.vue'
const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'zamestnanci',
    component: ZamestnanciView
  },
   {
     path: '/Pozicie',
     name: 'pozicie',
     component: PozicieView
  },
  {
    path: '/Archivovany',
    name: 'archivovany',
    component: ArchivovanyViewVue
  },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
