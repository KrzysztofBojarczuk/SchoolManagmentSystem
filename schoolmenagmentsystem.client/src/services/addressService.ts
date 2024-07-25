import type { Address } from "@/models/Address";
import axios from "axios";

const API_URL = "https://localhost:7290/api/Address";

export const getAddressBySchoolId = async (
  schoolId: number
): Promise<Address> => {
  const response = await axios.get(`${API_URL}/${schoolId}`);
  return response.data;
};

export const createAddress = async (
  schoolId: number,
  address: Address
): Promise<Address> => {
  const response = await axios.post(`${API_URL}/${schoolId}`, address);
  return response.data;
};

export const updateAddress = async (
  schoolId: number,
  address: Address
): Promise<Address> => {
  const response = await axios.put(`${API_URL}/${schoolId}`, address);
  return response.data;
};

export const deleteAddress = async (
  schoolId: number,
  addressId: number
): Promise<void> => {
  await axios.delete(`${API_URL}/${schoolId}/${addressId}`);
};
