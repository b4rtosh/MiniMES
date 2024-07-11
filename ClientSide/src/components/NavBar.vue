<script>

</script>

<template>
  <nav class="navbar">
    <ul class="navbar-nav">
      <li class="nav-item">
        <router-link to="/machines" class="nav-link">Machines</router-link>
      </li>
      <li class="nav-item">
        <router-link to="/orders" class="nav-link">Orders</router-link>
      </li>
      <li class="nav-item">
        <router-link to="/products" class="nav-link">Products</router-link>
      </li>
      <li class="nav-item">
        <router-link to="/parameters" class="nav-link">Parameters</router-link>
      </li>
   <li class="nav-item">
        <router-link to="/statuses" class="nav-link">Statuses</router-link>
      </li>
    </ul>
  </nav>

</template>

<style scoped>
.navbar {
  display: flex;
  justify-content: center;
  background-color: grey;
  border-radius: 10px;
}

.navbar-nav {
  list-style: none;
  padding: 10px;
  margin: 0;
  display: flex;
}

.nav-item {
  color: white;
  margin: 0 20px;

}

.nav-link {
  color: #fff; /* White text color */
  text-decoration: none; /* No underline */
  margin: 0 10px; /* Margin on all sides */
}

/* Hover state */
.nav-link:hover {
  color: #4c9baf; /* Change color on hover */
}

/* Active link state */
.router-link-active {
  color: #d5d4d4; 
  font-weight: bold;
}


</style>