<script>
import '@/assets/forms.css';
import axios from "axios";

export default {
  name: 'ProcessForm',
  data() {
    return {
      localObject: {
        serialNumber: '',
        orderId: 0,
        statusId: 0,
        productId: 0,
      },
      orders: [],
      statuses: [],
      parameters: [],
      addedParameters: [{processId: 0}]
    }
  },
  created() {
    this.getAllOrders();
    this.getAllStatuses();
    this.getAllParameters();
  },
  methods: {
    submitForm() {
      console.log(this.addedParameters);
      
    },
    async getAllOrders() {
      this.orders = await axios.get('http://localhost:23988/api/order/all')
          .then(response => response.data.$values)
          .catch(error => console.log(error));
    },
    async getAllStatuses() {
      this.statuses = await axios.get('http://localhost:23988/api/status/all')
          .then(response => response.data.$values)
          .catch(error => console.log(error));
    },
    async getAllParameters() {
      this.parameters = await axios.get('http://localhost:23988/api/parameter/all')
          .then(response => response.data.$values)
          .catch(error => console.log(error));
    },
    async addObject(){
      try {
        console.log();
        let response = await axios.put('http://localhost:23988/api/process/add', this.localObject)
            .then(x => x.data);
        const processId = response.id;
        if (!response.id) {throw new Error('Process ID not found');}
        
        for (let i = 0; i < this.addedParameters.length; i++) {
          this.addedParameters[i].processId = processId;
          console.log(`Sending PUT request to add process parameter ${i + 1}`, this.addedParameters[i]);
          try {
            response = await axios.put('http://localhost:23988/api/processparam/add', this.addedParameters[i]);
            console.log('Reponse', response);
          }catch (paramError){console.log(`Error adding parameter ${i + 1}`, paramError.response ? paramError.response.data : paramError.message)}
        }
        this.$emit('add-input');
      }catch (error) {
        console.log('Error', error);
      }
    },
  },
}

</script>

<template>
  <!--  add machine dialog which covers list -->
  <div>
    <h1>Add Process</h1>
    <form @submit.prevent="addObject">
      <div>
        <label for="serial-num-input">Serial number: </label>
        <input class="inputTxt" type="text" id="serial-num-input" v-model="localObject.serialNumber"
               pattern="[a-zA-Z0-9]+" required><br>
      </div>
      <div>
        <label for="order-select">Order: </label>
        <select id="order-select" v-model="localObject.orderId">
          <option v-for="order in orders" :key="order.id" :value="order.id">
            {{ order.code }}
          </option>
        </select>
      </div>
      <div>
        <label for="status-select">Status: </label>
        <select id="status-select" v-model="localObject.statusId">
          <option v-for="status in statuses" :key="status.id" :value="status.id">
            {{ status.name }}
          </option>
        </select>
      </div>
      <div v-for="x in addedParameters">
        <label for="parameter-select">Parameter: </label>
        <select id="parameter-select" v-model="x.parameterId">
          <option v-for="parameter in parameters" :key="parameter.id" :value="parameter.id">
            {{ parameter.name }}
          </option>
        </select>
        <label style="margin-left: 10%" id="parameter-value-label" for="parameter-value">Value: </label>
        <input class="inputTxt" id="parameter-value" type="number" v-model="x.value" required>
      </div>
      <button id="addButton" type="button" @click="addedParameters.push({processId : 0})">
        +
      </button>
      <div class='buttons'>
        <button type="submit">Add</button>
        <button type="reset" @click="$emit('cancelForm')">Cancel</button>
      </div>
    </form>
  </div>
</template>

<style scoped>

</style>