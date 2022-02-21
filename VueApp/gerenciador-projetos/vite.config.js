import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

// https://vitejs.dev/config/
export default defineConfig({
    server: {
        proxy: {
            "/projeto/api": {
                target: "https://localhost",
                changeOrigin: true,
                secure: false
            },
            "/api": {
                target: "https://localhost:44345",
                changeOrigin: true,
                secure: false
            }
        }
    },
    plugins: [vue()]
})