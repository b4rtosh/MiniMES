<script>
import '@/assets/forms.css';
export default{
  name: 'ParameterUptForm',
  props: {
    selectedObject: {
      type: Object,
      default: null,
    }
  },
  data(){
    return{
      localObject: {...this.selectedObject}
    }

  },
  methods: {
    submitForm() {
      this.$emit('submitForm', this.localObject);
    },
  },}

</script>

<template>
  <!--  add machine dialog which covers list -->
  <div>
    <h1>Update Parameter</h1>
    <form @submit.prevent="submitForm">
      <div>
        <label for="idInput">Id:</label>
        <input class="inputTxt" type="text" id="idInput" v-model="localObject.id" disabled>
      </div>
      <div>
        <label for="nameInput">Name:</label>
        <input class="inputTxt" type="text" id="nameInput" v-model="localObject.name" pattern="[a-zA-Z\ ]" required><br>
      </div>
      <div>
        <label for="unitInput">Unit:</label>
        <input class="inputTxt" type="text" id="unitInput" v-model="localObject.unit" pattern="[a-zA-Z\ ]" required><br>
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