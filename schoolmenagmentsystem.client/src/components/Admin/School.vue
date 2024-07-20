<template>
  <v-data-table
    :headers="headers"
    :items="schools"
    item-key="schoolId"
    class="elevation-1"
  >
    <template v-slot:top>
      <v-toolbar flat>
        <v-toolbar-title>School List</v-toolbar-title>
      </v-toolbar>
    </template>
    <template v-slot:item="{ item }">
      <tr>
        <td>{{ item.schoolId }}</td>
        <td>{{ item.title }}</td>
        <td>{{ item.numberOfClasses }}</td>
      </tr>
    </template>
    <template v-slot:no-data>
      <v-alert type="error" :value="true">No data available</v-alert>
    </template>
  </v-data-table>
</template>

<script lang="ts">
import { defineComponent, ref, onMounted } from "vue";
import { getSchools } from "@/services/schoolService";
import type { School } from "@/models/School";

export default defineComponent({
  name: "School",
  setup() {
    //ref jest używane do tworzenia reaktywnych odniesień, które śledzą zmiany w wartościach. Oto jak to działa w praktyce:
    const schools = ref<School[]>([]);
    const headers = ref([
      { text: "Id", value: "schoolId" },
      { text: "Title", value: "title" },
      { text: "Number Of Classes", value: "numberOfClasses" },
    ]);

    const fetchSchools = async () => {
      const response = await getSchools();
      schools.value = response;
    };

    onMounted(() => {
      fetchSchools();
    });

    return {
      schools,
      headers,
    };
  },
});
</script>

<style scoped></style>
