<script>
export default {
    props: {
        lista: {
            type: Array,
            required: true
        }
    },
    data() {
        return {

        };
    },
    created() {
        console.log('AKIIII LISTA 01:', this.lista);
    },
    mounted() {
        console.log('AKIIII LISTA:', this.lista);
    }
}
</script>

<template>
    <table class="table mb-0">
        <thead class="table-light">
            <tr>
                <slot name="filtros"></slot>                
            </tr>
        </thead>
        <tbody>
            <tr v-for="item in lista" :key="item.tarefaID">
                <slot name="colunas" :item="item"></slot>
            </tr>
        </tbody>
    </table>
</template>