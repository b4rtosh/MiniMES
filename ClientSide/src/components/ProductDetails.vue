<script>
import '@/assets/details.css'
import '@/assets/buttons.css'
import Delete from "@/components/Delete.vue";
import ProductUptForm from "@/components/ProductUptForm.vue";
import axios from 'axios';


export default{
  name: "ProductDetails",
  components: {ProductUptForm, Delete},
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
  methods:{
    openForm(){
      this.showForm = true;
    },
    async getDetailedObject(){
      this.selectedObject = await axios.get(`http://localhost:23988/api/product/${this.id}`)
          .then(response => response.data)
          .catch(error => console.log(error));
    },
    async updateObject(updatedObject){
      this.selectedObject.code = updatedObject.code;
      this.selectedObject.description = updatedObject.description;
      this.showForm= false;
      console.log(updatedObject);
      await axios.post('http://localhost:23988/api/product/update', updatedObject)
          .then(response => response.data)
          .catch(error => console.log(error));
    }

  }
}
</script>

<template>
  <div v-if="selectedObject && !showForm">
    <h1>Product details</h1>
    <p>Id: {{ selectedObject.id }}</p>
    <p>Code: {{ selectedObject.code }}</p>
    <p>Description: {{ selectedObject.description }}</p>
    <table class="listOfObjects">
      <tr>
        <th>Id</th>
        <th>Code</th>
      </tr>
      <tr v-for="order in selectedObject.orders.$values" :key="order.id" data-test="order">
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
        @submit-delete="$emit('delete', selectedObject)"
    />
  </div>
  <ProductUptForm
      v-if="showForm"
      :selectedObject="selectedObject"
      @cancelForm="showForm = false"
      @submitForm="updateObject"
  />
</template>

<style scoped>

</style>