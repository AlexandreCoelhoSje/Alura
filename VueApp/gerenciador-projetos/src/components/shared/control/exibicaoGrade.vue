<script>
export default {
    props: {
        identificador: {
            type: String,
            required: true
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
        nomeRotaDetalhar: {
            type: String,
            required: false
        },
        nomeRotaEditar: {
            type: String,
            required: false
        },
        nomeRotaExcluir: {
            type: String,
            required: false
        }
    },
    data() {
        return {

        };
    },
    methods: {
        formtarCampo(coluna, item) {

            let valor = item[coluna.chave];

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

                <th v-if="nomeRotaDetalhar" class="text-primary"></th>
                <th v-if="nomeRotaEditar" class="text-primary"></th>
                <th v-if="nomeRotaExcluir" class="text-primary"></th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="item in lista" :key="item[identificador]">
                <td
                    v-for="(coluna, indexC) in colunas"
                    :key="indexC"
                >{{ formtarCampo(coluna, item) }}</td>

                <td v-if="nomeRotaDetalhar" class="text-primary">Detalhar</td>
                <td v-if="nomeRotaEditar" class="text-primary">
                    <router-link
                        :to="{ name: nomeRotaEditar, params: { id: item[identificador] } }"
                    >Editar</router-link>
                </td>
                <td v-if="nomeRotaExcluir" class="text-danger">Excluir</td>
            </tr>
        </tbody>
    </table>
</template>