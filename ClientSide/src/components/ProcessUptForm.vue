<script>
import '@/assets/forms.css';
import axios from "axios";

export default {
  name: 'ProcessUptForm',
  props: {
    selectedObject: {
      type: Object,
      default: null,
    },
    route: {
      type: String,
      default: '',
    }
  },
  data() {
    return {
      localObject: {...this.selectedObject},
      orders: [],
      statuses: [],
      parameters: [],
      updatedParameter: {
        id: 0,
        processId: 0,
        parameterId: 0,
        value: 0,
      },
      addedParameters: [],
    }

  },
  created() {
    this.getAllOrders();
    this.getAllStatuses();
    this.getAllParameters();
    this.addParameters();
  },
  methods: {
    addParameters() {
      for (let i = 0; i < this.selectedObject.processParameters.$values.length; i++) {
        this.addedParameters.push({
              id: this.selectedObject.processParameters.$values[i].id,
              processId: this.selectedObject.id,
              value: this.selectedObject.processParameters.$values[i].value,
              parameterId: this.selectedObject.processParameters.$values[i].parameterId,
            }
        )
      }
    },
    async getAllOrders() {
      this.orders = await axios.get(`${this.route}/Process/api/Order/all`)
          .then(response => response.data.$values)
          .catch(error => console.log(error));
    },
    async getAllStatuses() {
      this.statuses = await axios.get(`${this.route}/Process/api/Status/all`)
          .then(response => response.data.$values)
          .catch(error => console.log(error));
    },
    async getAllParameters() {
      this.parameters = await axios.get(`${this.route}/Process/api/Param/all`)
          .then(response => response.data.$values)
          .catch(error => console.log(error));
    },
    async updateObject() {
      console.log('Update');
      try {
        let response = await axios.post(`${this.route}/Process/update`, this.localObject);
        for (let i = 0; i < this.addedParameters.length; i++) {
          console.log(this.addedParameters[i]);
          try {
            response = await axios.post(`${this.route}/ProcessParam/update`, this.addedParameters[i]);
            console.log('Reponse', response.data);
          } catch (paramError) {
            console.log(`Error adding parameter ${i + 1}`, paramError.response ? paramError.response.data : paramError.message)
          }
        }
        this.$emit('submitForm');
      } catch (error) {
        console.log('Error', error);
      }
    },
  },
}

</script>

<template>
  <!--  add machine dialog which covers list -->
  <div>
    <h1>Update Process</h1>
    <form @submit.prevent="updateObject">
      <div>
        <label for="serial-num-input">Serial number: </label>
        <input class="inputTxt"
               type="text"
               id="serial-num-input"
               v-model="localObject.serialNumber"
               pattern="^(?!\s)[\w]+(?<!\s)$"
               placeholder="Letters, digits"
               required><br>
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
        <input class="inputTxt"
               id="parameter-value"
               type="number"
               v-model="x.value"
               pattern="^(?!\s)[\w]+(?<!\s)$"
               placeholder="Number"
               required>
      </div>
      <!--      <button id="addButton" type="button" @click="addedParameters.push({processId : this.localObject.id})">-->
      <!--        +-->
      <!--      </button>-->
      <div class='buttons'>
        <button type="submit">Save</button>
        <button type="reset" @click="$emit('cancelForm')">Cancel</button>
      </div>
    </form>
  </div>
</template>

<style scoped>

</style>