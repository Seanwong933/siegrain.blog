// 路由文件，配置着 url 路径 和 页面的关系
import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home.vue'

Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  /*
    Knowledge:
    这里有两种路由模式
    第一种是 Home 页面使用的，在上面引入之后再在下面使用
    第二种是 about，直接导入路径
   */
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/about',
      name: 'about',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import(/*webpackChunkName: "about",*/ './views/About.vue')
    }
  ]
})
