<script>
import AtividadeDetalhe from '@/domain/atividade/AtividadeDetalhe'
import AtividadeService from '@/domain/atividade/AtividadeService'
import PaginaFormularioPadraoVue from "@/components/shared/layout/paginaFormularioPadrao.vue";

export default {
    components: {
        PaginaFormularioPadrao: PaginaFormularioPadraoVue
    },
    props: {
        atividadeID: {
            type: Int32Array,
            required: false
        },
        paramExtra: {
            type: String,
            required: false
        }
    },
    data() {
        return {
            tituloPagina: "Planejamento de Tarefas",
            atividade: new AtividadeDetalhe(),
            idAtividadeSelecionada: this.$route.params.id
        };
    },
    created() {

        this.service = new AtividadeService(this);
        this.detalhar();
    },
    methods: {
        detalhar() {

            var vueInstance = this;

            this.service
                .detalha(this.$route.params.id)
                .done(function (retorno) {

                    console.log('AtividadeGerenciarTarefa.detalhar', retorno);
                    vueInstance.atividade.mapear(retorno);
                })
                .fail(function (jqXHR, textStatus) {

                    console.log("AtividadeService.Lista erro " + textStatus);
                    alert('Erro ao Detalhar um Atividade id:' + vueInstance.$route.params.id);
                });
        }
    }
};
</script>

<template>
    <PaginaFormularioPadrao :tituloPrincipal="tituloPagina">
        <template v-slot:formulario>
            {{ 'idAtividadeSelecionada:' + idAtividadeSelecionada }}
            <form>
                <input type="hidden" v-model="atividade.atividadeID" id="atividadeID" />
                <input type="hidden" v-model="atividade.projetoID" id="atividadeID" />

                <div class="row mb-3">
                    <label for="inputDescricao" class="col-sm-2 col-form-label form-control-sm">Código</label>
                    <div class="col-sm-10">
                        <span
                            class="form-control-plaintext form-control-sm"
                            id="inputDescricao"
                            >{{atividade.codigoIdentificador}}</span>
                    </div>
                </div>

                <div class="row mb-3">
                    <label for="inputDescricao" class="col-sm-2 col-form-label">Descrição</label>
                    <div class="col-sm-10">
                        <span
                            type="text"
                            class="form-control-plaintext form-control-sm"
                            id="inputDescricao"
                        >{{atividade.descricao}}</span>
                    </div>
                </div>

                <div class="row mb-3">
                    <label for="inputObservacao" class="col-sm-2 col-form-label">Observacao</label>
                    <div class="col-sm-10">
                        <input
                            type="text"
                            v-model="atividade.observacao"
                            class="form-control form-control-sm"
                            id="inputObservacao"
                        />
                    </div>
                </div>

                <div class="row mb-3">
                    <label
                        for="inputNumeroOrdenacao"
                        class="col-sm-2 col-form-label"
                    >Numero Ordenação</label>
                    <div class="col-sm-10">
                        <input
                            type="number"
                            v-model="atividade.numeroOrdenacao"
                            class="form-control form-control-sm"
                            id="inputNumeroOrdenacao"
                        />
                    </div>
                </div>

                <div class="row mb-3">
                    <label for="inputValoresEsforco" class="col-sm-2 col-form-label">Valores Esforco</label>
                    <div class="col-sm-10">
                        <input
                            type="text"
                            v-model="atividade.valoresEsforco"
                            class="form-control form-control-sm"
                            id="inputValoresEsforco"
                        />
                    </div>
                </div>

                <div class="row mb-3">
                    <label
                        for="inputEsforcoEstimado"
                        class="col-sm-2 col-form-label"
                    >Esforço Estimado</label>
                    <div class="col-sm-10">
                        <input
                            type="text"
                            v-model="atividade.esforcoEstimado"
                            class="form-control form-control-sm"
                            id="inputEsforcoEstimado"
                        />
                    </div>
                </div>

                <div class="row mb-3">
                    <label for="inputEsforcoReal" class="col-sm-2 col-form-label">Esforço Real</label>
                    <div class="col-sm-10">
                        <input
                            type="text"
                            v-model="atividade.esforcoReal"
                            class="form-control form-control-sm"
                            id="inputEsforcoReal"
                        />
                    </div>
                </div>

                <!-- <div class="row mb-3">
                    <label
                        for="inputSituacaoProjeto"
                        class="col-sm-2 col-form-label"
                    >Situação Projeto</label>
                    <div class="col-sm-10">
                        <select
                            v-model="atividade.situacaoatividade"
                            class="form-select"
                            id="inputSituacaoProjeto"
                        >
                            <option :value="1">Aberto</option>
                            <option :value="2">Em Andamento</option>
                            <option :value="3">Finalizado</option>
                        </select>
                    </div>
                </div>-->

                <div class="d-grid gap-2 d-flex justify-content-center">
                    <button
                        v-if="this.modoNovo"
                        v-on:click="cadastrar()"
                        type="button"
                        class="btn btn-primary"
                    >Incluir</button>
                    <button
                        v-if="!this.modoNovo"
                        v-on:click="this.alterar()"
                        type="button"
                        class="btn btn-primary"
                    >Alterar</button>
                    <router-link
                        class="btn btn-secondary"
                        :to="{ name: 'Atividade', params: { projetoID: idProjetoSelecionado } }"
                    >Voltar</router-link>
                </div>
            </form>
        </template>
    </PaginaFormularioPadrao>
</template>

<style scoped>
</style>