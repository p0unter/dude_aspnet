using Microsoft.EntityFrameworkCore;

namespace _4_entityapp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }

        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<CourseSave> CourseSaves => Set<CourseSave>();
    }
}
