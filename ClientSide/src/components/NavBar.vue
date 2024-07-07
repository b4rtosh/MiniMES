<script>
  export default {
    data()
  {
    return{
    first: 'Machines',
      second: 'Orders',
      third: 'Products',
      fourth: 'Parameters'
  }
}
}
</script>

<template>
  <nav class="navbar">
    <ul class="navbar-nav">
      <li class="nav-item" v-bind:id="firstItem" >
        <a href="/machines" class="nav-link">{{ first }}</a>
      </li>
      <li class="nav-item" >
        <a href="/about" class="nav-link" >{{ second }}</a>
      </li>
      <li class="nav-item">
        <a href="/services" class="nav-link">{{third}}</a>
      </li>
      <li class="nav-item">
        <a href="/contact" class="nav-link">{{ fourth }}</a>
      </li>
    </ul>
  </nav>
</template>

<style scoped>
@import "https://fonts.googleapis.com/css2?family=Roboto:wght@400;500&display=swap";
.navbar {
  display: flex;
  justify-content: center;
  background-color: #333;
}

.navbar-nav {
  list-style: none;
  padding: 10px;
  margin: 0;
  display: flex;
}

.nav-item {
  margin: 0 20px;
}

.nav-link {
  text-decoration: none;
  color: white;
  transition: color 0.3s ease;
}

.nav-link:hover {
  color: #ddd;
}
</style>