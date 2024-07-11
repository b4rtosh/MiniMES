<script>
import '@/assets/details.css'
import '@/assets/buttons.css'
import Delete from "@/components/Delete.vue";
import MachineUptForm from "@/components/MachineUptForm.vue";
import axios from 'axios';
import {reactive} from 'vue';
export default{
  name: "MachineDetails",
  components: {MachineUptForm, Delete},
  props: {
    machine: {
      type: Object,
      default:{
        id: 0,
        name: 'error',
        description: 'error',
        orders: []
      }
    }
  },
  async created() {
    this.machine = await axios.get(`http://localhost:23988/api/machine/${this.machine.id}`)
        .then(response => response.data)
        .catch(error => console.log(error));
    console.log('machine', this.machine);
    console.log('local machine', this.localMachine);
  },
  data(){
    return{
      showDelete: false,
      showForm: false,
    }
  },
  methods:{
    openForm(){
      this.showForm = true;
    },
    async updateMachine(updatedMachine){
      this.machine.name = updatedMachine.name;
      this.machine.description = updatedMachine.description;
      this.showForm= false;
      await axios.post('http://localhost:23988/api/machine/update', updatedMachine)
          .then(response => console.log(response.data))
          .catch(error => console.log(error));
    }
  
  }
}
</script>

<template>
  <div v-if="machine && !showForm">
    <h1>Machine details</h1>
    <p>Id: {{ machine.id }}</p>
    <p>Name: {{ machine.name }}</p>
    <p>Description: {{ machine.description }}</p>
    <table class="listOfObjects">
      <tr>
        <th>Id</th>
        <th>Code</th>
      </tr>
          <tr v-for="order in machine.orders" :key="order.id" data-test="order">
            <td>{{ order.id }}</td>
            <td>{{ order.code }}</td>
          </tr>
    </table>
    <div class="buttons">
      <button type="reset" @click="$emit('cancel-details')">Cancel</button>
      <button type="button" @click="showDelete = true">Delete</button>
      <button type="button" @click="openForm">Update</button>
    </div>
    <Delete 
        v-if="showDelete"
        @cancel-delete="showDelete = false"
        @submit-delete="$emit('delete', machine)"
    />
  </div>
  <MachineUptForm
      v-if="showForm"
      :machine="machine"
      @cancelForm="showForm = false"
      @submitForm="updateMachine"
    />
</template>

<style scoped>

</style>