import {createRouter, createWebHistory} from 'vue-router';
import MachineAdd from "@/views/MachineAdd.vue";
import Machines from "@/views/Machines.vue";
import MachineDetail from "@/views/MachineDetail.vue";
import OrderAdd from "@/views/OrderAdd.vue";
import Orders from "@/views/Orders.vue";
import OrderDetail from "@/views/OrderDetail.vue";

//import EditMachine from "@/views/EditMachine.vue";
import Products from "@/views/Products.vue";
import Parameters from "@/views/Parameters.vue";
import Home from "@/views/Home.vue";


const routes = [
    {path: '/', component: Home},
    {path: '/machine', component: Machines},
    {path: '/machine/add', component: MachineAdd},
    {path: '/machine/:id', component: MachineDetail},
    {path: '/machine/:id/edit', component: MachineAdd, props: true},
    {path: '/machine/:id/delete', component: MachineDetail, props: true},
    {path: '/order', component: Orders},
    {path: '/order/add', component: OrderAdd},
    {path: '/order/:id', component: OrderDetail},
    {path: '/oder/:id/edit', component: OrderAdd, props: true},
    {path: '/order/:id/delete', component: OrderDetail, props: true},
    {path: '/product', component: Products},
    {path: '/parameter', component: Parameters},
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;