<script>
import ProjetoService from "@/domain/projeto/ProjetoService";
import PaginaListaPadraoVue from "@/components/shared/layout/paginaListaPadrao.vue";
import ExibicaoGradeVue from "@/components/shared/control/exibicaoGrade.vue";

export default {
    components: {
        PaginaListaPadrao: PaginaListaPadraoVue,
        ExibicaoGrade: ExibicaoGradeVue
    },
    data() {
        return {
            tituloPagina: "Projetos",
            projetos: []
        };
    },
    created() {

        var self = this;
        this.service = new ProjetoService(this);

        this.service
            .lista({})
            .done(function (projetos) {
                self.projetos = projetos;
                console.log("ProjetoService.Lista sucesso ", projetos);
            })
            .fail(function (jqXHR, textStatus) {
                console.log("ProjetoService.Lista erro " + textStatus);
            });
    }
};
</script>

<template>
    <PaginaListaPadrao :tituloPrincipal="this.tituloPagina">
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
                nomeRotaEditar="ProjetoEditar"
            />
        </template>
    </PaginaListaPadrao>
</template>

<style scoped>
.icone-proj {
    width: 30px;
}
</style>
