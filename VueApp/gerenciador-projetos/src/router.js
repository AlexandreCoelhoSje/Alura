import { createWebHistory, createRouter } from 'vue-router';

//Importa o Modulo
import Dashborad from './components/modules/DashboardPrincipal.vue'
import Projeto from './components/modules/projeto/Projeto.vue'
import ProjetoDados from './components/modules/projeto/ProjetoDados.vue'

//Cria as rotas
const routes = [
    { path: '/', name: 'Inicio', component: Dashborad },
    { path: '/projeto', name: 'Projeto', component: Projeto },
    { path: '/projeto/novo', name: 'ProjetoNovo', component: ProjetoDados },
    { path: '/projeto/editar/:id', name: 'ProjetoEditar', component: ProjetoDados }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;