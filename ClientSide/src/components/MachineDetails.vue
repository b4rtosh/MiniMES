<script>
import '@/assets/details.css'
import '@/assets/buttons.css'
import Delete from "@/components/Delete.vue";
import MachineUptForm from "@/components/MachineUptForm.vue";
import axios from 'axios';


export default{
  name: "MachineDetails",
  components: {MachineUptForm, Delete},
  props: ['id', 'route'],
  created(){
    this.getDetailedObject();
  },
  data(){
    return{
      showDelete: false,
      showForm: false,
      selectedObject: null,
    }
  },
  methods:{
    openForm(){
      this.showForm = true;
    },
    async getDetailedObject(){
      this.selectedObject = await axios.get(`${this.route}/int/${this.id}`)
          .then(response => response.data)
          .catch(error => console.log(error));
    },
    async updateObject(updatedObject){
      console.log(updatedObject);
      this.selectedObject.name = updatedObject.name;
      this.selectedObject.description = updatedObject.description;
      this.showForm= false;
      await axios.post(`${this.route}/update`, updatedObject)
          .then(response => console.log(response.data))
          .catch(error => console.log(error));
    }
  }
}
</script>

<template>
  <div v-if="selectedObject && !showForm">
    <h1>Machine details</h1>
    <p>Id: {{ selectedObject.id }}</p>
    <p>Name: {{ selectedObject.name }}</p>
    <p>Description: {{ selectedObject.description }}</p>
    <h2>Orders:</h2>
    <table class="listOfObjects">
      <tr>
        <th>Id</th>
        <th>Code</th>
        <th>Quantity</th>
      </tr>
          <tr v-for="order in selectedObject.orders.$values" :key="order.id" data-test="order">
            <td>{{ order.id }}</td>
            <td>{{ order.code }}</td>
            <td>{{ order.quantity }}</td>
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
        @submit-delete="$emit('delete', selectedObject)"
    />
  </div>
  <MachineUptForm
      v-if="showForm"
      :machine="selectedObject"
      @cancelForm="showForm = false"
      @submitForm="updateObject"
    />
</template>

<style scoped>

</style>