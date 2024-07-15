<script>
import axios from 'axios'
import ParameterList from "@/components/ParameterList.vue";
import ParameterDetails from "@/components/ParameterDetails.vue";
import ParameterForm from "@/components/ParameterForm.vue";
import '@/assets/all.css'
export default {
  name: 'Parameters',
  components: {
    ParameterList,
    ParameterDetails,
    ParameterForm,
  },
  data(){
    return{
      objects: [],
      showForm: false,
      showDetails: false,
      showUptForm: false,
      selectedObject: null,
      route: 'http://localhost:23988/api/Param'
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
        let response = await axios.put(`${this.route}/add`, newObject)
            .then(x => x.data);
        console.log(response);
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

  <ParameterList
      v-if="!showForm && !showDetails && !showUptForm"
      :objects="objects"
      @show-form="openForm"
      @show-details="openDetails"
      @refresh="getAllObjects"
  />
  <ParameterForm
      v-if="showForm"
      @add-input="addObject"
      @cancel-form="closeForm"
  />
  <ParameterDetails
      v-if="showDetails"
      :id="selectedObject.id"
      @cancel-details="closeDetails"
      @delete="deleteObject"
      :route="route"
  />

</template>

<style>

</style>