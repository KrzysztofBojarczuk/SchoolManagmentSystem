using Microsoft.Extensions.Hosting;
using SchoolManagmentSystem.Server.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolMenagmentSystem.Server.Models
{
    public class School
    {
        [Key]
        public int SchoolId { get; set; }
        public string Title { get; set; }
        public int NumberOfClasses { get; set; }
        public ICollection<Class> Clases { get; } = new List<Class>();
    }
}
