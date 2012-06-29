using System.Data.Entity;

namespace Demo.Data.Entity
{
    public class EntityContext : DbContext
    {
        public EntityContext(string connectionString)
            : base(connectionString)
        {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany<Course>(s => s.Courses)
                .WithMany(x => x.Students)
                .Map(x =>
                         {
                             x.MapLeftKey("CourseId");
                             x.MapRightKey("StudentId");
                             x.ToTable("StudentsCourses");
                         });

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}