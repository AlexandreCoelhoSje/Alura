import { createWebHistory, createRouter } from 'vue-router';

//Importa o Modulo
import Dashborad from './components/modules/DashboardPrincipal.vue'
import Projeto from './components/modules/projeto/Projeto.vue'
import ProjetoFormulario from './components/modules/projeto/ProjetoFormulario.vue'
import Atividade from './components/modules/atividade/Atividade.vue'
import AtividadeFormulario from './components/modules/atividade/AtividadeFormulario.vue'
import AtividadeGerenciarTarefa from './components/modules/atividade/AtividadeGerenciarTarefa.vue'
import Tarefa from './components/modules/tarefa/Tarefa.vue'
import TarefaFormulario from './components/modules/tarefa/TarefaFormulario.vue'

//Cria as rotas
const routes = [
    { path: '/', name: 'Inicio', component: Dashborad },
    
    { path: '/projeto', name: 'Projeto', component: Projeto },
    { path: '/projeto/novo', name: 'ProjetoNovo', component: ProjetoFormulario },
    { path: '/projeto/editar/:id', name: 'ProjetoEditar', component: ProjetoFormulario },
    
    { path: '/atividade', name: 'Atividade', component: Atividade },
    { path: '/atividade/novo', name: 'AtividadeNovo', component: AtividadeFormulario, props: (route) => ({...route.params }) },
    { path: '/atividade/editar/:id', name: 'AtividadeEditar', component: AtividadeFormulario, props: (route) => ({...route.params }) },
    { path: '/atividade/tarefa/:id', name: 'AtividadeTarefa', component: AtividadeGerenciarTarefa, props: (route) => ({...route.params }) },

    { path: '/tarefa', name: 'Tarefa', component: Tarefa },
    { path: '/tarefa/novo', name: 'TarefaNovo', component: TarefaFormulario, props: (route) => ({...route.params }) },
    { path: '/tarefa/editar/:id', name: 'TarefaEditar', component: TarefaFormulario, props: (route) => ({...route.params }) }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;