import School from "@/components/Admin/School.vue";
import Home from "@/views/Home.vue";
import { createRouter, createWebHistory } from "vue-router";

const router = createRouter({
  history: createWebHistory(),
  routes: [
    {
      path: "/",
      component: School,
    },
    {
      path: "/school",
      component: School,
    },
    {
      path: "/home",
      component: Home,
    },
  ],
});

export default router;
