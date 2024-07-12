<script>
import axios from 'axios'
import ProcessList from "@/components/ProcessList.vue";
import ProcessDetails from "@/components/ProcessDetails.vue";
import ProcessForm from "@/components/ProcessForm.vue";
import '@/assets/all.css'

export default {
  name: 'Processes',
  components: {
    ProcessList,
    ProcessDetails,
    ProcessForm,
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
      this.objects = await axios.get('http://localhost:23988/api/process/all')
          .then(response => response.data.$values)
          .catch(error => console.log(error));
    },
    async addObject(newObject){
      try {
        console.log(newObject);
        let response = await axios.put('http://localhost:23988/api/process/add', newObject.process)
            .then(x => x.data);
        console.log(response.id);
        for (let i = 0; i < Object.keys(newObject.parameters.length); i++) {
          newObject.parameters[i].processId = response.id;
          
          response = await axios.put('http://localhost:23988/api/processparam/add', newObject.parameters[i])
          console.log('Added parameter', response.data);
        }
        await this.getAllObjects();
        this.closeForm();
      } catch (error){
        console.log('Error', error);
      }
    },

    async deleteObject(object){
      console.log(object);
      await axios.delete(`http://localhost:23988/api/process/delete/${object.id}`)
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

  <ProcessList
      v-if="!showForm && !showDetails && !showUptForm"
      :objects="objects"
      @show-form="openForm"
      @show-details="openDetails"
      @refresh="getAllObjects"
  />
  <ProcessForm
      v-if="showForm"
      @add-input="addObject"
      @cancel-form="closeForm"
  />
  <ProcessDetails
      v-if="showDetails"
      :id="selectedObject.id"
      @cancel-details="closeDetails"
      @delete="deleteObject"
  />

</template>

<style>

</style>