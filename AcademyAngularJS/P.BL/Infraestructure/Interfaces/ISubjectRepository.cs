using Common.Lib.Core.Context;
using P.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P.BL.Infraestructure.Interfaces
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        Subject FindByName(string name);

        int GetNumberSubjects();

        void AddFromDb(Subject entity);
    }
}
