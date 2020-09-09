using Common.Lib.Core;
using Common.Lib.DAL.EFCore;
using Common.Lib.Infrastructure;
using P.BL.Infraestructure.Interfaces;
using P.BL.Models;
using P.DAL.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P.DAL.EFCore
{
    public class ExamsRepository : EfCoreRepository<Exam>, IExamRepository
    {
        public static Dictionary<string, Exam> ExamsByName { get; set; } = new Dictionary<string, Exam>();

        public ExamsRepository()
        {

        }

        public ExamsRepository(AcademyDbContext dbcontext)
            : base(dbcontext)
        {
            if (GetNumberExams() == 0)
            {
                foreach (var element in QueryAll().ToList())
                    AddFromDb(element);

            }
        }


        public override SaveResult<Exam> Add(Exam entity)
        {
            var output = base.Add(entity);

            if (output.IsSuccess)
                ExamsByName.Add(output.Entity.Name, output.Entity);
                

            return output;
        }

        public override SaveResult<Exam> Update(Exam entity)
        {
            var previousName = string.Empty;

            using (var repoTemp = Entity.DepCon.Resolve<IExamRepository>())
            {
                var existingExam = repoTemp.Find(entity.Id);
                previousName = existingExam.Name;
            }

            var output = base.Update(entity);
         
            if (output.IsSuccess)
            {
                if (previousName != output.Entity.Name)
                {
                    ExamsByName.Remove(previousName);
                    ExamsByName.Add(output.Entity.Name, output.Entity);
                }
                else
                    ExamsByName[output.Entity.Name] = output.Entity;
            }

            return output;
        }

        public override SaveResult<Exam> Delete(Exam entity)
        {
            var output = base.Delete(entity);

            if (output.IsSuccess == true)
                ExamsByName.Remove(entity.Name);

            return output;
        }

        public override Exam Find(Guid id)
        {
            return base.Find(id);
        }

        public Exam FindByName(string name)
        {
            if (ExamsByName.ContainsKey(name))
            {
                var examForUpdate = ExamsByName[name];
                return examForUpdate;
            }

            return null;
        }

        public int GetNumberExams()
        {
            return ExamsByName.Values.Count;
        }

        public void AddFromDb(Exam entity)
        {
            ExamsByName.Add(entity.Name, entity);
        }
    }
}
