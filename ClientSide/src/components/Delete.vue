<script setup>

</script>

<template>
<div>
  <h1>Delete</h1>
  <p>Are you sure you want to delete this machine?</p>
  <div class="buttons">
    <button type="reset" @click="$emit('cancel-delete')">Cancel</button>
    <button type="submit" @click="$emit('submit-delete')">Delete</button>
</div>
</div>
</template>

<style scoped>

</style>