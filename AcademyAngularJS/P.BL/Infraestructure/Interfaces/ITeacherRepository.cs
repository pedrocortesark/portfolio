using Common.Lib.Core.Context;
using P.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P.BL.Infraestructure.Interfaces
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        Teacher FindByName(string name);

        int GetNumberTeachers();

        void AddFromDb(Teacher entity);
    }
}
