<template>
  <v-container>
    <v-card class="pa-5 mb-5">
      <v-form v-model="valid" ref="form" @submit.prevent="submitForm">
        <v-text-field
          v-model="newSchool.title"
          label="Title"
          :rules="[rules.required]"
        ></v-text-field>
        <v-text-field
          v-model="newSchool.numberOfRooms"
          label="Number of Rooms"
          :rules="[rules.required, rules.number]"
          type="number"
        ></v-text-field>
        <v-btn :disabled="!valid" color="success" type="submit">
          Add School
        </v-btn>
      </v-form>
    </v-card>
    <v-text-field
      v-model="searchTerm"
      label="Search"
      @input="fetchSchools"
    ></v-text-field>
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
          <td>{{ item.numberOfRooms }}</td>
          <td>
            <v-icon @click="deleteSchool(item.schoolId)" color="black">
              mdi-trash-can
            </v-icon>
          </td>
        </tr>
      </template>
      <template v-slot:no-data>
        <v-alert type="error" :value="true">No data available</v-alert>
      </template>
    </v-data-table>
  </v-container>
</template>

<script lang="ts">
import { defineComponent, ref, onMounted } from "vue";
import {
  getSchools,
  createSchool,
  deleteSchool,
} from "@/services/schoolService";
import type { School } from "@/models/School";

export default defineComponent({
  name: "School",

  setup() {
    const schools = ref<School[]>([]);
    const headers = ref([
      { title: "Id", value: "schoolId" },
      { title: "Title", value: "title" },
      { title: "Number Of Rooms", value: "numberOfRooms" },
      { title: "Actions", value: "actions", sortable: false },
    ]);

    const valid = ref(false);
    const newSchool = ref<Partial<School>>({
      title: "",
      numberOfRooms: 0,
    });

    const searchTerm = ref<string>("");

    const rules = {
      required: (value: any) => !!value || "Required.",
      number: (value: any) => !isNaN(value) || "Must be a number.",
    };

    const fetchSchools = async () => {
      const response = await getSchools(searchTerm.value);
      schools.value = response;
    };

    const handleDelete = async (id: number) => {
      await deleteSchool(id);
      await fetchSchools();
    };

    const submitForm = async () => {
      if (valid.value) {
        await createSchool(newSchool.value as School);
        newSchool.value.title = "";
        newSchool.value.numberOfRooms = 0;
        await fetchSchools();
      }
    };

    onMounted(() => {
      fetchSchools();
    });

    return {
      schools,
      headers,
      valid,
      newSchool,
      rules,
      searchTerm,
      deleteSchool: handleDelete,
      submitForm,
      fetchSchools,
    };
  },
});
</script>

<style scoped></style>
