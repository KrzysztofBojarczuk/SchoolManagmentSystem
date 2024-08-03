import axios from "axios";
import type { Class } from "@/models/Class";

const API_URL = "https://localhost:7290/api/Class";

export const getClassesForSchoolByIdService = async (
  schoolId: number
): Promise<Class[]> => {
  const response = await axios.get(`${API_URL}/school/${schoolId}`);
  return response.data;
};

export const getClassbyIdService = async (
  schoolId: number,
  classId: number
): Promise<Class> => {
  const response = await axios.delete(
    `${API_URL}/school/${schoolId}/class/${classId}`
  );
  return response.data;
};

export const createClassService = async (
  schoolId: number,
  createClass: Class
): Promise<Class> => {
  const response = await axios.post(
    `${API_URL}/school/${schoolId}`,
    createClass
  );
  return response.data;
};

export const updateClassService = async (
  schoolId: number,
  classToUpdate: Class
): Promise<Class> => {
  const response = await axios.put(
    `${API_URL}/school/${schoolId}/class/${classToUpdate.classId}`,
    classToUpdate
  );
  return response.data;
};

export const deleteClassService = async (
  schoolId: number,
  classId: number
): Promise<void> => {
  await axios.delete(`${API_URL}/school/${schoolId}/class/${classId}`);
};

export const getNumberOfClassService = async (
  schoolId: number
): Promise<number> => {
  const response = await axios.get(
    `${API_URL}/getNumberOfSchool?schoolId=${schoolId}`
  );
  return response.data;
};
