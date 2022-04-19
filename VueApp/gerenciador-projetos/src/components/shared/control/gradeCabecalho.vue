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

  <th :class="classes"><slot></slot></th>

</template>

<style>

</style>