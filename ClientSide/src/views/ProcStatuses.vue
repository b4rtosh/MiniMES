<script>
import axios from 'axios'
import ProcStatusList from "@/components/ProcStatusList.vue";
import ProcStatusDetails from "@/components/ProcStatusDetails.vue";
import ProcStatusForm from "@/components/ProcStatusForm.vue";
import '@/assets/all.css'
export default {
  name: 'Statuses',
  components: {
    ProcStatusList,
    ProcStatusDetails,
    ProcStatusForm,
  },
  data(){
    return{
      objects: [],
      showForm: false,
      showDetails: false,
      showUptForm: false,
      selectedObject: null,
    }
  },
  created(){
    this.getAllObjects();
  },
  methods: {
    async getAllObjects(){
      this.objects = await axios.get('http://localhost:23988/api/status/all')
          .then(response => response.data.$values)
          .catch(error => console.log(error));
    },
    async addObject(newObject){
      try {
        await axios.put('http://localhost:23988/api/status/add', newObject)
        await this.getAllObjects();
        this.closeForm();
      } catch (error){
        console.log('Error', error);
      }
    },

    async deleteObject(object){
      console.log(object);
      await axios.delete(`http://localhost:23988/api/status/delete/${object.id}`)
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

  <ProcStatusList
      v-if="!showForm && !showDetails && !showUptForm"
      :objects="objects"
      @show-form="openForm"
      @show-details="openDetails"
      @refresh="getAllObjects"
  />
  <ProcStatusForm
      v-if="showForm"
      @add-input="addObject"
      @cancel-form="closeForm"
  />
  <ProcStatusDetails
      v-if="showDetails"
      :id="selectedObject.id"
      @cancel-details="closeDetails"
      @delete="deleteObject"
  />

</template>

<style>

</style>