using System;
using Microsoft.EntityFrameworkCore;
using A4_Lib.Models;

namespace A4_DAL
{
    public class AcademyDbContext : DbContext
    {
        private DbSet<Student> StudentDb { get; set; }
       
        private DbSet<Subject> SubjectDb { get; set; }

        private DbSet<Exam> ExamDb { get; set; }
    }
}
