using SchoolMenagmentSystem.Server.Models;

namespace SchoolManagmentSystem.Server.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string ZipCode { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
    }
}
