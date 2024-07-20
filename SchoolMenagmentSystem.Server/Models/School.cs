using System.ComponentModel.DataAnnotations;

namespace SchoolMenagmentSystem.Server.Models
{
    public class School
    {
        [Key]
        public int SchoodId { get; set; }
        public string Title { get; set; }
        public int NumberOfClasses { get; set; }

    }
}
