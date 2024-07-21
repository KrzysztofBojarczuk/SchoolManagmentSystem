using SchoolMenagmentSystem.Server.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagmentSystem.Server.Dtos
{
    public class ClassGetDto
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int GradeLevel { get; set; }
    }
}
