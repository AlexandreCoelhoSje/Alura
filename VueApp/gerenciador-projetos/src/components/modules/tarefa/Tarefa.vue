<script>
import { Modal } from 'bootstrap';

import Tarefa from "../../../domain/tarefa/Tarefa";
import TarefaService from "@/domain/tarefa/TarefaService";

import PaginaListaPadraoVue from "@/components/shared/layout/paginaListaPadrao.vue";
import ExibicaoGradeVue from "@/components/shared/control/exibicaoGrade.vue";
import ModalConfirmacaoVue from '@/components/shared/control/modalConfirmacao.vue';


export default {
    components: {
        PaginaListaPadrao: PaginaListaPadraoVue,
        ExibicaoGrade: ExibicaoGradeVue,
        ModalConfirmacao: ModalConfirmacaoVue
    },
    props: {
        atividadeID: {
            type: String,
            required: false
        }
    },
    data() {
        return {
            filtros: {
                id: null,
                asc: true,
                ordenacao: '',
                descricao: ''
            },
            idAtividadeSelecionada: this.atividadeID,
            lista: [],
            idModalFormulario: 'modalFormulario',
            modalFormulario: null,
            idModalExcluir: 'modalExcluir',
            modalExcluir: null
        };
    },
    created() {

        this.service = new TarefaService(this);
        this.consultar();
    },
    methods: {
        cancelarModal(modal) {
            
            modal.hide();
        },
        novo() {

            this.modalFormulario = new Modal(document.getElementById(this.idModalFormulario), { backdrop: 'static'});
            this.modalFormulario.show();
        },
        gravar() {

            this.modalFormulario.hide();
        },
        consultar() {
            var vueInstance = this;
            this.filtros.id = this.idAtividadeSelecionada;

            this.service
                .lista(this.filtros)
                .done(function (listaRetornada) {

                    vueInstance.lista = listaRetornada;
                    console.log("Tarefa.consultar sucesso ", listaRetornada);
                })
                .fail(function (jqXHR, textStatus) {

                    console.log("Tarefa.consultar erro " + textStatus);
                });
        }        
    }
}
</script>

<template>

    <div class="border-top border-bottom mb-1 border-2 border-dark bg-light" style="height: 60vh;">
        <table class="table mb-0">
            <thead class="table-light">
                <tr>
                    <th scope="col">#</th>
                    <th scope="col">Descrição</th>
                    <th class="text-end">
                        <button type="button" class="btn btn-outline-secondary ml-auto rounded-0" v-on:click="novo">Adicionar</button>
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="item in lista" :key="item.tarefaID">
                    <th scope="row">1</th>
                    <td>{{ item.descricao }}</td>
                    <td></td>
                </tr>               
            </tbody>
        </table>
    </div>

    <!-- Modal -->
    <div :id="idModalFormulario" class="modal fade" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Tarefa - nova</h5>
                    <button
                        type="button"
                        class="btn-close"
                        data-bs-dismiss="modal"
                        aria-label="Close"
                        v-on:click="cancelarModal(this.idModalFormulario);"
                    ></button>
                </div>
                <div class="modal-body">{{ textoCorpo }}</div>
                <div class="modal-footer">
                    <button @click="$emit('modalCancelar', parametroEvento);" type="button" class="btn btn-secondary" data-bs-dismiss="modal">Fechar</button>
                    <button
                        type="button"
                        :class="'btn ' + classeContextoBotaoConfirmar"
                        @click="$emit('modalConfirmar', parametroEvento);"
                    >{{ textoBotaoConfirmar }}</button>
                </div>
            </div>
        </div>
    </div>

</template>