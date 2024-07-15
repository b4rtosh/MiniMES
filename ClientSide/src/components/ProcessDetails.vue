<script>
import '@/assets/details.css'
import '@/assets/buttons.css'
import Delete from "@/components/Delete.vue";
import ProcessUptForm from "@/components/ProcessUptForm.vue";
import axios from 'axios';


export default{
  name: "ProcessDetails",
  components: {ProcessUptForm, Delete},
  props: ['id'],
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
  methods: {
    openForm() {
      this.showForm = true;
    },
    async getDetailedObject() {
      this.selectedObject = await axios.get(`http://localhost:23988/api/process/${this.id}`)
          .then(response => response.data)
          .catch(error => console.log(error));
    },
    async updateObject(updatedObject) {
      this.selectedObject.serialNumer = updatedObject.serialNumber;
      this.selectedObject.orderId = updatedObject.orderId;
      this.selectedObject.statusId = updatedObject.statusId;
      this.showForm = false;
      await axios.post('http://localhost:23988/api/process/update', updatedObject)
          .then(response => console.log(response.data))
          .catch(error => console.log(error));
      await this.getDetailedObject();
    },
    async deleteObject() {
      await axios.delete(`http://localhost:23988/api/process/delete/${this.selectedObject.id}`)
          .then(response => response.data)
          .catch(error => console.log('Error', error));
      this.$emit('delete');
    },
  }
}
</script>

<template>
  <div v-if="selectedObject && !showForm">
    <h1>Process details</h1>
    <div id="details">
      <div style="width: 80%">
        <p>Id: {{ selectedObject.id }}</p>
        <p>Serial number: {{ selectedObject.serialNumber }}</p>
        <p>Created time: {{ selectedObject.createdTime }}</p>
      </div>
    </div>
    <div class="parentDiv">
      <div class="childDiv">
        <h2>Status</h2>
        <p>Id: {{selectedObject.processStatus.id}}</p>
        <p>Name: {{selectedObject.processStatus.name}}</p>
      </div>
      <div class="childDiv">
        <h2>Order</h2>
        <p>Id: {{selectedObject.order.id}}</p>
        <p>Code: {{selectedObject.order.code}}</p>
      </div>
    </div>
    <h2>Parameters:</h2>
    <table class="listOfObjects">
      <tr>
        <th>Id</th>
        <th>Value</th>
      </tr>
      <tr v-for="parameter in selectedObject.processParameters.$values" :key="parameter.id" data-test="parameter">
        <td>{{ parameter.id }}</td>
        <td>{{parameter.value}}</td>
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
        @submit-delete="deleteObject"
    />
  </div>
  <ProcessUptForm
      v-if="showForm"
      :machine="selectedObject"
      @cancelForm="showForm = false"
      @submitForm="updateObject"
  />
</template>

<style scoped>

</style>