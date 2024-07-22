import { SchoolType } from "./SchoolType";

export const getSchoolTypeText = (type: SchoolType): string => {
  switch (type) {
    case SchoolType.TechnicalSchool:
      return "Technical School";
    case SchoolType.HighSchool:
      return "High School";
    case SchoolType.ElementarySchool:
      return "Elementary School";
    default:
      return "";
  }
};
