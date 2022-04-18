<script>
import AtividadeConsulta from "./../../../domain/atividade/AtividadeConsulta";
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
            idProjetoSelecionado: this.$route.params.projetoID ? this.$route.params.projetoID : null,
            filtros: {
                id: this.idProjetoSelecionado,
                asc: true,
                ordenacao: '',
                descricao: ''
            }
        };
    },
    created() {

        this.service = new AtividadeService(this);

        if (this.idProjetoSelecionado)
            this.consultar();
    },
    methods: {
        consultar() {

            var vueInstance = this;
            this.filtros.id = this.idProjetoSelecionado;
            //this.filtros.ordenacao = 'numeroOrdenacao';

            this.service
                .lista(this.filtros)
                .done(function (listaRetornada) {

                    vueInstance.lista = listaRetornada;
                    vueInstance.modo = vueInstance.$constModo.consulta();
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
        selecionarProjeto(idProjeto) {

            this.idProjetoSelecionado = idProjeto;
            this.consultar();
        },
        trocarProjeto() {

            this.modo = this.$constModo.selecao();
        },
        selecionarAtividade(atividadeID) {

            let projetoID = this.idProjetoSelecionado;
            this.$router.push({ name: 'AtividadeTarefa', params: { id: atividadeID, atividadeID: atividadeID, projetoID: projetoID } });
        }
    }
}
</script>

<template>
    <ProjetoSelecao
        v-if="this.modo == this.$constModo.selecao()"
        :tituloPagina="this.tituloPaginaSelecao"
        :modoInicial="this.$constModo.selecao()"
        @selecionar-registro="selecionarProjeto"
    />

    <PaginaListaPadrao
        v-if="this.modo == this.$constModo.consulta()"
        :tituloPrincipal="this.tituloPagina"
    >
        <template v-slot:filtro>
            <form @submit.prevent="consultar()">
                <div class="row mb-3">
                    <label
                        for="inputDescricao"
                        class="col-sm-2 col-md-2 col-form-label col-form-label-sm"
                    >Descrição</label>
                    <div class="col-sm-8 col-md-4">
                        <input
                            type="text"
                            class="form-control form-control-sm"
                            id="inputDescricao"
                            placeholder="digite parte da descrição"
                            v-model="filtros.descricao"
                        />
                    </div>
                    <div class="col-sm-2 col-md-6">
                        <button type="submit" class="btn btn-primary">Filtrar</button>
                        <router-link
                            class="btn btn-primary ms-1"
                            :to="{ name: 'AtividadeNovo', params: { projetoID: idProjetoSelecionado } }"
                        >Novo</router-link>
                        <button
                            type="button"
                            class="btn btn-outline-primary float-end"
                            v-on:click="trocarProjeto"
                        >Trocar Projeto</button>
                    </div>
                </div>
            </form>
        </template>

        <template v-slot:lista>
            <ExibicaoGrade
                identificador="atividadeID"
                :colunas="[
                    {
                        nome: 'Código',
                        chave: 'codigoIdentificador',
                        type: String
                    },
                    {
                        nome: 'Ordenação',
                        chave: 'numeroOrdenacao',
                        type: String
                    },
                    {
                        nome: 'Descrição',
                        chave: 'descricao',
                        type: String
                    },
                    {
                        nome: 'Esforço Estimado',
                        chave: 'esforcoEstimado',
                        type: String
                    },
                    {
                        nome: 'Esforço Real',
                        chave: 'esforcoReal',
                        type: String
                    }
                ]"
                :lista="lista"
                colunaNomeRegistro="descricao"
                :habilitarEditar="true"
                nomeRotaEditar="AtividadeEditar"
                :habilitarExcluir="true"
                @excluir-registro="excluirSelecionar"
                :habilitarSelecao="true"
                textoOpcaoSelecao="Gerenciar"
                @selecionar-registro="selecionarAtividade"
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