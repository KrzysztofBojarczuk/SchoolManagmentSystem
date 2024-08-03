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
        <v-autocomplete
          label="Type of School"
          :items="schoolTypeOptions"
          item-title="text"
          item-value="value"
          v-model="newSchool.type"
        ></v-autocomplete>
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
          <td>{{ getSchoolTypeText(item.type) }}</td>
          <td>
            <v-icon @click="handleDelete(item.schoolId)" color="black">
              mdi-trash-can
            </v-icon>
            <v-icon @click="handleInfo(item.schoolId)">
              mdi-information
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

<script setup lang="ts">
import { defineComponent, ref, onMounted } from "vue";
import {
  getSchoolsService,
  createSchoolService,
  deleteSchoolService,
} from "@/services/schoolService";
import type { School } from "@/models/School";
import { SchoolType } from "@/enums/SchoolType";
import { getSchoolTypeText } from "@/enums/getSchoolTypeText";
import router from "@/router";

const schoolTypeOptions = ref([
  { text: "Technical School", value: SchoolType.TechnicalSchool },
  { text: "High School", value: SchoolType.HighSchool },
  { text: "Elementary School", value: SchoolType.ElementarySchool },
]);

const schools = ref<School[]>([]);

const headers = ref([
  { title: "Id", value: "schoolId" },
  { title: "Title", value: "title" },
  { title: "Number Of Rooms", value: "numberOfRooms" },
  { title: "Type Of School", value: "type" },
  { title: "Actions", value: "actions", sortable: false },
]);

const valid = ref(false);

const newSchool = ref<Partial<School>>({
  title: "",
  numberOfRooms: 0,
  type: SchoolType.TechnicalSchool,
});
const searchTerm = ref<string>("");

const rules = {
  required: (value: any) => !!value || "Required.",
  number: (value: any) => !isNaN(value) || "Must be a number.",
};

const fetchSchools = async () => {
  const response = await getSchoolsService(searchTerm.value);
  schools.value = response;
};

const handleDelete = async (id: number) => {
  await deleteSchoolService(id);
  await fetchSchools();
};

const handleInfo = (id: number) => {
  router.push({ name: "SchoolInfo", params: { id } });
};

const submitForm = async () => {
  await createSchoolService(newSchool.value as School);
  newSchool.value.title = "";
  newSchool.value.numberOfRooms = 0;
  newSchool.value.type = SchoolType.TechnicalSchool;
  await fetchSchools();
};

onMounted(() => {
  fetchSchools();
});
</script>

<style scoped></style>
<!-- ref, Vue sprawia, że ​​wartość staje się reaktywna, więc jeśli 
się zmieni, komponent zareaguje na te zmiany i odpowiednio zaktualizuje DOM lub inne reaktywne właściwości. -->
