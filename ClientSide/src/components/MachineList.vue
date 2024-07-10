<script>
import '@/assets/tables.css'
  export default{
    name: 'MachineList',
    props: {machines: Array}
  }
</script>

<template>
  <div>
    <h1>Machines</h1>
    <table class="listOfObjects">
      <tr>
        <th>Id</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
      <tr v-for="machine in machines" :key="machine.id">
        <td>
          <button id="showDetailsButton" @click="$emit('show-details', machine)">{{ machine.id }}</button>
        </td>
        <td>{{ machine.name }}</td>
        <td>{{ machine.description }}</td>
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