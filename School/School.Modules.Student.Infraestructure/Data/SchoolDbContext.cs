using Microsoft.EntityFrameworkCore;
using School.Modules.Student.Infraestructure.Entity;

namespace School.Modules.Student.Infraestructure.Data
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<StudentEntity> Students {  get; set; }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
