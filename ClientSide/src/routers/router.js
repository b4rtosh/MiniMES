import {createRouter, createWebHistory} from 'vue-router';
import Machines from "@/views/Machines.vue";
import Orders from "@/views/Orders.vue";
import Products from "@/views/Products.vue";
import Parameters from "@/views/Parameters.vue";
import Home from "@/views/Home.vue";
import Statuses from "@/views/ProcStatuses.vue";
import Processes from "@/views/Processes.vue";

// Define routes
const routes = [
    {path: '/', component: Home},
    {path: '/machines', component: Machines, name: 'Machines'},
    {path: '/orders', component: Orders},
    {path: '/products', component: Products},
    {path: '/parameters', component: Parameters},
    {path: '/statuses', component: Statuses},
    {path: '/processes', component: Processes},
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;