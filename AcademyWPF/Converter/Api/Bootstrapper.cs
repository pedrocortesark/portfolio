using Common.Lib.Core;
using Common.Lib.Core.Context;
using Common.Lib.DAL.EFCore;
using Common.Lib.Infrastructure;
using Converter.DbContextFactory;
using P.BL.Infraestructure.Interfaces;
using P.BL.Models;
using P.DAL.EFCore;
using P.DAL.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Converter.Api
{
    public class Bootstrapper
    {
        public IDependencyContainer Init()
        {
            var dp = new SimpleDependencyContainer();

            RegisterRepositories(dp);

            Entity.DepCon = dp;

            return dp;
        }

        public void RegisterRepositories(IDependencyContainer dp)
        {
            var studentsRepoBuilder = new Func<object[], object>((parameters) =>
            {
                return new StudentsRepository(GetDbConstructor());
            });

            var subjectsRepoBuilder = new Func<object[], object>((parameters) =>
            {
                return new SubjectsRepository(GetDbConstructor());
            });

            var examsRepoBuilder = new Func<object[], object>((parameters) =>
            {
                return new ExamsRepository(GetDbConstructor());
            });

            var teachersRepoBuilder = new Func<object[], object>((parameters) =>
            {
                return new TeachersRepository(GetDbConstructor());
            });


            var studentsExamsRepoBuilder = new Func<object[], object>((parameters) =>
            {
                return new EfCoreRepository<StudentExam>(GetDbConstructor());
            });

            var studentsSubjectsRepoBuilder = new Func<object[], object>((parameters) =>
            {
                return new EfCoreRepository<StudentSubject>(GetDbConstructor());
            });



            dp.Register<IRepository<Student>, StudentsRepository>(studentsRepoBuilder);
            dp.Register<IStudentRepository, StudentsRepository>((parameters) => new StudentsRepository(GetDbConstructor()));

            dp.Register<IRepository<Subject>, SubjectsRepository>(subjectsRepoBuilder);
            dp.Register<ISubjectRepository, SubjectsRepository>((parameters) => new SubjectsRepository(GetDbConstructor()));

            dp.Register<IRepository<Teacher>, TeachersRepository>(teachersRepoBuilder);
            dp.Register<ITeacherRepository, TeachersRepository>((parameters) => new TeachersRepository(GetDbConstructor()));

            dp.Register<IRepository<StudentSubject>, EfCoreRepository<StudentSubject>>(studentsSubjectsRepoBuilder);

            dp.Register<IRepository<Exam>, ExamsRepository>(examsRepoBuilder);
            dp.Register<IExamRepository, ExamsRepository>((parameters) => new ExamsRepository(GetDbConstructor()));

            dp.Register<IRepository<StudentExam>, EfCoreRepository<StudentExam>>(studentsExamsRepoBuilder);



        }

        private static AcademyDbContext GetDbConstructor()
        {
            var factory = new AcademyDbContextFactory();
            return factory.CreateDbContext(null);
        }
    }
}
