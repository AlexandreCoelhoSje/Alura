import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import path from 'path'

// https://vitejs.dev/config/
export default defineConfig({
    server: {
        proxy: {
            "/projeto/api": {
                target: "https://localhost",
                changeOrigin: true,
                secure: false
            },
            "/planejamento/api": {
                target: "http://localhost",
                changeOrigin: true,
                secure: false
            }
        }
    },
    plugins: [vue()],
    resolve: {
        alias: {
            '@': path.resolve(__dirname, './src')
        },
    }
})