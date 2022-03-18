<script>
import Atividade from "./../../../domain/atividade/Atividade";
import AtividadeService from "@/domain/atividade/AtividadeService.js";

import ProjetoSelecaoVue from '@/components/modules/projeto/Projeto.vue'

import PaginaListaPadraoVue from "@/components/shared/layout/paginaListaPadrao.vue";
import ExibicaoGradeVue from "@/components/shared/control/exibicaoGrade.vue";
import ModalConfirmacaoVue from '@/components/shared/control/modalConfirmacao.vue';

export default {
    components: {
        PaginaListaPadrao: PaginaListaPadraoVue,
        ExibicaoGrade: ExibicaoGradeVue,
        ModalConfirmacao: ModalConfirmacaoVue,
        ProjetoSelecao: ProjetoSelecaoVue
    },
    data() {
        return {
            tituloPagina: "Atividades",
            tituloPaginaSelecao: "Atividades - <small>selecione um projeto</small>",
            lista: [],
            entidadeAlvo: {
                id: null,
                nome: '',
                monstrarModalExclusao: false
            },
            modo: this.$constModo.selecao(),
            idProjetoSelecionado: null
        };
    },
    created() {

        this.service = new AtividadeService(this);
        this.consultar();
    },
    methods: {
        consultar() {

            var vueInstance = this;

            let atividade = new Atividade();
            atividade.projetoID = idProjetoSelecionado;

            this.service
                .lista(atividade)
                .done(function (listaRetornada) {
                    vueInstance.lista = listaRetornada;
                    console.log("Atividade.consultar sucesso ", listaRetornada);
                })
                .fail(function (jqXHR, textStatus) {
                    console.log("Atividade.consultar erro " + textStatus);
                });
        },
        excluirSelecionar(id, nome) {

            this.entidadeAlvo.monstrarModalExclusao = true;
            this.entidadeAlvo.nome = nome;
            this.entidadeAlvo.id = id;
        },
        excluirCancelar() {

            this.entidadeAlvo.monstrarModalExclusao = false
            this.entidadeAlvo.nome = '';
            this.entidadeAlvo.id = null;
        },
        excluirConfirmar(value) {

            var vueInstance = this;

            this.service
                .apaga(this.entidadeAlvo.id)
                .done(function (atividade) {

                    console.log('Atividade.excluir', atividade);
                    vueInstance.entidadeAlvo.monstrarModalExclusao = false;
                    vueInstance.entidadeAlvo.nome = '';
                    vueInstance.entidadeAlvo.id = null;
                    vueInstance.consultar();
                })
                .fail(function (jqXHR, textStatus) {

                    console.log("Atividade.excluir erro " + textStatus);
                    alert('Erro ao Excluir Atividade id:' + vueInstance.$route.params.id);
                });
        },
        selecione(idProjeto) {

            this.idProjetoSelecionado = idProjeto;
            this.consultar();
        }
    }
}
</script>

<template>
    <ProjetoSelecao
        v-if="this.modo == this.$constModo.selecao()"
        :tituloPagina="this.tituloPaginaSelecao"
        :modoInicial="this.$constModo.selecao()"
        @selecionar-registro="selecione"
    />

    <PaginaListaPadrao
        v-if="this.modo == this.$constModo.consulta()"
        :tituloPrincipal="this.tituloPagina"
    >
        <template v-slot:filtro>
            <form>
                <div class="row mb-3">
                    <label
                        for="inputDescricao"
                        class="col-sm-2 col-md-1 col-form-label col-form-label-sm"
                    >Descrição</label>
                    <div class="col-sm-8 col-md-3">
                        <input
                            type="text"
                            class="form-control form-control-sm"
                            id="inputDescricao"
                            placeholder="digite parte da descrição"
                        />
                    </div>
                    <div class="col-sm-2 col-md-2">
                        <button type="submit" class="btn btn-primary">Filtrar</button>
                        <router-link class="btn btn-primary ms-1" to="/projeto/novo">Novo</router-link>
                    </div>
                </div>
            </form>
        </template>

        <template v-slot:lista>
            <ExibicaoGrade
                identificador="projetoID"
                :colunas="[
                    {
                        nome: '',
                        chave: '',
                        type: ''
                    },
                    {
                        nome: 'Descrição',
                        chave: 'descricao',
                        type: String
                    },
                    {
                        nome: 'Data Inicio',
                        chave: 'dataInicial',
                        type: Date
                    },
                    {
                        nome: 'Situação',
                        chave: 'situacaoProjeto.descricao',
                        type: Object
                    },
                    {
                        nome: 'A Fazer',
                        chave: '',
                        type: ''
                    },
                    {
                        nome: 'Fazendo',
                        chave: '',
                        type: ''
                    },
                    {
                        nome: 'Feitas',
                        chave: '',
                        type: ''
                    }
                ]"
                :lista="projetos"
                :habilitarEditar="true"
                :habilitarExcluir="true"
                nomeRotaEditar="ProjetoEditar"
                colunaNomeRegistro="descricao"
                @excluir-registro="excluirSelecionar"
            />
        </template>
    </PaginaListaPadrao>

    <ModalConfirmacao
        textoTitulo="Confirmar Exclusão!"
        :textoCorpo="'Tem certeza que deseja excluir o registro ' + this.entidadeAlvo.nomeProjeto + '?'"
        textoBotaoLancar="Excluir"
        textoBotaoConfirmar="Excluir"
        classeContextoBotaoConfirmar="btn-danger"
        :exibirModal="this.entidadeAlvo.monstrarModalExclusao"
        @modal-Confirmar="excluirConfirmar"
        @modal-cancelar="excluirCancelar"
    />
</template>