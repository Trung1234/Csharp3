using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace OnlineCourse.Models
{
    public class OnlineContext : DbContext
    {
        public OnlineContext(): base("OnlineContext")
        {
            

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Administrators> Administrators { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Student DB Config
            modelBuilder.Entity<Student>()
           .HasKey(c => c.Id);
            modelBuilder.Entity<Student>().Property(t => t.FirstName)
                .HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Student>().Property(t => t.LastName)
                .HasMaxLength(50).IsRequired();

            // Course DB Config
            modelBuilder.Entity<Course>()
           .HasKey(c => c.Id);
            modelBuilder.Entity<Course>().Property(t => t.Name)
                .HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Course>().Property(t => t.Description)
               .HasMaxLength(50).IsRequired();

            // Admin DB Config
            modelBuilder.Entity<Administrators>()
           .HasKey(c => c.Id);
            modelBuilder.Entity<Administrators>().Property(t => t.FirstName)
                .HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Administrators>().Property(t => t.LastName)
                .HasMaxLength(50).IsRequired();

            // configures one-to-many relationship
            modelBuilder.Entity<Student>()
                .HasRequired<Course>(s => s.Course)
                .WithMany(g => g.Students)
                .HasForeignKey<int>(s => s.CurrentCourseId);


            // configures many-to-many relationship
            //modelBuilder.Entity<Student>()
            //    .HasMany<Course>(s => s.Courses)
            //    .WithMany(c => c.Students)
            //    .Map(cs =>
            //    {
            //        cs.MapLeftKey("StudentRefId");
            //        cs.MapRightKey("CourseRefId");
            //        cs.ToTable("StudentVsCourse");
            //    });


            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}