using Microsoft.Extensions.Hosting;
using SchoolManagmentSystem.Server.Enums;
using SchoolManagmentSystem.Server.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolMenagmentSystem.Server.Models
{
    public class School
    {
        [Key]
        public int SchoolId { get; set; }
        public string Title { get; set; }
        public int NumberOfRooms { get; set; }
        public SchoolType Type { get; set; }
        public ICollection<Class> Clases { get; } = new List<Class>();
    }
}
