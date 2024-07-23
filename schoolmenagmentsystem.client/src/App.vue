<template>
  <v-app>
    <v-app-bar :elevation="2">
      <v-list class="d-flex">
        <v-list-item
          v-for="(menu, index) in menus"
          :key="index"
          @click="navigateTo(menu.path)"
        >
          <v-list-item-title>{{ menu.name }}</v-list-item-title>
        </v-list-item>
      </v-list>
    </v-app-bar>
    <v-main>
      <router-view />
    </v-main>
  </v-app>
</template>

<script setup lang="ts">
import { ref } from "vue";
import { useRouter } from "vue-router";

const menus = ref([
  { name: "Home", path: "/homepage" },
  { name: "List of Schools", path: "/school" },
]);

const router = useRouter();

const navigateTo = (path: string) => {
  router.push(path);
};
</script>

<style scoped></style>
