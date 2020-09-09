using Common.Lib.Core.Context;
using P.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P.BL.Infraestructure.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        Student GetStudentByDni(string dni);

        int GetNumberStudents();

        void AddFromDb(Student entity);

    }
}
