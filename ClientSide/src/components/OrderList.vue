<script>
import '@/assets/tables.css'
export default{
  name: 'OrderList',
  props: {objects: Array}
}
</script>

<template>
  <div>
    <h1>Orders</h1>
    <table class="listOfObjects">
      <tr>
        <th>Id</th>
        <th>Code</th>
        <th>Machine Id</th>
        <th>Product Id</th>
        <th>Quantity</th>
      </tr>
      <tr v-for="object in objects" :key="object.id">
        <td>
          <button id="showDetailsButton" @click="$emit('show-details', object)">{{ object.id }}</button>
        </td>
        <td>{{object.code}}</td>
        <td>{{ object.machineId }}</td>
        <td>{{ object.productId }}</td>
        <td>{{object.quantity}}</td>
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