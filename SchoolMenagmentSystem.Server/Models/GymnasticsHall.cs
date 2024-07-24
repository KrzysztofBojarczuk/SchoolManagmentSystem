using SchoolMenagmentSystem.Server.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagmentSystem.Server.Models
{
    public class GymnasticsHall
    {
        [Key]
        public int GymnasticsHallId { get; set; }
        public int GymnasticsHallNumber { get; set; }
        public double Surface { get; set; }
        public bool NeedsRepair { get; set; }
        public DateTime? BusyFrom { get; set; }
        public DateTime? BusyTo { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
    }
}
