<template>
  <v-container>
    <v-card class="pa-5">
      <v-card-title>School Info</v-card-title>
      <v-card-text>
        <p>School ID: {{ schoolId }}</p>
        <p>Number of Classes: {{ numberOfClasses }}</p>
      </v-card-text>
    </v-card>
  </v-container>
</template>

<script setup lang="ts">
import { onMounted, ref } from "vue";
import { useRoute } from "vue-router";
import { getNumberOfClass } from "@/services/classService";

const route = useRoute();
const schoolId = route.params.id;
const numberOfClasses = ref<number | null>(null);

onMounted(async () => {
  numberOfClasses.value = await getNumberOfClass(Number(schoolId));
});
</script>

<style scoped></style>
