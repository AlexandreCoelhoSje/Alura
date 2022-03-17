<script>
import { Modal } from 'bootstrap';

export default {
    props: {
        textoTitulo: {
            type: String,
            required: true
        },
        textoCorpo: {
            type: String,
            required: true
        },
        textoBotaoLancar: {
            type: String,
            required: true
        },
        textoBotaoConfirmar: {
            type: String,
            required: true
        },
        classeContextoBotaoConfirmar: {
            type: String,
            required: false,
            default(rawProps) {
                return rawProps.classeContextoBotaoConfirmar ? rawProps.classeContextoBotaoConfirmar : 'primary'
            }
        },
        exibirModal: {
            type: Boolean,
            required: true
        },
        parametroEvento: [String, Number, Object]
    },
    data() {
        return {
            modalConfirmacao: null,
            idModal: 'modalConfirmacao' + this.$util.data.gerarIdComDataHora()
        };
    },
    watch: {
        exibirModal(valorNovo, valorAntigo) {

            if (this.modalConfirmacao != null) {
                
                if (this.exibirModal)
                    this.modalConfirmacao.show();
                else
                    this.modalConfirmacao.hide();
            }
        }
    },
    mounted() {

        this.modalConfirmacao = new Modal(document.getElementById(this.idModal), { backdrop: 'static'});
        
        if (this.exibirModal)
            this.modalConfirmacao.show();
    }
};
</script>

<template>
    <!-- Button trigger modal -->
    <!-- <a
        type="button"
        class="btn btn-link"
        data-bs-toggle="modal"
        data-bs-target="#exampleModal"
    >{{ textoBotaoLancar }}</a>-->

    <!-- Modal -->
    <div :id="this.idModal" class="modal fade" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">{{ textoTitulo }}</h5>
                    <button
                        type="button"
                        class="btn-close"
                        data-bs-dismiss="modal"
                        aria-label="Close"
                        @click="$emit('modalCancelar', parametroEvento);"
                    ></button>
                </div>
                <div class="modal-body">{{ textoCorpo }}</div>
                <div class="modal-footer">
                    <button @click="$emit('modalCancelar', parametroEvento);" type="button" class="btn btn-secondary" data-bs-dismiss="modal">Fechar</button>
                    <button
                        type="button"
                        :class="'btn ' + classeContextoBotaoConfirmar"
                        @click="$emit('modalConfirmar', parametroEvento);"
                    >{{ textoBotaoConfirmar }}</button>
                </div>
            </div>
        </div>
    </div>
</template>