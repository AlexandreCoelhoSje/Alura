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
    <h1>{{ tituloPrincipal }}</h1>
    <hr />

     <div class="row justify-content-center">
        <div class="col col-md-8 col-lg-7">
            <slot name="formulario"></slot>
        </div>
    </div>

</template>

