<script>
export default {
    props: {
        identificador: {
            type: String,
            required: true
        },
        paramExtra: {
            type: String,
            required: false
        },
        colunas: {
            type: Array,
            required: true,
            validator(value) {

                var existePropInvalida = false;
                var nomeChave = '';

                for (let i = 0; i < value.length; i++) {

                    let coluna = value[i];

                    if (!existePropInvalida) {
                        if (!coluna.hasOwnProperty('nome')) {
                            existePropInvalida = true;
                            console.log('O Objeto não contem a propriedade: nome', coluna);
                        }
                        if (!coluna.hasOwnProperty('chave')) {
                            existePropInvalida = true;
                            console.log('O Objeto não contem a propriedade: chave', coluna);
                        }
                        if (!coluna.hasOwnProperty('type')) {
                            existePropInvalida = true;
                            console.log('O Objeto não contem a propriedade: type', coluna);
                        }
                    }
                }

                return existePropInvalida ? 'danger'.includes(value) : 'success';
            }
        },
        lista: {
            type: Array,
            required: true
        },
        colunaNomeRegistro: {
            type: String,
            required: false
        },
        habilitarDetalhar: {
            type: Boolean,
            required: false,
            default: false
        },
        nomeRotaDetalhar: {
            type: String,
            required: false
        },
        habilitarEditar: {
            type: Boolean,
            required: false,
            default: false
        },
        nomeRotaEditar: {
            type: String,
            required: false
        },
        habilitarExcluir: {
            type: Boolean,
            required: false,
            default: false
        },
        // nomeRotaExcluir: {
        //     type: String,
        //     required: false
        // },
        habilitarSelecao: {
            type: Boolean,
            required: false,
            default: false
        }
    },
    emits: ['selecionarRegistro', 'excluirRegistro'],
    data() {
        return {

        };
    },
    methods: {
        formtarCampo(coluna, item) {

            let valor = '';

            //Captura o valor
            if (coluna.type === Object) {

                valor = item;
                let propriedades = coluna.chave.split('.');

                for (let i = 0; i < propriedades.length; i++) {

                    valor = valor[propriedades[i]];
                }
            } else {

                valor = item[coluna.chave];
            }

            //Formata o valor
            if (coluna.type === Date)
                valor = this.$util.data.formatarData(valor);

            return valor;
        }
    }
};
</script>

<template>
    <table class="table table-striped table-hover">
        <thead class="table-dark">
            <tr>
                <template v-for="coluna in colunas" :key="coluna.nome">
                    <th>{{ coluna.nome }}</th>
                </template>

                <th v-if="habilitarDetalhar" class="text-primary"></th>
                <th v-if="habilitarEditar" class="text-primary"></th>
                <th v-if="habilitarExcluir" class="text-primary"></th>
                <th v-if="habilitarSelecao" class="text-primary"></th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="item in lista" :key="item[identificador]">
                <td
                    v-for="(coluna, indexC) in colunas"
                    :key="indexC"
                >{{ formtarCampo(coluna, item) }}</td>

                <td v-if="habilitarDetalhar">Detalhar</td>
                <td v-if="habilitarEditar">
                    <router-link
                        class="btn btn-link"
                        :to="{ name: nomeRotaEditar, params: { id: item[identificador], paramExtra: paramExtra } }"
                    >Editar</router-link>
                </td>
                <td v-if="habilitarExcluir">
                    <a
                        @click="() => { $emit('excluirRegistro', item[identificador], item[this.colunaNomeRegistro], paramExtra); }"
                        class="btn btn-link"
                    >Excluir</a>
                </td>
                <td v-if="habilitarSelecao">
                    <a
                        @click="() => { $emit('selecionarRegistro', item[identificador], paramExtra); }"
                        class="btn btn-link"
                    >Selecionar</a>
                </td>
            </tr>
        </tbody>
    </table>
</template>