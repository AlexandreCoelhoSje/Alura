<script>
import ProjetoDetalhe from '@/domain/projeto/ProjetoDetalhe'
import ProjetoService from '@/domain/projeto/ProjetoService'
import PaginaFormularioPadraoVue from "@/components/shared/layout/paginaFormularioPadrao.vue";

export default {
    components: {
        PaginaFormularioPadrao: PaginaFormularioPadraoVue
    },
    data() {
        return {
            tituloPagina: "Projetos",
            modoNovo: this.$route.params.id ? false : true,
            projeto: new ProjetoDetalhe()
        };
    },
    created() {

        this.service = new ProjetoService(this);

        //Detalha Projeto
        if (!this.modoNovo)
            this.detalhar();
    },
    methods: {
        alterar() {

            var vueInstance = this;

            this.service
                .altera(this.projeto)
                .done(function (retorno) {
                  
                    console.log("ProjetoFormulario.alterar sucesso ", retorno);
                    vueInstance.$router.push({ name: 'Projeto' });
                })
                .fail(function (jqXHR, textStatus) {

                    console.log("ProjetoFormulario.alterar erro " + textStatus);
                });
        },
        detalhar() {

            var vueInstance = this;

            this.service
                .detalha(this.$route.params.id)
                .done(function (projeto) {

                    console.log('ProjetoFormulario.detalhar', projeto);
                    vueInstance.projeto.mapear(projeto);
                })
                .fail(function (jqXHR, textStatus) {

                    console.log("ProjetoService.Lista erro " + textStatus);
                    alert('Erro ao Detalhar um Projeto id:' + vueInstance.$route.params.id);
                });
        },
        cadastrar() {

            var vueInstance = this;

            this.service
                .cadastra(this.projeto)
                .done(function (projeto) {

                    console.log("ProjetoFormulario.cadastrar sucesso ", projeto);
                    vueInstance.$router.push({ name: 'Projeto' });
                })
                .fail(function (jqXHR, textStatus) {

                    console.log("ProjetoFormulario.cadastrar erro " + textStatus);
                });
        }
    }
};
</script>

<template>
    <PaginaFormularioPadrao :tituloPrincipal="tituloPagina">
        <template v-slot:formulario>
            <form>
                <input type="hidden" v-model="projeto.projetoID" id="projetoID" />

                <div class="row mb-3">
                    <label for="inputDescricao" class="col-sm-2 col-form-label">Descrição</label>
                    <div class="col-sm-10">
                        <input
                            type="text"
                            v-model="projeto.descricao"
                            class="form-control form-control-sm"
                            id="inputDescricao"
                        />
                    </div>
                </div>

                <div class="row mb-3">
                    <label for="inputDataInicial" class="col-sm-2 col-form-label">Data Inicial</label>
                    <div class="col-sm-4">
                        <input
                            type="date"
                            v-model="projeto.dataInicial"
                            class="form-control form-control-sm"
                            id="inputDataInicial"
                        />
                    </div>
                    <label for="inputDataFinal" class="col-sm-2 col-form-label">Data Final</label>
                    <div class="col-sm-4">
                        <input
                            type="date"
                            v-model="projeto.dataFinal"
                            class="form-control form-control-sm"
                            id="inputDataFinal"
                        />
                    </div>
                </div>

                <div class="row mb-3">
                    <label
                        for="inputSituacaoProjeto"
                        class="col-sm-2 col-form-label"
                    >Situação Projeto</label>
                    <div class="col-sm-10">
                        <select
                            v-model="projeto.situacaoProjeto.situacaoProjetoID"
                            class="form-select"
                            id="inputSituacaoProjeto"
                        >
                            <option :value="1">Aberto</option>
                            <option :value="2">Em Andamento</option>
                            <option :value="3">Finalizado</option>
                        </select>
                    </div>
                </div>

                <div class="row mb-3">
                    <label for="inputResumo" class="col-sm-2 col-form-label">Resumo</label>
                    <div class="col-sm-10">
                        <textarea
                            v-model="projeto.resumo"
                            class="form-control form-control-sm"
                            id="inputResumo"
                        ></textarea>
                    </div>
                </div>

                <div class="d-grid gap-2 d-flex justify-content-center">
                    <button
                        v-if="this.modoNovo"
                        v-on:click="this.cadastrar()"
                        type="button"
                        class="btn btn-primary"
                    >Incluir</button>
                    <button
                        v-if="!this.modoNovo"
                        v-on:click="this.alterar()"
                        type="button"
                        class="btn btn-primary"
                    >Alterar</button>
                    <router-link class="btn btn-secondary" :to="{ name: 'Projeto' }">Voltar</router-link>
                </div>
            </form>
        </template>
    </PaginaFormularioPadrao>
</template>

<style scoped>
</style>
