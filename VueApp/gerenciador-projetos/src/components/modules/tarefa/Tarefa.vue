<script>
import { Modal } from "bootstrap";

import Tarefa from "../../../domain/tarefa/Tarefa";
import TarefaService from "@/domain/tarefa/TarefaService";

import PaginaListaPadraoVue from "@/components/shared/layout/paginaListaPadrao.vue";
import ExibicaoGradeVue from "@/components/shared/control/exibicaoGrade.vue";
import ModalConfirmacaoVue from "@/components/shared/control/modalConfirmacao.vue";

import ExibicaoGradeV2Vue from "@/components/shared/control/exibicaoGradeV2.vue";

export default {
    components: {
        PaginaListaPadrao: PaginaListaPadraoVue,
        ExibicaoGrade: ExibicaoGradeVue,
        ModalConfirmacao: ModalConfirmacaoVue,
        ExibicaoGradeV2: ExibicaoGradeV2Vue
    },
    data() {
        return {
            filtros: {
                id: null,
                asc: true,
                ordenacao: "",
                descricao: "",
            },
            lista: [],
            idModalFormulario: "modalFormulario",
            modalFormulario: null,
            idModalExcluir: "modalExcluir",
            modalExcluir: null,
            tarefa: new Tarefa(),
            modoNovo: false,
            atividadeID: this.$route.params.id
        };
    },
    created() {
        this.service = new TarefaService(this);
        this.consultar();
    },
    mounted() {
        
        this.modalFormulario = new Modal(
            document.getElementById(this.idModalFormulario),
            { backdrop: "static" }
        );
    },
    methods: {
        cancelarModal(modal) {

            this.modoNovo = false;
            //modal.hide();
        },
        novo() {

            this.modoNovo = true;
            this.tarefa = new Tarefa();            
            this.modalFormulario.show();
        },
        gravar() {

            var vueInstance = this;
            this.tarefa.atividadeID = this.atividadeID;

            console.log('tarefa incluir: ', this.tarefa);

            this.service
                .cadastra(this.tarefa)
                .done(function (tarefa) {

                    vueInstance.modoNovo = false;
                    vueInstance.modalFormulario.hide();
                    vueInstance.consultar();
                    console.log("tarefaFormulario.cadastrar sucesso ", tarefa);                    
                })
                .fail(function (jqXHR, textStatus) {

                    console.log("AtividadeFormulario.cadastrar erro " + textStatus);
                });            
        },
        editar(tarefaID) {

            this.modoNovo = false;
            this.tarefa = new Tarefa();

            var vueInstance = this;

            this.service
                .detalha(tarefaID)
                .done(function (retorno) {

                    console.log('tarefaFormulario.detalhar', retorno);
                    vueInstance.tarefa.mapear(retorno);
                    vueInstance.modalFormulario.show();
                })
                .fail(function (jqXHR, textStatus) {

                    console.log("tarefa.Lista erro " + textStatus);
                    alert('Erro ao Detalhar um Atividade id:' + vueInstance.$route.params.id);
                });
        },
        salvar() {

            var vueInstance = this;

            this.tarefa.id = this.tarefa.tarefaID;

            this.service
                .altera(this.tarefa)
                .done(function (retorno) {

                    console.log("tarefaFormulario.alterar sucesso ", retorno);
                    vueInstance.modalFormulario.hide();
                    vueInstance.consultar();
                })
                .fail(function (jqXHR, textStatus) {

                    console.log("AtividadeFormulario.alterar erro " + textStatus);
                });
        },
        consultar() {
            var vueInstance = this;
            this.filtros.id = this.atividadeID;

            this.service
                .lista(this.filtros)
                .done(function (listaRetornada) {
                    vueInstance.lista = listaRetornada;
                    console.log("Tarefa.consultar sucesso ", listaRetornada);
                })
                .fail(function (jqXHR, textStatus) {
                    console.log("Tarefa.consultar erro " + textStatus);
                });
        },
        excluir(tarefaID) {

            this.modoNovo = false;

            var vueInstance = this;

            this.service
                .apaga(this.tarefa.tarefaID)
                .done(function (retorno) {

                    console.log('tarefaFormulario.excluir', retorno);
                    vueInstance.modalFormulario.hide();
                    vueInstance.consultar();
                })
                .fail(function (jqXHR, textStatus) {

                    console.log("tarefa.Lista erro " + textStatus);
                    alert('Erro ao Detalhar um excluir id:' + vueInstance.$route.params.id);
                });
        }
    },
};
</script>

