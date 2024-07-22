import type { SchoolType } from "@/enums/SchoolType";

export interface School {
  schoolId: number;
  title: string;
  numberOfRooms: number;
  type: SchoolType;
}
