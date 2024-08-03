import type { AddressCreateDTO } from "@/models/AddresCreateDTO";
import type { Address } from "@/models/Address";
import axios from "axios";

const API_URL = "https://localhost:7290/api/Address";

export const getAddressByIdService = async (
  schoolId: number
): Promise<Address> => {
  const response = await axios.get(`${API_URL}/${schoolId}`);
  return response.data;
};

export const createAddressService = async (
  schoolId: number,
  address: AddressCreateDTO
): Promise<AddressCreateDTO> => {
  const response = await axios.post(`${API_URL}/${schoolId}`, address);
  return response.data;
};

export const updateAddressService = async (
  schoolId: number,
  address: AddressCreateDTO
): Promise<AddressCreateDTO> => {
  const response = await axios.put(`${API_URL}/${schoolId}`, address);
  return response.data;
};

export const deleteAddressService = async (schoolId: number): Promise<void> => {
  await axios.delete(`${API_URL}/${schoolId}`);
};
