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

              <div class="mt-3">
                <v-btn class="mr-6" @click="openUpdateDialog">
                  Update Address
                </v-btn>
                <v-btn color="red" @click="handleDelete">
                  Delete Address
                </v-btn>
              </div>
            </div>
            <div v-else>
              <p>No address available.</p>
              <v-btn class="mt-3" @click="openAddDialog"> Add Address </v-btn>
            </div>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>

    <!-- Add Address Dialog -->
    <v-dialog v-model="addDialog" max-width="600px">
      <v-card>
        <v-card-title>
          <span class="headline">Add Address</span>
        </v-card-title>
        <v-card-text>
          <v-form v-model="valid">
            <v-text-field
              v-model="newAddress.city"
              label="City"
              :rules="[rules.required]"
              required
            />
            <v-text-field
              v-model="newAddress.street"
              label="Street"
              :rules="[rules.required]"
              required
            />
            <v-text-field
              v-model="newAddress.number"
              label="Number"
              :rules="[rules.required]"
              required
            />
            <v-text-field
              v-model="newAddress.zipCode"
              label="Zip Code"
              :rules="[rules.required]"
              required
            />
          </v-form>
        </v-card-text>
        <v-card-actions class="pa-5">
          <v-btn @click="addDialog = false">Cancel</v-btn>
          <v-btn color="primary" :disabled="!valid" @click="addAddress">
            Add Address
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>

    <!-- Update Address Dialog -->
    <v-dialog v-model="updateDialog" max-width="600px">
      <v-card>
        <v-card-title>
          <span class="headline">Update Address</span>
        </v-card-title>
        <v-card-text>
          <v-form v-model="valid">
            <v-text-field
              v-model="selectedAddress.city"
              label="City"
              :rules="[rules.required]"
              required
            />
            <v-text-field
              v-model="selectedAddress.street"
              label="Street"
              :rules="[rules.required]"
              required
            />
            <v-text-field
              v-model="selectedAddress.number"
              label="Number"
              :rules="[rules.required]"
              required
            />
            <v-text-field
              v-model="selectedAddress.zipCode"
              label="Zip Code"
              :rules="[rules.required]"
              required
            />
          </v-form>
        </v-card-text>
        <v-card-actions class="pa-5">
          <v-btn @click="updateDialog = false">Cancel</v-btn>
          <v-btn color="primary" :disabled="!valid" @click="updateAddress">
            Update Address
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-container>
</template>

<script setup lang="ts">
import { ref, onMounted } from "vue";
import { useRoute } from "vue-router";
import { getNumberOfClassService } from "@/services/classService";
import {
  getAddressByIdService,
  deleteAddressService,
  createAddressService,
  updateAddressService,
} from "@/services/addressService";
import type { Address } from "@/models/Address";
import type { AddressCreateDTO } from "@/models/AddresCreateDTO";

const route = useRoute();
const schoolId = Number(route.params.id);
const numberOfClasses = ref<number | null>(null);
const address = ref<Address | null>(null);
const addDialog = ref(false);
const updateDialog = ref(false);
const valid = ref(false);
const newAddress = ref<AddressCreateDTO>({
  city: "",
  street: "",
  number: "",
  zipCode: "",
});

const selectedAddress = ref<AddressCreateDTO>({
  city: "",
  street: "",
  number: "",
  zipCode: "",
});

const rules = {
  required: (value: any) => !!value || "Required.",
};

const handleDelete = async () => {
  await deleteAddressService(schoolId);
  await fetchAddress();
};

const fetchAddress = async () => {
  address.value = await getAddressByIdService(schoolId);
  if (address.value) {
    selectedAddress.value = { ...address.value };
  }
};

const addAddress = async () => {
  await createAddressService(schoolId, newAddress.value);
  addDialog.value = false;
  await fetchAddress();
};

const updateAddress = async () => {
  await updateAddressService(schoolId, selectedAddress.value);
  updateDialog.value = false;
  await fetchAddress();
};

const openUpdateDialog = () => {
  updateDialog.value = true;
};

const openAddDialog = () => {
  addDialog.value = true;
};

onMounted(async () => {
  numberOfClasses.value = await getNumberOfClassService(schoolId);
  await fetchAddress();
});
</script>
