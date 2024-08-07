import { fileURLToPath, URL } from 'node:url'

import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import dotenv from 'dotenv'

dotenv.config();

const port = process.env.VITE_PORT ? parseInt(process.env.VITE_PORT, 10) : 3000;

export default defineConfig({
  plugins: [
    vue(),
  ],
  server: {
    port:  port,
  },
  resolve: {
    alias: {
      '@': fileURLToPath(new URL('./src', import.meta.url))
    }
  }
})
