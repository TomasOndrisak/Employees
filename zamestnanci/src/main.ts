import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import "bootstrap/dist/css/bootstrap.min.css"
import "bootstrap"
import axios from 'axios'
import VueAxios from 'vue-axios'
import {BootstrapVue3} from 'bootstrap-vue-3'
createApp(App).use(store).use(router).use(VueAxios, axios).use(BootstrapVue3).mount('#app')
