<script>
import '@/assets/details.css'
import '@/assets/buttons.css'
import Delete from "@/components/Delete.vue";
import OrderUptForm from "@/components/OrderUptForm.vue";
import axios from 'axios';


export default{
  name: "OrderDetails",
  components: {OrderUptForm, Delete},
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
      this.selectedObject = await axios.get(`${this.route}/Order/long/${this.id}`)
          .then(response => response.data)
          .catch(error => console.log(error));
      console.log(this.selectedObject);
    },
    async updateObject(updatedObject){
      this.selectedObject.code = updatedObject.code;
      this.selectedObject.quantity = updatedObject.quantity;
      this.selectedObject.machineId = updatedObject.machineId;
      this.selectedObject.productId = updatedObject.productId;
      this.showForm= false;
      await axios.post(`${this.route}/Order/update`, updatedObject)
          .then(response => console.log(response.data))
          .catch(error => console.log(error));
      await this.getDetailedObject();
    }
  }
}
</script>

<template>
  <div v-if="selectedObject && !showForm">
    <h1>Order details</h1>
    <div id="details">
    <div style="width: 70%">
    <p>Id: {{ selectedObject.id }}</p>
    <p>Code: {{ selectedObject.code }}</p>
    <p>Quantity: {{ selectedObject.quantity }}</p>
      </div>
    </div>
    <div class="parentDiv">
    <div class="childDiv">
      <h2>Machine</h2>
      <p>Id: {{selectedObject.machine.id}}</p>
      <p>Name: {{selectedObject.machine.name}}</p>
    </div>
      <div class="childDiv" >
        <h2>Product</h2>
        <p>Id: {{selectedObject.product.id}}</p>
        <p>Code: {{selectedObject.product.code}}</p>
      </div>
      
    </div>
    <h2>Processes:</h2>
    <table class="listOfObjects">
      <tr>
        <th>Id</th>
        <th>Serial Number</th>
      </tr>
      <tr v-for="process in selectedObject.processes.$values" :key="process.id" data-test="process">
        <td>{{ process.id }}</td>
        <td>{{process.serialNumber}}</td>
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
  <OrderUptForm
      v-if="showForm"
      :machine="selectedObject"
      :route="route"
      @cancelForm="showForm = false"
      @submitForm="updateObject"
  />
</template>

<style scoped>

</style>