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
    public class SubjectsRepository : EfCoreRepository<Subject>, ISubjectRepository
    {
        public Dictionary<string, Subject> SubjectsByName { get; set; } = new Dictionary<string, Subject>();

        public SubjectsRepository(AcademyDbContext dbcontext)
            : base(dbcontext)
        {
            if (GetNumberSubjects() == 0)
            {
                foreach (var element in QueryAll().ToList())
                    AddFromDb(element);

            }
        }

        public override SaveResult<Subject> Add(Subject entity)
        {
            var output = base.Add(entity);

            if (output.IsSuccess)
                SubjectsByName.Add(output.Entity.Name, output.Entity);

            return output;
        }

        public override SaveResult<Subject> Update(Subject entity)
        {
            var previousName = string.Empty;

            using (var repoTemp = Entity.DepCon.Resolve<ISubjectRepository>())
            {
                var existingSubject = repoTemp.Find(entity.Id);
                previousName = existingSubject.Name;
            }

            var output = base.Update(entity);

            if (output.IsSuccess)
            {
                if (previousName != output.Entity.Name)
                {
                    SubjectsByName.Remove(previousName);
                    SubjectsByName.Add(output.Entity.Name, output.Entity);
                }
                else
                    SubjectsByName[output.Entity.Name] = output.Entity;
            }

            return output;
        }

        public override SaveResult<Subject> Delete(Subject entity)
        {
            var output = base.Delete(entity);

            if (output.IsSuccess == true)
                SubjectsByName.Remove(entity.Name);

            return output;
        }

        public override Subject Find(Guid id)
        {
            return base.Find(id);
        }

        public Subject FindByName(string name)
        {
            if (SubjectsByName.ContainsKey(name))
            {
                return SubjectsByName[name];
            }

            return null;
        }

        public int GetNumberSubjects()
        {
            return SubjectsByName.Count;
        }

        public void AddFromDb(Subject entity)
        {
            SubjectsByName.Add(entity.Name, entity);
        }
    }
}
