
import { createApp } from 'vue';
import App from './App.vue';
import router from './routers/router';
import './assets/globalStyles.css';


export const API_URL = `http://localhost:${import.meta.env.VITE_API_PORT}/api`;
createApp(App).use(router).mount('#app');