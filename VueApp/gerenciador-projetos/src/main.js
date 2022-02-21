import { createApp } from 'vue'
import router from './router'
import jquery from 'jquery'

import App from './App.vue'
import Projeto from './components/projeto/Projeto.vue'

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap'


const vueApp = createApp(App);
vueApp.use(router);
vueApp.use({
    install: (app, options) => {
        app.config.globalProperties.$jquery = jquery;
    }
})
vueApp.mount('#app');