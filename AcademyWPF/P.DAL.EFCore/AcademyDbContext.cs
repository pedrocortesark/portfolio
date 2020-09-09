using Common.Lib.Core;
using Microsoft.EntityFrameworkCore;
using P.BL.Models;
using System;

namespace P.DAL.EFCore.Context
{
    public class AcademyDbContext : DbContext
    {
       
        #region DbSets!

        public DbSet<Student> Students { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Exam> Exams { get; set; }

        public DbSet<StudentSubject> StudentSubject { get; set; }

        public DbSet<StudentExam> StudentExam { get; set; }

        #endregion


        public AcademyDbContext(DbContextOptions<AcademyDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Entity>()
                .Ignore(x => x.CurrentValidation);
        }


    }
}
