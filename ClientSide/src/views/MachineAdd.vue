<script>
import axios from 'axios';
export default{
  name: 'Add Machine',
  data(){
    return{
      machine:{
        name: "",
        description: ""
      }
    };
  },
  methods: {
    async addMachine(){
      console.log(this.machine);
      await axios.put('http://localhost:23988/api/machine/add', this.machine)
          .then(response => console.log('Response', response.data))
          .catch(error => console.log('Error', error));
    }
  }
};

</script>

<template>
<h1>Add Machine</h1>
  <div>
  <form @submit.prevent="addMachine">
    <label for="name">Name:</label>
    <input class="inputTxt" type="text" id="name" v-model="machine.name" required><br>
    
    <label for="description">Description:</label>
    <input class="inputTxt" type="text" id="description" v-model="machine.description" required><br>
    <button type="submit">Add</button>
  </form>
  </div>
</template>

<style scoped>
/* GlobalStyles.css */

form {
  display: flex;
  flex-direction: column;
  gap: 10px;
  margin: 20px;
}

.inputTxt {
  padding: 8px;
  border: 1px solid #ccc;
  border-radius: 4px;
}

button {
  padding: 10px 20px;
  background-color: #007bff;
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

button:hover {
  background-color: #0056b3;
}

label {
  font-weight: bold;
}
</style>
