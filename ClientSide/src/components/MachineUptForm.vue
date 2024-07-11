<script>
import '@/assets/forms.css';
export default{
  name: 'MachineUptForm',
  props: {
    machine: {
      type: Object,
      default: null,
    }
  },
  data(){
    return{
      localMachine: {...this.machine}
    }
  
  },
methods: {
  submitForm() {
    this.$emit('submitForm', this.localMachine);
  },
},}

</script>

<template>
  <!--  add machine dialog which covers list -->
  <div>
    <h1>Add Machine</h1>
    <form @submit.prevent="submitForm">
      <div>
        <label for="nameInput">Name:</label>
        <input class="inputTxt" type="text" id="nameInput" v-model="localMachine.name" required><br>
      </div>
      <div>
        <label for="descriptionInput">Description:</label>
        <input class="inputTxt" type="text" id="descriptionInput" v-model="localMachine.description" required><br>
      </div>
      <div class='buttons'>
        <button type="submit">Update</button>
        <button type="reset" @click="$emit('cancelForm')">Cancel</button>
      </div>
    </form>
  </div>
</template>

<style scoped>

</style>