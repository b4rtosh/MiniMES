<script>
import '@/assets/forms.css';
export default{
  name: 'ProductForm',
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
    <h1>Add Product</h1>
    <form @submit.prevent="submitForm">
      <div>
        <label for="codeInput">Code:</label>
        <input class="inputTxt" 
               type="text" 
               id="codeInput"
               pattern="^(?!\s)[\w]+(?<!\s)$"
               placeholder="Letters, digits"
               v-model="localObject.code" 
               required><br>
      </div>
      <div>
        <label for="descriptionInput">Description:</label>
        <input class="inputTxt" 
               type="text" 
               id="descriptionInput"
               v-model="localObject.description"
               pattern="^(?!\s)[\w ]+(?<!\s)$"
               placeholder="Words, digits, backspaces"
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