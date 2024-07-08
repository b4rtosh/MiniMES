<script>
import axios from 'axios';
export default{
  name: "MachineDetail",
  data(){
    return{
      machine: null
    }
  },
  created(){
    this.getMachine();
  },
  methods:{
    async getMachine(){
      this.machine = await axios(`http://localhost:23988/api/machine/${this.$route.params.id}`)
          .then(response => response.data);
      console.log(this.machine);
    }
  }
}
</script>

<template>
<h1>Machine detail</h1>
  <p>Id: {{machine.id}}</p>
  <p>Name: {{machine.name}}</p>
  <p>Description: {{machine.description}}</p>
  <table class="machinesTable">
    <tr>
      <th>Id</th>
      <th>Code</th>
    </tr>
    <tr v-for="order in machine.orders" :key="order.id" data-test="order">
      <td>{{ order.id }}</td>
      <td>{{ order.code }}</td>
    </tr>
  </table>
</template>

<style scoped>

</style>