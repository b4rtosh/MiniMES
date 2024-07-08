<script>
import axios from 'axios'
import VueAxios from 'vue-axios'

export default {
  name: 'Machines',
  data() {
    return {
      machines: null
    }
  },
  created() {
     this.getMachines()
   },
  methods: {
    async getMachines() {
     this.machines  = await axios.get('http://localhost:23988/api/machine/all', {
        headers:{
          'Cache-Control': 'no-cache',
          'Pragma': 'no-cache',
          'Expires': '0'
        }
      }).then(response => response.data)
       console.log(this.machines);
    }
  }
}
</script>

<template>
  <h1>Machines</h1>
  <table class="machinesTable">
    <tr>
      <th>Id</th>
      <th>Name</th>
      <th>Description</th>
    </tr>
    <tr v-for="machine in machines" :key="machine.id" data-test="machine">
      <td>{{ machine.id }}</td>
      <td>{{ machine.name }}</td>
      <td>{{ machine.description }}</td>
    </tr>
  </table>
  <div id="buttons">
  <button @click="getMachines">Refresh</button>
  <router-link to="/machine/add">
    <button>Add</button>
  </router-link>
  </div>
</template>

<style scoped>

.machinesTable {
  width: 100%;
  border-collapse: collapse;
  text-align: left;
}

.machinesTable th {
  background-color: #f2f2f2;
  color: #333;
  font-weight: bold;
  padding: 12px 15px;
}

.machinesTable td {
  padding: 10px 15px;
  border-bottom: 1px solid #ddd;
}

.machinesTable tr:nth-child(even) {
  background-color: #f9f9f9;
}

.machinesTable tr:hover {
  background-color: #e2e2e2;
}

button {
  padding: 10px 20px;
  background-color: #007bff;
  
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  width: 10%;
}

button:hover {
  background-color: #0056b3;
}

#buttons{
margin-top: 10px;
text-align: center;
}


</style>