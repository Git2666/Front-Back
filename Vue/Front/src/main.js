import { createApp } from 'vue'
import axios from 'axios';

import './style.css'
import App from './App.vue'
import router from './router/router.js'



// 请求拦截器
axios.interceptors.request.use(config => {
    // 从 localStorage 中获取 token
    const token = localStorage.getItem('token');
  
    // 如果 token 存在，添加到请求头中
    if (token) {
      config.headers['Authorization'] = `Bearer ${token}`;
    }
  
    return config;
  }, error => {
    return Promise.reject(error);
  });

createApp(App).use(router).mount('#app')
