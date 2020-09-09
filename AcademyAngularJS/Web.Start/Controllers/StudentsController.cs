using Common.Lib.Core;
using Common.Lib.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P.BL.Infraestructure.Interfaces;
using P.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Start.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var repo = Entity.DepCon.Resolve<IStudentRepository>();
            return await repo.QueryAll().ToListAsync();
        }


        // GET: api/Students/5
        [HttpGet("{id}", Name = "GetStudent")]
        public async Task<ActionResult<Student>> GetStudent(Guid id)
        {
            return await Task.Run(() =>
            {
                var repo = Entity.DepCon.Resolve<IStudentRepository>();
                var student = repo.QueryAll().FirstOrDefault(x => x.Id == id);
                // var student = await _context.Students.FindAsync(id);
                if (student == null)
                {
                    return null;
                }
                return student;
            });
        }



        // PUT: api/Students/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut]
        public async Task<ActionResult<SaveResult<Student>>> PutStudent(Student student)
        {
            return await Task.Run(() =>
            {
                var sr = student.Save();
                return sr;
            });

        }


        // POST: api/Students
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<SaveResult<Student>>> PostStudent(Student student)
        {
            return await Task.Run(() =>
            {
                var sr = student.Save();
                return sr;
            });
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SaveResult<Student>>> DeleteStudent(Guid id)
        {
            return await Task.Run(() =>
            {
                var repo = Entity.DepCon.Resolve<IStudentRepository>();
                var stuDelete = repo.QueryAll().FirstOrDefault(x => x.Id == id);
                var sr = stuDelete.Delete();
                return sr;
            });
        }


        private bool StudentExists(Guid id)
        {
            var repo = Entity.DepCon.Resolve<IStudentRepository>();
            return repo.QueryAll().Any(x=>x.Id == id);
        }
    }
}
