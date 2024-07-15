<script>
import '@/assets/details.css'
import '@/assets/buttons.css'
import Delete from "@/components/Delete.vue";
import ProcStatusUptForm from "@/components/ProcStatusUptForm.vue";
import axios from 'axios';


export default{
  name: "ProcStatusDetails",
  components: {ProcStatusUptForm, Delete},
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
      this.selectedObject.name = updatedObject.name;
      this.showForm= false;
      console.log(updatedObject);
      await axios.post(`${this.route}/update`, updatedObject)
          .then(response => response.data)
          .catch(error => console.log(error));
    }

  }
}
</script>

<template>
  <div v-if="selectedObject && !showForm">
    <h1>Status details</h1>
    <p>Id: {{ selectedObject.id }}</p>
    <p>Name: {{ selectedObject.name }}</p>
    <h2>Processes:</h2>
    <table class="listOfObjects">
      <tr>
        <th>Id</th>
        <th>Serial number</th>
        <th>Order Id</th>
      </tr>
      <tr v-for="process in selectedObject.processes.$values" :key="process.id" data-test="process">
        <td>{{ process.id }}</td>
        <td>{{ process.serialNumber }}</td>
        <td>{{ process.orderId }}</td>
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
  <ProcStatusUptForm
      v-if="showForm"
      :selectedObject="selectedObject"
      @cancelForm="showForm = false"
      @submitForm="updateObject"
  />
</template>

<style scoped>

</style>