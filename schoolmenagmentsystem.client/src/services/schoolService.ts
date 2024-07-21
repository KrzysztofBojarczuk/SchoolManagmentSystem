import axios from "axios";
import type { School } from "@/models/School";

const API_URL = "https://localhost:7290/api/School";

export const getSchools = async (searchTerm?: string): Promise<School[]> => {
  const response = await axios.get(API_URL, {
    params: { searchTerm },
  });
  return response.data;
};

export const getSchoolById = async (schoolId: number): Promise<School> => {
  const response = await axios.get(`${API_URL}/${schoolId}`);
  return response.data;
};

export const createSchool = async (school: School): Promise<School> => {
  const response = await axios.post(API_URL, school);
  return response.data;
};

export const updateSchool = async (schoolToUpdate: School): Promise<School> => {
  const response = await axios.put(
    `${API_URL}/${schoolToUpdate.schoolId}`,
    schoolToUpdate
  );
  return response.data;
};

export const deleteSchool = async (schoolId: number): Promise<void> => {
  await axios.delete(`${API_URL}/${schoolId}`);
};

//Promise to obiekt, który reprezentuje wynik operacji asynchronicznej, która może zakończyć się sukcesem lub niepowodzeniem.
