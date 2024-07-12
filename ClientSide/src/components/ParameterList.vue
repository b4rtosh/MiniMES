<script>
import '@/assets/tables.css'
export default{
  name: 'ParameterList',
  props: {objects: Array}
}
</script>

<template>
  <div>
    <h1>Parameters</h1>
    <table class="listOfObjects">
      <tr>
        <th>Id</th>
        <th>Name</th>
        <th>Unit</th>
      </tr>
      <tr v-for="object in objects" :key="object.id">
        <td>
          <button id="showDetailsButton" @click="$emit('show-details', object)">{{ object.id }}</button>
        </td>
        <td>{{ object.name}}</td>
        <td>{{ object.unit }}</td>
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