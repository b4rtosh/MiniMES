<script>
import axios from 'axios';


export default{
  name: "MachineDetail",
  props: ['id'],
  data(){
    return{
      machine: null,
      idData: 0,
      nameData: "",
      descriptionData: "",
    }
  },
  created(){
    this.getMachine();
  },
  methods:{
    async getMachine() {
      try{
        const response = await axios(`http://localhost:23988/api/machine/${this.id}`)
            .then(response => response.data);
        console.log('Response', response);
        this.idData = response.id;
        this.nameData = response.name;
        this.descriptionData = response.description;
        
        this.machine = response;
        console.log(this.machine);
      } catch (error) {
        console.log('Error', error);
      }
      // this.machine = await axios(`http://localhost:23988/api/machine/${this.$route.params.id}`)
      // this.machine = await axios(`http://localhost:23988/api/machine/${this.id}`)
      //     .then(response => response.data)
      //     .then(response =>
      //     {
      //       console.log('Response', response);
      //       this.idData = response.id;
      //       this.nameData = response.name;
      //       this.descriptionData = response.description;
      //     })
      //     .catch(error => {
      //       console.log('Error', error);
      //     })
    },
    // goToUpdate(){
    //   // redirect with this.machine to update 
    //   console.log('Before reroute', this.machine);
    //   this.$router.push({name: 'updateMachine', params: {id: this.id, machine: this.machine}}); 
    // },
    goToDelete(){},
  }
}
</script>

<template>
<h1>Machine detail</h1>
  <p>Id: {{idData}}</p>
  <p>Name: {{nameData}}</p>
  <p>Description: {{descriptionData}}</p>
  <table class="machinesTable">
    <tr>
      <th>Id</th>
      <th>Code</th>
    </tr>
<!--    <tr v-for="order in machine.orders" :key="order.id" data-test="order">-->
<!--      <td>{{ order.id }}</td>-->
<!--      <td>{{ order.code }}</td>-->
<!--    </tr>-->
  </table>
  <div id="buttons">
      <button @click="goToDelete">Delete</button>
<!--    <button @click="goToUpdate">Update</button>-->
  </div>
</template>

<style scoped>

</style>