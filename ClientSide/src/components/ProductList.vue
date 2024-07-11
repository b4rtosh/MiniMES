<script>
import '@/assets/tables.css'
export default{
  name: 'ProductList',
  props: {objects: Array}
}
</script>

<template>
  <div>
    <h1>Products</h1>
    <table class="listOfObjects">
      <tr>
        <th>Id</th>
        <th>Code</th>
        <th>Description</th>
      </tr>
      <tr v-for="object in objects" :key="object.id">
        <td>
          <button id="showDetailsButton" @click="$emit('show-details', object)">{{ object.id }}</button>
        </td>
        <td>{{ object.code}}</td>
        <td>{{ object.description }}</td>
      </tr>
    </table>
    <div class="buttons">
      <button @click="$emit('refresh')">Refresh</button>
      <button @click="$emit('show-form')">Add</button>
    </div>
  </div>
</template>

<style scoped>

</style>