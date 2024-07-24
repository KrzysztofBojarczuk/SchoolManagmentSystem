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
        public List<Class> Clases { get; set; }
        public Address Addres { get; set; }
        public List<GymnasticsHall> GymnasticsHalls { get; set; }
    }
}
