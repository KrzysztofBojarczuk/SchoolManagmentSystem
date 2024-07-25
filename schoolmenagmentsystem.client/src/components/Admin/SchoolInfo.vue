<template>
  <v-container>
    <h2 class="ml-6">School Info</h2>
    <v-row no-gutters class="pa-5">
      <v-col cols="12" sm="6">
        <v-card class="pa-5 my-6">
          <v-card-text>
            <p>School ID: {{ schoolId }}</p>
            <p>Number of Classes: {{ numberOfClasses }}</p>
          </v-card-text>
        </v-card>

        <v-card class="pa-5 my-6">
          <v-card-title>Address</v-card-title>
          <v-card-text>
            <div v-if="address">
              <p>City: {{ address.city }}</p>
              <p>Street: {{ address.street }}</p>
              <p>Number: {{ address.number }}</p>
              <p>Zip Code: {{ address.zipCode }}</p>
            </div>
            <div v-else>
              <p>No address available.</p>
            </div>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import { onMounted, ref } from "vue";
import { useRoute } from "vue-router";
import { getNumberOfClass } from "@/services/classService";
import { getAddressBySchoolId } from "@/services/addressService";
import type { Address } from "@/models/Address";

const route = useRoute();
const schoolId = route.params.id;
const numberOfClasses = ref<number | null>(null);
const address = ref<Address | null>(null);

onMounted(async () => {
  numberOfClasses.value = await getNumberOfClass(Number(schoolId));

  address.value = await getAddressBySchoolId(Number(schoolId));
});
</script>

<style scoped></style>
