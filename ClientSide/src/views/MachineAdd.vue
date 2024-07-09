<script>
import axios from 'axios';
import '@/assets/buttons.css';

export default {
  props: ['argId', 'argName', 'argDescription'],
  data() {
    return {
      machineData: {
        name: this.argName,
        description: this.argDescription,
      },
      buttonMode: "",
      mode:"",
      inputId: this.argId,
    }
  },
  mounted() {
    if (this.argId !== 0) {
      this.buttonMode = 'Update';
      this.mode = 'Update Machine';
      
    } else {
      console.log('No machine data');
      this.buttonMode = 'Add';
      this.mode = 'Add Machine';
    }
  },
  methods: {
    async addMachine() {
      console.log(this.machine);
      await axios.put('http://localhost:23988/api/machine/add', this.machineData)
          .then(response => {
            console.clear();
            console.log('Response', response.data);
            this.$router.push({name: 'machineDetail', params: {id: response.data.id}});
          })
          .catch(error => {
            console.log('Error', error);
          })
    },
    showMachine() {
      console.log(this.machine);
      console.log(this.machineData);
    }
  }
};

</script>

<template>
  <h1>{{ mode }}</h1>
  <div>
    <form @submit.prevent="addMachine">
      <div>
        <label for="id">Id:</label>
        <input class="inputTxt" v-model="inputId" type="text" id="id" required><br>
      </div>
      <div>
        <label for="name">Name:</label>
        <input class="inputTxt" type="text" id="name" v-model="machineData.name" required><br>
      </div>
      <div>
        <label for="description">Description:</label>
        <input class="inputTxt" type="text" id="description" v-model="machineData.description" required><br>
      </div>
      <div id='buttons'>
        <button type="submit">{{ buttonMode }}</button>
      </div>
    </form>
  </div>
  <button @click="showMachine">show</button>
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

label {
  font-weight: bold;
}
</style>
