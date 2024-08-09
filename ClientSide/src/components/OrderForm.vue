<script>
import '@/assets/forms.css';
import axios from "axios";
export default{
  name: 'OrderForm',
  props: ['route'],
  data(){
    return{
      localObject: {
        code: '',
        quantity: '',
        machineId: 0,
        productId: 0,
      },
      machines:[],
      products:[],
    }
  },
  created(){
    this.getAllMachines();
    this.getAllProducts();
  },
  methods:{
    submitForm(){
      this.$emit('add-input', this.localObject);
    },
    async getAllMachines(){
      this.machines = await axios.get(`${this.route}/Machine/all`)
          .then(response => response.data.$values)
          .catch(error => console.log(error));
    },
    async getAllProducts(){
      this.products = await axios.get(`${this.route}/Product/all`)
          .then(response => response.data.$values)
          .catch(error => console.log(error));
    },
  }}

</script>

<template>
  <!--  add machine dialog which covers list -->
  <div>
    <h1>Add Machine</h1>
    <form @submit.prevent="submitForm">
      <div>
        <label for="codeInput">Code: </label>
        <input class="inputTxt" 
               type="text" 
               id="codeInput" 
               v-model="localObject.code"
               pattern="^(?!\s)[\w]+(?<!\s)$"
               placeholder="Letters, digits"
               required><br>
      </div>
      <div>
        <label for="quantityInput">Quantity: </label>
        <input class="inputTxt" 
               type="number" 
               id="quantityInput"
               pattern="^(?!\s)[\w]+(?<!\s)$"
               placeholder="Number"
               v-model="localObject.quantity" 
               required><br>
      </div>
      <div>
        <label for="machine-select">Machine Id: </label>
        <select id="machine-select" v-model="localObject.machineId">
          <option v-for="machine in machines" :key="machine.id" :value="machine.id">
            {{machine.name}}
          </option>
        </select>
      </div>
      <div>
        <label for="product-select">Product Id: </label>
        <select id="product-select" v-model="localObject.productId">
          <option v-for="product in products" :key="product.id" :value="product.id">
            {{product.code}}
          </option>
        </select>
      </div>
      <div class='buttons'>
        <button type="submit">Add</button>
        <button type="reset" @click="$emit('cancelForm')">Cancel</button>
      </div>
    </form>
  </div>
</template>

<style scoped>

</style>