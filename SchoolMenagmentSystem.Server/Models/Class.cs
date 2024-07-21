using SchoolMenagmentSystem.Server.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagmentSystem.Server.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        [Required]
        [Range(1, 12)]
        public int GradeLevel { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
    }
}
