<script>
import AtividadeDetalhe from '@/domain/atividade/AtividadeDetalhe'
import AtividadeService from '@/domain/atividade/AtividadeService'

import TarefaVue from '@/components/modules/tarefa/Tarefa.vue'
import PaginaFormularioPadraoVue from "@/components/shared/layout/paginaFormularioPadrao.vue";

export default {
    components: {
        PaginaFormularioPadrao: PaginaFormularioPadraoVue,
        Tarefa: TarefaVue
    },
    props: {
        atividadeID: {
            type: Int32Array,
            required: false
        },
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
            <form>
                <input type="hidden" v-model="atividade.atividadeID" id="atividadeID" />
                <input type="hidden" v-model="atividade.projetoID" id="projetoID" />

                <div class="row mb-3">
                    <div class="col-sm-1">
                        <span class="form-control-plaintext" id="inputNumeroOrdenacao">Nº {{
                            atividade.numeroOrdenacao
                        }}</span>
                    </div>
                    <div class="col-sm-2">
                        <span class="form-control-plaintext" id="inputDescricao">{{
                            atividade.codigoIdentificador
                        }}</span>
                    </div>
                    <div class="col-sm-7">
                        <span class="form-control-plaintext" id="inputDescricao">{{
                            atividade.descricao
                        }}</span>
                    </div>
                    <div class="col-sm-2">
                        <span class="form-control-plaintext" id="inputEsforcoEstimado">
                            {{ atividade.esforcoEstimado }} / {{ atividade.esforcoReal }}
                        </span>
                    </div>
                </div>

                <Tarefa :atividadeID="atividadeID" ></Tarefa>

                <div class="d-grid gap-2 d-flex justify-content-center">
                    <router-link class="btn btn-secondary"
                        :to="{ name: 'Atividade', params: { projetoID: this.projetoID } }">Voltar</router-link>
                </div>
            </form>
        </template>
    </PaginaFormularioPadrao>
</template>

<style scoped>
</style>