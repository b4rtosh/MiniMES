<script>
import axios from 'axios'
import '@/assets/forms.css';
import "@/assets/table.css";


export default {
  name: 'Machines',
  data() {
    return {
      machines: null,
      showForm: false,
      showDetails: false,
      newMachine: {
        id: 0,
        name: "",
        description: ""
      },
      idDetails: 0,
        nameDetails: "",
        descriptionDetails: "",
      


    }
  },
  created() {
    this.getMachines()
  },
  methods: {
    async getMachines() {
      this.machines = await axios.get('http://localhost:23988/api/machine/all')
          .then(response => response.data)
      console.log(this.machines);
    },
    //   dialog add
    async addMachine() {
      console.log(this.newMachine);
      this.newMachine = await axios.put('http://localhost:23988/api/machine/add', this.newMachine)
          .then(response => response.data)
          .catch(error => {
            console.log('Error', error);
          })
      this.disableForm();
      this.getMachines();
      this.newMachine = {
        id: 0,
        name: "",
        description: "",
      };
    },
    enableForm() {
      this.showForm = true;
      this.showDetails = false;
    },
    disableForm() {
      this.showForm = false;
    },
    enableDetails(machine) {
      this.showDetails = true;
      console.log(machine);
      this.idDetails = machine.id;
      console.log(machine.id);
      this.nameDetails = machine.name;
      this.descriptionDetails = machine.description;

    },
    disableDetails() {
      this.showDetails = false;
    },
  }
}
</script>

<template>

  <div v-show="!showForm && !showDetails">
    <h1>Machines</h1>
    <table class="machinesTable">
      <tr>
        <th>Id</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
      <tr v-for="machine in machines" :key="machine.id" data-test="machine">

        <td>
          <button id="showDetailsButton" @click="enableDetails(machine)">{{ machine.id }}</button>
        </td>
        <td>{{ machine.name }}</td>
        <td>{{ machine.description }}</td>
      </tr>
    </table>
    <div class="buttons">
      <button @click="getMachines">Refresh</button>
      <button @click="enableForm">Add</button>
    </div>
  </div>

  <div v-show="showForm">
    <!--  add machine dialog which covers list -->
    <h1>Add Machine</h1>
    <form @submit.prevent="addMachine">
      <div>
        <label for="nameInput">Name:</label>
        <input class="inputTxt" type="text" id="nameInput" v-model="newMachine.name" required><br>
      </div>
      <div>
        <label for="descriptionInput">Description:</label>
        <input class="inputTxt" type="text" id="descriptionInput" v-model="newMachine.description" required><br>
      </div>
      <div class='buttons'>
        <button type="submit">Add</button>
        <button type="reset" @click="disableForm">Cancel</button>
      </div>
    </form>
  </div>
  
  <div v-show="showDetails">
  <h1>Machine details</h1>
  <p>Id: {{ idDetails }}</p>
  <p>Name: {{ nameDetails }}</p>
  <p>Description: {{ descriptionDetails }}</p>
  <table class="machinesTable">
    <tr>
      <th>Id</th>
      <th>Code</th>
    </tr>
    <!--    <tr v-for="order in machine.orders" :key="order.id" data-test="order">-->
    <!--      <td>{{ order.id }}</td>-->
    <!--      <td>{{ order.code }}</td>-->
    <!--    </tr>-->
  </table>
  <div class="buttons">
    <button type="reset" @click="disableDetails">Cancel</button>
    <!--    <button @click="goToUpdate">Update</button>-->
  </div>
  </div>
</template>

<style scoped>

#showDetailsButton {
  color: white;
  padding: 4px;
  border: none;
  cursor: pointer;
  width: 30%;
}
</style>