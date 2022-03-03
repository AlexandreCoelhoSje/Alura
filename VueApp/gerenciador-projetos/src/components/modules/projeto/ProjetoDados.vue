<script>
import ProjetoService from '@/domain/projeto/ProjetoService'
import Projeto from '@/domain/projeto/Projeto'
import PaginaFormularioPadraoVue from "@/components/shared/layout/paginaFormularioPadrao.vue";

export default {
    components: {
        PaginaFormularioPadrao: PaginaFormularioPadraoVue
    },
    data() {
        return {
            tituloPagina: "Projetos",
            modoNovo: this.$route.params.id ? false : true,
            projeto: new Projeto()
        };
    },
    created() {
        //Detalha Projeto
        if (!this.modoNovo) {

            this.service = new ProjetoService(this.$jquery);
            this.service.detalha(this.$route.params.id, (retorno) => {

                this.projeto.projetoDTO(retorno);
                console.log('Projeto detalhado', retorno);
            }, () => {
                alert('Erro ao Detalhar um Projeto id:' + this.$route.params.id);
            });
        }
    },
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
                            class="form-control"
                            id="inputDescricao"
                        />
                    </div>
                </div>

                <div class="row mb-3">
                    <label for="inputDataInicial" class="col-sm-2 col-form-label">Data Inicial</label>
                    <div class="col-sm-10">
                        <input
                            type="text"
                            v-model="projeto.dataInicial"
                            class="form-control"
                            id="inputDataInicial"
                        />
                    </div>
                </div>

                <div class="row mb-3">
                    <label for="inputDataFinal" class="col-sm-2 col-form-label">Data Final</label>
                    <div class="col-sm-10">
                        <input
                            type="text"
                            v-model="projeto.dataFinal"
                            class="form-control"
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
                        <select class="form-select" id="inputSituacaoProjeto">
                            <option value="1">Inativo</option>
                            <option value="2">Ativo</option>
                        </select>
                    </div>
                </div>

                <div class="row mb-3">
                    <label for="inputResumo" class="col-sm-2 col-form-label">Resumo</label>
                    <div class="col-sm-10">
                        <textarea class="form-control" id="inputResumo"></textarea>
                    </div>
                </div>

                <div class="d-grid gap-2 d-flex justify-content-center">
                    <button type="button" class="btn btn-primary">Gravar</button>
                    <router-link class="btn btn-secondary" :to="{ name: 'Projeto' }">Voltar</router-link>
                </div>
            </form>
        </template>
    </PaginaFormularioPadrao>
</template>

<style scoped>
</style>
