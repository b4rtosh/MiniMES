<script>
import axios from 'axios'
import MachineList from "@/components/MachineList.vue";
import MachineDetails from "@/components/MachineDetails.vue";
import MachineForm from "@/components/MachineForm.vue";
import '@/assets/all.css'
import MachineUptForm from "@/components/MachineUptForm.vue";

export default {
  name: 'Machines',
  components: {
    MachineUptForm,
    MachineList,
    MachineDetails,
    MachineForm,
  },
  data(){
    return{
      machines: [],
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
      this.machines = await axios.get('http://localhost:23988/api/machine/all')
          .then(response => response.data.$values)
          .catch(error => console.log(error));
    },
    async addObject(newMachine){
      try {
        await axios.put('http://localhost:23988/api/machine/add', newMachine)
        await this.getAllObjects();
        this.closeForm();
      } catch (error){
        console.log('Error', error);
      }
    },
   
    async deleteObject(object){
      console.log(object);
      await axios.delete(`http://localhost:23988/api/machine/delete/${object.id}`)
          .then(response => response.data)
          .catch(error => console.log('Error', error));
      this.closeForm();
      await this.getAllObjects();
    },
    async updateObject(object){
      console.log(object);
      await axios.post('http://localhost:23988/api/machine/update', object)
          .then(response => response.data)
          .catch(error => console.log('Error', error));
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
    openDetails(machine){
      this.selectedObject = machine;
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
 
    <MachineList
        v-if="!showForm && !showDetails && !showUptForm"
        :machines="machines"
        @show-form="openForm"
        @show-details="openDetails"
        @refresh="getAllObjects"
    />
    <MachineForm
        v-if="showForm"
        @add-input="addObject"
        @cancel-form="closeForm"
    />
      <MachineDetails
        v-if="showDetails"
        :id="selectedObject.id"
        @cancel-details="closeDetails"
        @delete="deleteObject"
      />

</template>

<style>

</style>