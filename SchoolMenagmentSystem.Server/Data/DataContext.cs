using Microsoft.EntityFrameworkCore;
using SchoolManagmentSystem.Server.Models;
using SchoolMenagmentSystem.Server.Models;

namespace SchoolMenagmentSystem.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<School> Schools { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<GymnasticsHall> GymnasticsHalls { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
