<script>
import AtividadeDetalhe from '@/domain/atividade/AtividadeDetalhe'
import AtividadeService from '@/domain/atividade/AtividadeService'
import PaginaFormularioPadraoVue from "@/components/shared/layout/paginaFormularioPadrao.vue";

export default {
    components: {
        PaginaFormularioPadrao: PaginaFormularioPadraoVue
    },
    props: {
        projetoID: {
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
            tituloPagina: "Atividades",
            modoNovo: this.$route.params.id ? false : true,
            atividade: new AtividadeDetalhe()
        };
    },
    computed: {
        idProjetoSelecionado() {
            if (this.projetoID)
                return this.projetoID;
            else if (this.paramExtra)
                return JSON.parse(this.$route.params.paramExtra).projetoID;
        }
    },
    created() {

        this.service = new AtividadeService(this);

        if (!this.modoNovo) {
            this.detalhar();
        }
    },
    methods: {
        alterar() {

            var vueInstance = this;

            this.service
                .altera(this.atividade)
                .done(function (retorno) {

                    console.log("AtividadeFormulario.alterar sucesso ", retorno);
                    vueInstance.$router.push({ name: 'Atividade', params: { projetoID: vueInstance.idProjetoSelecionado } });
                })
                .fail(function (jqXHR, textStatus) {

                    console.log("AtividadeFormulario.alterar erro " + textStatus);
                });
        },
        detalhar() {

            var vueInstance = this;

            this.service
                .detalha(this.$route.params.id)
                .done(function (retorno) {

                    console.log('AtividadeFormulario.detalhar', retorno);
                    vueInstance.atividade.mapear(retorno);
                })
                .fail(function (jqXHR, textStatus) {

                    console.log("AtividadeService.Lista erro " + textStatus);
                    alert('Erro ao Detalhar um Atividade id:' + vueInstance.$route.params.id);
                });
        },
        cadastrar() {

            var vueInstance = this;
            this.atividade.projetoID = this.idProjetoSelecionado;
            console.log('atividade incluir: ', this.atividade);

            this.service
                .cadastra(this.atividade)
                .done(function (atividade) {

                    console.log("AtividadeFormulario.cadastrar sucesso ", atividade);
                    vueInstance.$router.push({ name: 'Atividade', params: { projetoID: vueInstance.idProjetoSelecionado } });
                })
                .fail(function (jqXHR, textStatus) {

                    console.log("AtividadeFormulario.cadastrar erro " + textStatus);
                });
        }
    }
};
</script>

<template>
    <PaginaFormularioPadrao :tituloPrincipal="tituloPagina">
        <template v-slot:formulario>
            <form>
                <input type="hidden" v-model="atividade.atividadeID" id="atividadeID" />
                <input type="hidden" v-model="atividade.projetoID" id="atividadeID" />

                <div class="row mb-3">
                    <label for="inputDescricao" class="col-sm-2 col-form-label">Código Identificador</label>
                    <div class="col-sm-10">
                        <input
                            type="text"
                            v-model="atividade.codigoIdentificador"
                            class="form-control form-control-sm"
                            id="inputDescricao"
                        />
                    </div>
                </div>

                <div class="row mb-3">
                    <label for="inputDescricao" class="col-sm-2 col-form-label">Descrição</label>
                    <div class="col-sm-10">
                        <input
                            type="text"
                            v-model="atividade.descricao"
                            class="form-control form-control-sm"
                            id="inputDescricao"
                        />
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