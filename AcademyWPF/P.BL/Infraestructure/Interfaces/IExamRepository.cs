using Common.Lib.Core.Context;
using P.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P.BL.Infraestructure.Interfaces
{
    public interface IExamRepository : IRepository<Exam>
    {
        Exam FindByName(string name);

        int GetNumberExams();

        void AddFromDb(Exam entity);
    }
}
