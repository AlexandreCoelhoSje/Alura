<script>
export default {
    props: {
        lista: {
            type: Array,
            required: true
        }
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
                <slot :item="item"></slot>
            </tr>
        </tbody>
    </table>
</template>