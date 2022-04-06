<script>
import ProjetoConsulta from "../../../domain/projeto/ProjetoConsulta";
import ProjetoService from "@/domain/projeto/ProjetoService";

import PaginaListaPadraoVue from "@/components/shared/layout/paginaListaPadrao.vue";
import ExibicaoGradeVue from "@/components/shared/control/exibicaoGrade.vue";
import ModalConfirmacaoVue from '@/components/shared/control/modalConfirmacao.vue';

export default {
    props: {
        tituloPagina: {
            type: String,
            required: false,
            default(props) {
                return props.tituloPagina ? props.tituloPagina : 'Projetos'
            }
        },
        modoInicial: {
            type: String,
            required: false
        }
    },
    emits: ['selecionarRegistro'],
    components: {
        PaginaListaPadrao: PaginaListaPadraoVue,
        ExibicaoGrade: ExibicaoGradeVue,
        ModalConfirmacao: ModalConfirmacaoVue
    },
    data() {
        return {
            projetos: [],
            entidadeAlvo: {
                id: null,
                nomeProjeto: '',
                monstrarModalExclusao: false
            },
            colunasGrid: [
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
                    nome: 'Total',
                    chave: 'totalAtividades',
                    type: ''
                },
                {
                    nome: 'A Fazer',
                    chave: 'atividadesAFazer',
                    type: ''
                },
                {
                    nome: 'Fazendo',
                    chave: 'atividadesFazendo',
                    type: ''
                },
                {
                    nome: 'Feitas',
                    chave: 'atividadesFeitas',
                    type: ''
                }
            ],
            modo: this.modoInicial ? this.modoInicial : this.$constModo.cadastro()
        };
    },
    created() {

        this.service = new ProjetoService(this);
        this.consultar();
    },
    methods: {
        consultar() {

            var vueInstance = this;

            this.service
                .lista({})
                .done(function (projetos) {
                    vueInstance.projetos = projetos;
                    console.log("Projeto.consultar sucesso ", projetos);
                })
                .fail(function (jqXHR, textStatus) {
                    console.log("Projeto.consultar erro " + textStatus);
                });
        },
        excluirSelecionar(id, nome) {

            this.entidadeAlvo.monstrarModalExclusao = true;
            this.entidadeAlvo.nomeProjeto = nome;
            this.entidadeAlvo.id = id;
        },
        excluirCancelar() {

            this.entidadeAlvo.monstrarModalExclusao = false
        },
        excluirConfirmar(value) {

            var vueInstance = this;

            this.service
                .apaga(this.entidadeAlvo.id)
                .done(function (projetos) {

                    console.log('ProjetoFormulario.excluir', projetos);
                    vueInstance.entidadeAlvo.monstrarModalExclusao = false;
                    vueInstance.entidadeAlvo.nomeProjeto = '';
                    vueInstance.entidadeAlvo.id = null;
                    vueInstance.consultar();
                })
                .fail(function (jqXHR, textStatus) {

                    console.log("ProjetoService.excluir erro " + textStatus);
                    alert('Erro ao Excluir um Projeto id:' + vueInstance.$route.params.id);
                });
        }
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
                        <router-link v-if="modo == this.$constModo.cadastro()" class="btn btn-primary ms-1" to="/projeto/novo">Novo</router-link>
                    </div>
                </div>
            </form>
        </template>

        <template v-slot:lista>
            <ExibicaoGrade
                identificador="projetoID"
                :colunas="colunasGrid"
                :lista="projetos"                
                colunaNomeRegistro="descricao"
                
                :habilitarEditar="modo == this.$constModo.cadastro()"
                nomeRotaEditar="ProjetoEditar"
                
                :habilitarExcluir="modo == this.$constModo.cadastro()"
                @excluir-registro="excluirSelecionar"
                
                :habilitarSelecao="modo == this.$constModo.selecao()"
                @selecionar-registro="(value) => { $emit('selecionarRegistro', value); }"
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

<style scoped>
.icone-proj {
    width: 30px;
}
</style>
