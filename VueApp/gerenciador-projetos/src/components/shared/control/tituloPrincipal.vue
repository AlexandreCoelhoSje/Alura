<script>
    export default {
        props: {
            texto: {
                type: String,
                required: true
            }
        },
        data() {
            return {

            };
        }
    };
</script>

<template>
    <h1>{{ texto }}</h1>
    <hr />
</template>