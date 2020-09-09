using Common.Lib.Core;
using Common.Lib.DAL.EFCore;
using Common.Lib.Infrastructure;
using P.BL.Infraestructure.Interfaces;
using P.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P.DAL.EFCore.Context
{
    public class TeachersRepository : EfCoreRepository<Teacher>, ITeacherRepository
    {
        public Dictionary<string, Teacher> TeachersByName { get; set; } = new Dictionary<string, Teacher>();

        public TeachersRepository()
        {

        }

        public TeachersRepository(AcademyDbContext dbcontext)
            : base(dbcontext)
        {
            if (GetNumberTeachers() == 0)
            {
                foreach (var element in QueryAll().ToList())
                    AddFromDb(element);

            }
        }

        public override SaveResult<Teacher> Add(Teacher entity)
        {
            var output = base.Add(entity);

            if (output.IsSuccess)
                TeachersByName.Add(output.Entity.CompleteName, output.Entity);

            return output;
        }

        public override SaveResult<Teacher> Update(Teacher entity)
        {
            var previousName = string.Empty;

            using (var repoTemp = Entity.DepCon.Resolve<ITeacherRepository>())
            {
                var existingTeacher = repoTemp.Find(entity.Id);
                previousName = existingTeacher.CompleteName;
            }

            var output = base.Update(entity);

            
            if (output.IsSuccess)
            {
                if (previousName != output.Entity.CompleteName)
                {
                    TeachersByName.Remove(previousName);
                    TeachersByName.Add(output.Entity.CompleteName, output.Entity);
                }
                else
                    TeachersByName[output.Entity.CompleteName] = output.Entity;
            }

            return output;
        }

        public override SaveResult<Teacher> Delete(Teacher entity)
        {
            var output = base.Delete(entity);

            if (output.IsSuccess == true)
                TeachersByName.Remove(entity.CompleteName);

            return output;
        }

        public override Teacher Find(Guid id)
        {
            return base.Find(id);
        }

        public Teacher FindByName(string name)
        {
            if (TeachersByName.ContainsKey(name))
                return TeachersByName[name];
            return null;
        }

        public int GetNumberTeachers()
        {
            return TeachersByName.Count;
        }

        public void AddFromDb(Teacher entity)
        {
            TeachersByName.Add(entity.CompleteName, entity);
        }
    }
}
