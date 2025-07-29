import { createRouter, createWebHistory } from 'vue-router'
import Login from '../views/Login.vue'
import Center from '../views/Center.vue'

const router= createRouter(
    {
        history: createWebHistory(),
        routes:[
            {path:'/', component:Login},
            {path:'/center', component:Center},

        ]
    }
)

// 模拟登录状态 (在实际项目中，可以通过Vuex或者其他状态管理工具进行存储)
function isLoggedIn() {
    return !!localStorage.getItem('token'); // 这里假设登录后会有一个token存储在localStorage
  }
  
// 全局路由守卫
router.beforeEach((to, from, next) => {
    if (to.path != '/' && !isLoggedIn()) {
        // 如果未登录并且尝试访问center页面，重定向到登录页面
        next('/');
    } else {
        // 如果已登录或者访问的不是center页面，允许路由跳转
        next();
    }
});

export default router