<script>
import axios from 'axios'
import ProductList from "@/components/ProductList.vue";
import ProductDetails from "@/components/ProductDetails.vue";
import ProductForm from "@/components/ProductForm.vue";
import '@/assets/all.css'
import ProductUptForm from "@/components/ProductUptForm.vue";

export default {
  name: 'Products',
  components: {
    ProductUptForm,
    ProductList,
    ProductDetails,
    ProductForm,
  },
  data(){
    return{
      objects: [],
      showForm: false,
      showDetails: false,
      showUptForm: false,
      selectedObject: null,
      route: 'http://localhost:23988/api/Product'
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
      await axios.delete(`${this.route}/delete/int/${object.id}`)
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
    openDetails(product){
      this.selectedObject = product;
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

  <ProductList
      v-if="!showForm && !showDetails && !showUptForm"
      :objects="objects"
      @show-form="openForm"
      @show-details="openDetails"
      @refresh="getAllObjects"
  />
  <ProductForm
      v-if="showForm"
      @add-input="addObject"
      @cancel-form="closeForm"
  />
  <ProductDetails
      v-if="showDetails"
      :id="selectedObject.id"
      @cancel-details="closeDetails"
      @delete="deleteObject"
      :route="route"
  />

</template>

<style>

</style>