using SchoolManagmentSystem.Server.Enums;

namespace SchoolMenagmentSystem.Server.Dtos
{
    public class SchoolCreateDto
    {
        public string Title { get; set; }
        public int NumberOfRooms { get; set; }
        public SchoolType Type { get; set; }
    }
}
