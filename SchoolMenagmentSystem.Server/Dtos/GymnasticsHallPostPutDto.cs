using SchoolMenagmentSystem.Server.Models;

namespace SchoolManagmentSystem.Server.Dtos
{
    public class GymnasticsHallPostPutDto
    {
        public int GymnasticsHallNumber { get; set; }
        public double Surface { get; set; }
        public bool NeedsRepair { get; set; }
        public DateTime? BusyFrom { get; set; }
        public DateTime? BusyTo { get; set; }
    }
}
