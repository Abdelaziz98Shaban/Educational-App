using Microsoft.EntityFrameworkCore;

namespace UniAppDay2.Models
{
    public class UNIEntities:DbContext
    {
        public UNIEntities() { }
        public UNIEntities(DbContextOptions options):base(options) 
        { 
        }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Trainee> Trainee { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<CourseResult> CourseResult { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=UNIDB;Integrated Security=True");
        //}

    }
}







