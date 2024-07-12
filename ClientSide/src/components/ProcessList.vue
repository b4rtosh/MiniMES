<script>
import '@/assets/tables.css'
export default{
  name: 'ProcessList',
  props: {objects: Array}
}
</script>

<template>
  <div>
    <h1>Processes</h1>
    <table class="listOfObjects">
      <tr>
        <th>Id</th>
        <th>SerialNumber</th>
        <th>Order Id</th>
        <th>Status Id</th>
        <th>Time</th>
      </tr>
      <tr v-for="object in objects" :key="object.id">
        <td>
          <button id="showDetailsButton" @click="$emit('show-details', object)">{{ object.id }}</button>
        </td>
        <td>{{object.serialNumber}}</td>
        <td>{{ object.orderId }}</td>
        <td>{{ object.statusId }}</td>
        <td>{{object.createdTime}}</td>
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