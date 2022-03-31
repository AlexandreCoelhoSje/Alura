<script>
export default {
    props: {
        tituloPrincipal: {
            type: String,
            required: true
        }
    },
    date() {
        return {

        };
    }
};
</script>

<template>
    <h1 v-html="tituloPrincipal"></h1>
    <hr />

    <!-- Filtros -->
    <div class="row">
        <div class="col-12">
            <slot name="filtro"></slot>
        </div>
    </div>

    <slot name="lista"></slot>    

</template>