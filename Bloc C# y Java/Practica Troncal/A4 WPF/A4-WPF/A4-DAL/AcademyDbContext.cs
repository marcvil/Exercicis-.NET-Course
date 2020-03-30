using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using A4_WPF.Lib.Models;

namespace A4_DAL
{
    public class AcademyDbContext : DbContext
    {
        public DbSet<Student> StudentsDB { get; set; }
        public DbSet<Subject> SubjectDB { get; set; }
        public DbSet<Exam> ExamDB { get; set; }

    }
}
