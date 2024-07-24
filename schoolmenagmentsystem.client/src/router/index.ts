import School from "@/components/Admin/School.vue";
import Homepage from "@/views/Homepage.vue";
import { createRouter, createWebHistory } from "vue-router";
import SchoolInfo from "@/components/Admin/SchoolInfo.vue";

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
      path: "/school/:id",
      name: "SchoolInfo",
      component: SchoolInfo,
      props: true,
    },
    {
      path: "/homepage",
      name: "Homepage",
      component: Homepage,
    },
  ],
});

export default router;
