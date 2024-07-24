using SchoolManagmentSystem.Server.Models;
using SchoolMenagmentSystem.Server.Models;

namespace SchoolManagmentSystem.Server.Dtos
{
    public class GymnasticsHallGetDto
    {
        public int GymnasticsHallId { get; set; }
        public int GymnasticsHallNumber { get; set; }
        public double Surface { get; set; }
        public bool NeedsRepair { get; set; }
        public DateTime? BusyFrom { get; set; }
        public DateTime? BusyTo { get; set; }
    }
}
