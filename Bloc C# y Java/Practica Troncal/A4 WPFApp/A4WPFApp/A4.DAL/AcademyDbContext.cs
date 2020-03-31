using System;
using Microsoft.EntityFrameworkCore;
using A4.Lib.Models;
using Common.Lib.Core;



namespace A4_DAL
{
    public class AcademyDbContext : DbContext
    {
        public AcademyDbContext(DbContextOptions<AcademyDbContext> options) : base (options)
        {

        }

        private DbSet<Student> StudentDb { get; set; }

        private DbSet<Subject> SubjectDb { get; set; }

        private DbSet<Exam> ExamDb { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Entity>()
                .Ignore(x => x.CurrentValidation);
        }
    }
}
