import {createRouter, createWebHistory} from 'vue-router';
import Machines from "@/views/Machines.vue";
import Orders from "@/views/Orders.vue";
import Products from "@/views/Products.vue";
import Parameters from "@/views/Parameters.vue";
import Home from "@/views/Home.vue";

// Define routes
const routes = [
    {path: '/', component: Home},
    {path: '/machines', component: Machines, name: 'Machines'},
    {path: '/orders', component: Orders},
    {path: '/products', component: Products},
    {path: '/parameters', component: Parameters},
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;