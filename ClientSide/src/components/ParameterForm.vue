<script>
import '@/assets/forms.css';
export default{
  name: 'ParameterForm',
  data(){
    return{
      localObject: {
        code: '',
        description: ''
      }
    }
  },
  methods:{
    submitForm(){
      this.$emit('add-input', this.localObject);
    }
  }}

</script>

<template>
  <!--  add machine dialog which covers list -->
  <div>
    <h1>Add Parameter</h1>
    <form @submit.prevent="submitForm">
      <div>
        <label for="nameInput">Name: </label>
        <input class="inputTxt"
               type="text"
               id="nameInput" 
               v-model="localObject.name"
               pattern="^(?!\s)[\w ]+(?<!\s)$"
               placeholder="Words, digits, backspaces"
               required><br>
      </div>
      <div>
        <label for="unitInput">Unit: </label>
        <input class="inputTxt" 
               type="text" 
               id="unitInput" 
               v-model="localObject.unit"
               pattern="^(?!\s)[\w\.\-]+(?<!\s)$"
               placeholder="Letters, digits, dots"
               required><br>
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