<template>
    <div class="border-top border-bottom mb-1 border-2 border-dark bg-light" style="height: 60vh">
        <table class="table mb-0">
            <thead class="table-light">
                <tr>
                    <th scope="col">#</th>
                    <th scope="col">Descrição</th>
                    <th class="text-end">
                        <button type="button" class="btn btn-outline-secondary ml-auto rounded-0" v-on:click="novo">
                            Adicionar
                        </button>
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="item in lista" :key="item.tarefaID">
                    <th scope="row">{{ item.ordem }}</th>
                    <td class="w-100">{{ item.descricao }}</td>
                    <td class="text-end pe-2">                        
                        <button type="button" class="btn btn-sm btn-outline-primary rounded-0" v-on:click="editar(item.tarefaID);">
                            Edi.
                        </button>
                    </td>
                </tr>
            </tbody>
        </table>

        <br><br><br>
        <h1>Segunda</h1>

        <ExibicaoGradeV2 :lista="lista">
            <template v-slot:filtros>
            <th scope="col">#</th>
            <th scope="col">Descrição</th>
            <th class="text-end">
                <button type="button" class="btn btn-outline-secondary ml-auto rounded-0" v-on:click="novo">
                    Adicionar
                </button>
            </th>
        </template>

        <template v-slot:colunas>
            <th scope="row">{{ colunas.item.ordem }}</th>
            <td class="w-100">{{ colunas.item.descricao }}</td>
            <td class="text-end pe-2">
                <button type="button" class="btn btn-sm btn-outline-primary rounded-0"
                    v-on:click="editar(colunas.item.tarefaID);">
                    Edi.
                </button>
            </td>
        </template>
        </ExibicaoGradeV2>
    </div>

    <!-- Modal -->
    <div :id="idModalFormulario" class="modal fade" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <form>
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Tarefa - nova</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"
                            v-on:click="cancelarModal(this.idModalFormulario)"></button>
                    </div>
                    <div class="modal-body">
                        <input type="hidden" v-model="tarefa.atividadeID" id="atividadeID" />
                        <input type="hidden" v-model="tarefa.tarefaID" id="tarefaID" />

                        <div class="row mb-3">
                            <label for="inputDescricao" class="col-sm-2 col-form-label">Descrição</label>
                            <div class="col-sm-10">
                                <input type="text" v-model="tarefa.descricao" class="form-control form-control-sm"
                                    id="inputDescricao" />
                            </div>
                        </div>

                        <div class="row mb-3">
                            <label for="inputNumeroOrdenacao" class="col-sm-2 col-form-label">Numero Ordenação</label>
                            <div class="col-sm-10">
                                <input type="number" v-model="tarefa.ordem"
                                    class="form-control form-control-sm" id="inputNumeroOrdenacao" />
                            </div>
                        </div>
                    </div>

                    <div class="modal-footer">
                        <div class="d-grid gap-2 d-flex justify-content-center">
                            <button v-if="this.modoNovo" v-on:click="gravar()" type="button" class="btn btn-primary">
                                Incluir
                            </button>

                            <button v-if="!this.modoNovo" v-on:click="excluir" type="button"
                                class="btn btn-danger">
                                Excluir
                            </button>

                            <button v-if="!this.modoNovo" v-on:click="salvar" type="button"
                                class="btn btn-primary">
                                Alterar
                            </button>

                            <button @click="cancelarModal(this.idModalFormulario)" type="button"
                                class="btn btn-secondary" data-bs-dismiss="modal">
                                Fechar
                            </button>
                        </div>
                    </div>

                </form>
            </div>
        </div>
    </div>
</template>