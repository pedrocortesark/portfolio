﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Lib.Core;
using Common.Lib.Core.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using P.BL.Models;
using System.IO;

namespace Converter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HandleDbController : ControllerBase
    {
        [HttpGet("ExportData")]
        public void ExportData()
        {
            using (var repoTea = Entity.DepCon.Resolve<IRepository<Teacher>>())
            {
                var teachers = repoTea.QueryAll().ToList();
                var teaJson = JsonConvert.SerializeObject(teachers);

                var path = @"Y:\Dropbox\Disco_duro\_PROYECTOS_PERSONALES\_PROY_2020\00_DEV\Databases\Conversions\TeachersJson";
                System.IO.File.WriteAllText(path, teaJson);
            }

            using (var repoSub = Entity.DepCon.Resolve<IRepository<Subject>>())
            {
                var subject = repoSub.QueryAll().ToList();
                var subJson = JsonConvert.SerializeObject(subject);

                var path = @"Y:\Dropbox\Disco_duro\_PROYECTOS_PERSONALES\_PROY_2020\00_DEV\Databases\Conversions\SubjectsJson";
                System.IO.File.WriteAllText(path, subJson);
            }

            using (var repoStu = Entity.DepCon.Resolve<IRepository<Student>>())
            {
                var student = repoStu.QueryAll().ToList();
                var stuJson = JsonConvert.SerializeObject(student);

                var path = @"Y:\Dropbox\Disco_duro\_PROYECTOS_PERSONALES\_PROY_2020\00_DEV\Databases\Conversions\StudentsJson";
                System.IO.File.WriteAllText(path, stuJson);
            }

            using (var repoExa = Entity.DepCon.Resolve<IRepository<Exam>>())
            {
                var exam = repoExa.QueryAll().ToList();
                var exaJson = JsonConvert.SerializeObject(exam);

                var path = @"Y:\Dropbox\Disco_duro\_PROYECTOS_PERSONALES\_PROY_2020\00_DEV\Databases\Conversions\ExamsJson";
                System.IO.File.WriteAllText(path, exaJson);
            }

            using (var repoStuExa = Entity.DepCon.Resolve<IRepository<StudentExam>>())
            {
                var stuExam = repoStuExa.QueryAll().ToList();
                var stuExamJson = JsonConvert.SerializeObject(stuExam);

                var path = @"Y:\Dropbox\Disco_duro\_PROYECTOS_PERSONALES\_PROY_2020\00_DEV\Databases\Conversions\StudentExamJson";
                System.IO.File.WriteAllText(path, stuExamJson);
            }

            using (var repoStuSub = Entity.DepCon.Resolve<IRepository<StudentSubject>>())
            {
                var stuSubject = repoStuSub.QueryAll().ToList();
                var stuSubjectJson = JsonConvert.SerializeObject(stuSubject);

                var path = @"Y:\Dropbox\Disco_duro\_PROYECTOS_PERSONALES\_PROY_2020\00_DEV\Databases\Conversions\StudentSubjectJson";
                System.IO.File.WriteAllText(path, stuSubjectJson);
            }

        }

        [HttpGet("ImportData")]
        public void ImportData()
        {
            using (var repoTea = Entity.DepCon.Resolve<IRepository<Teacher>>())
            {
                var path = @"Y:\Dropbox\Disco_duro\_PROYECTOS_PERSONALES\_PROY_2020\00_DEV\Databases\Conversions\TeachersJson";
                var teaJson = System.IO.File.ReadAllText(path);
                var teachers = JsonConvert.DeserializeObject<List<Teacher>>(teaJson);

                foreach (var element in teachers)
                    _context.Teachers.Add(element);

                _context.SaveChanges();
            }
        }

    }
}