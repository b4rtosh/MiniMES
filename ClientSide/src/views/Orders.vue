<script>
import axios from 'axios'
import OrderList from "@/components/OrderList.vue";
import OrderDetails from "@/components/OrderDetails.vue";
import OrderForm from "@/components/OrderForm.vue";
import '@/assets/all.css'
import {API_URL} from "@/main.js";

export default {
  name: 'Orders',
  components: {
    OrderList,
    OrderDetails,
    OrderForm,
  },
  data(){
    return{
      objects: [],
      showForm: false,
      showDetails: false,
      showUptForm: false,
      selectedObject: null,
      route: `${API_URL}/Order`
    }
  },
  created(){
    this.getAllObjects();
  },
  methods: {
    async getAllObjects(){
      this.objects = await axios.get(`${this.route}/all`)
          .then(response => response.data.$values)
          .catch(error => console.log(error));
    },
    async addObject(newObject){
      try {
        await axios.put(`${this.route}/add`, newObject)
        await this.getAllObjects();
        this.closeForm();
      } catch (error){
        console.log('Error', error);
      }
    },

    async deleteObject(object){
      console.log(object);
      await axios.delete(`${this.route}/delete/long/${object.id}`)
          .then(response => response.data)
          .catch(error => console.log('Error', error));
      this.closeForm();
      await this.getAllObjects();
    },
      openForm(){
      this.showForm = true;
      this.showDetails = false;
    },
    closeForm(){
      this.showForm = false;
      this.showDetails = false;
    },
    openDetails(object){
      this.selectedObject = object;
      this.showDetails = true;
      this.showForm = false;
    },
    closeDetails(){
      this.showDetails = false;
      this.showForm = false;
    },
  }
}

</script>

<template>

  <OrderList
      v-if="!showForm && !showDetails && !showUptForm"
      :objects="objects"
      @show-form="openForm"
      @show-details="openDetails"
      @refresh="getAllObjects"
  />
  <OrderForm
      v-if="showForm"
      @add-input="addObject"
      @cancel-form="closeForm"
  />
  <OrderDetails
      v-if="showDetails"
      :id="selectedObject.id"
      @cancel-details="closeDetails"
      :route="route"
      @delete="deleteObject"
  />

</template>

<style>

</style>