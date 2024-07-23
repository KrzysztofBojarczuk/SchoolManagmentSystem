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
      name: "School",
      component: School,
    },
    {
      path: "/homepage",
      name: "Homepage",
      component: Homepage,
    },
  ],
});

export default router;
