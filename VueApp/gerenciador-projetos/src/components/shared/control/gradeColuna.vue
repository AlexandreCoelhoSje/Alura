<script>
export default {
    props: {
        classes: {
            type: String,
            required: false,
            default: ''
        }
    }
}
</script>

<template>

    <td :class="classes"><slot></slot></td>

</template>

<style>
</style>