import { createApp } from 'vue'
import jquery from 'jquery'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap'

import router from './router'
import constHttp from './constants/http'
import data from './util/data'
import App from './App.vue'


const vueApp = createApp(App);

vueApp.use(router);
vueApp.use({
    install: (app, options) => {
        app.config.globalProperties.$jquery = jquery;
    }
});
vueApp.use({
    install: (app, options) => {
        app.config.globalProperties.$constHttp = constHttp;
    }
});
vueApp.use({
    install: (app, options) => {
        app.config.globalProperties.$util = {};
        app.config.globalProperties.$util.data = data;
    }
});

vueApp.mount('#app');