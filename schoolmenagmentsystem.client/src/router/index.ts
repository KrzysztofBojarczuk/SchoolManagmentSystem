import School from "@/components/Admin/School.vue";
import Homepage from "@/views/Homepage.vue";
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
      path: "/homepage",
      component: Homepage,
    },
  ],
});

export default router;
