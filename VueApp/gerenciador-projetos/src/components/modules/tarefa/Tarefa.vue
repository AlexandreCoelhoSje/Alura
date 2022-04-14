<script>
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
    data() {
        return {
            filtros: {
                id: this.idAtividadeSelecionada,
                asc: true,
                ordenacao: '',
                descricao: ''
            },
            idAtividadeSelecionada: this.$route.params.atividadeID ? this.$route.params.atividadeID : null,
            lista: []
        };
    },
    created() {

        this.service = new TarefaService(this);
        this.consultar();
    },
    methods: {
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
    },
}
</script>

<template>

    <PaginaListaPadrao :tituloPrincipal="this.tituloPagina">

        <template v-slot:filtro>

            <form @submit.prevent="consultar()">
                <div class="row mb-3">
                    <label for="inputDescricao"
                        class="col-sm-2 col-md-2 col-form-label col-form-label-sm">Descrição</label>
                    <div class="col-sm-8 col-md-4">
                        <input type="text" class="form-control form-control-sm" id="inputDescricao"
                            placeholder="digite parte da descrição" v-model="filtros.descricao" />
                    </div>
                    <div class="col-sm-2 col-md-6">
                        <button type="submit" class="btn btn-primary">Filtrar</button>
                        <router-link class="btn btn-primary ms-1"
                            :to="{ name: 'TarefaNovo', params: { atividadeID: idAtividadeSelecionada } }">Novo
                        </router-link>
                    </div>
                </div>
            </form>
        </template>

        <template v-slot:lista>
            <ExibicaoGrade identificador="tarefaID" :colunas="[
                {
                    nome: 'Ordem',
                    chave: 'ordem',
                    type: String
                },
                {
                    nome: 'Descrição',
                    chave: 'descricao',
                    type: String
                }
            ]" :lista="lista" colunaNomeRegistro="descricao" :habilitarEditar="true" nomeRotaEditar="TarefaEditar"
                :habilitarExcluir="true" @excluir-registro="excluirSelecionar" />
        </template>
    </PaginaListaPadrao>

    <ModalConfirmacao textoTitulo="Confirmar Exclusão!"
        :textoCorpo="'Tem certeza que deseja excluir o registro ' + this.entidadeAlvo.nomeProjeto + '?'"
        textoBotaoLancar="Excluir" textoBotaoConfirmar="Excluir" classeContextoBotaoConfirmar="btn-danger"
        :exibirModal="this.entidadeAlvo.monstrarModalExclusao" @modal-Confirmar="excluirConfirmar"
        @modal-cancelar="excluirCancelar" />
</template>