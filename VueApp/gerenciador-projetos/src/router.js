import { createWebHistory, createRouter } from 'vue-router';

//Importa o Modulo
import Dashborad from './components/modules/DashboardPrincipal.vue'
import Projeto from './components/modules/projeto/Projeto.vue'
import ProjetoFormulario from './components/modules/projeto/ProjetoFormulario.vue'
import Atividade from './components/modules/atividade/Atividade.vue'
import AtividadeFormulario from './components/modules/atividade/AtividadeFormulario.vue'

//Cria as rotas
const routes = [
    { path: '/', name: 'Inicio', component: Dashborad },
    { path: '/projeto', name: 'Projeto', component: Projeto },
    { path: '/projeto/novo', name: 'ProjetoNovo', component: ProjetoFormulario },
    { path: '/projeto/editar/:id', name: 'ProjetoEditar', component: ProjetoFormulario },
    { path: '/atividade', name: 'Atividade', component: Atividade },
    { path: '/atividade/novo', name: 'AtividadeNovo', component: AtividadeFormulario, props: (route) => ({...route.params }) },
    { path: '/atividade/editar/:id', name: 'ProjetoEditar', component: AtividadeFormulario }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;