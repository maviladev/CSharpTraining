using Microsoft.EntityFrameworkCore;
using PatternCQRS_Sample.Domain;
using System;

namespace PatternCQRS_Sample.Persistence
{
    public class AppDbContext: DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        { }

        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().Property(c => c.Price).HasPrecision(14, 2);

            modelBuilder.Entity<Course>().HasData(
                new Course { 
                    CourseId = Guid.NewGuid(),
                    Title = "C# Basic",
                    Description = "C# for beginners",
                    CreationDate = DateTime.Now,
                    PublishDate = DateTime.Now.AddMonths(2),
                    Price = 150
                });

            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    CourseId = Guid.NewGuid(),
                    Title = "Go Basic",
                    Description = "Go for beginners",
                    CreationDate = DateTime.Now,
                    PublishDate = DateTime.Now.AddMonths(3),
                    Price = 150
                });

            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    CourseId = Guid.NewGuid(),
                    Title = "Android Basic",
                    Description = "Android for beginners",
                    CreationDate = DateTime.Now,
                    PublishDate = DateTime.Now.AddMonths(4),
                    Price = 150
                });

            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    CourseId = Guid.NewGuid(),
                    Title = "iOS Basic",
                    Description = "iOS for beginners",
                    CreationDate = DateTime.Now,
                    PublishDate = DateTime.Now.AddMonths(5),
                    Price = 150
                });
        }


    }
}
