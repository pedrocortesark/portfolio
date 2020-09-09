using Common.Lib.Core;
using Common.Lib.Core.Context;
using Common.Lib.Infrastructure;
using P.BL.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace P.BL.Models
{
    public class Student : Entity
    {
        public string Dni { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string LastName2 { get; set; }


        private string _completeName;

        public string CompleteName
        {
            get
            {
                _completeName = Name + " " + LastName + " " + LastName2;
                return _completeName;
            }
        }
        
        public bool Status { get; set; } = true;

        public int Chair { get; set; }

        [JsonIgnore]
        public virtual List<Subject> Subjects
        {
            get
            {
                var repo = Entity.DepCon.Resolve<IRepository<StudentSubject>>();
                var subjects = repo
                    .QueryAll()
                    .Where(x => x.StudentId == this.Id)
                    .Select(x => x.Subject)
                    .ToList();
                return subjects;
            }
        }

        [JsonIgnore]
        public virtual List<StudentExam> Exams
        {
            get
            {
                var repo = Entity.DepCon.Resolve<IRepository<StudentExam>>();
                var exams = repo
                    .QueryAll()
                    .Where(x => x.StudentId == this.Id)
                    .ToList();
                return exams;
            }
        }

        public string SubjectsString
        {
            get
            {
                var subjects = string.Empty;

                if (Subjects.Count != 0)
                {
                    for (var i = 0; i < Subjects.Count - 1; i++)
                    {
                        subjects += Subjects[i].Name + ", ";
                    }

                    subjects += Subjects[Subjects.Count - 1].Name;

                }
                else
                    subjects = "This student is not matriculated in any subject";

                return subjects;
            }
        }

        
        public int NumSubjects
        {
            get 
            {
                return Subjects.Count;
            }
        }


        public override ValidationResult Validate()
        {
            var output = base.Validate();

            ValidateName(output);
            ValidateDni(output);
            ValidateChairNumber(output);

            return output;
        }
        
        public SaveResult<Student> Save()
        {
            var saveResult = base.Save<Student>();
            return saveResult;
        }

        public SaveResult<Student> Delete()
        {
            var saveResult = base.Delete<Student>();
            return saveResult;
        }

        public Student Clone()
        {
            return Clone<Student>();
        }

        public override T Clone<T>()
        {
            var output = base.Clone<T>() as Student;
            output.Name = this.Name;
            output.Dni = this.Dni;
            output.Chair = this.Chair;
            output.Status = this.Status;
            return output as T;
        }


        #region Domain validations

        public void ValidateName(ValidationResult output)
        {
            var vr = ValidateName(this.Name);

            if (!vr.IsSuccess)
            {
                output.IsSuccess = false;
                output.Errors.AddRange(vr.Errors);
            }

        }
        public void ValidateDni(ValidationResult output)
        {
            var vr = ValidateDni(this.Dni, this.Id);

            if (!vr.IsSuccess)
            {
                output.IsSuccess = false;
                output.Errors.AddRange(vr.Errors);
            }
        }
        public void ValidateChairNumber(ValidationResult output)
        {
            var vr = ValidateChair(this.Chair.ToString(), this.Id);

            if (!vr.IsSuccess)
            {
                output.IsSuccess = false;
                output.Errors.AddRange(vr.Errors);
            }
        }

        #endregion

        #region Static validations

        public static ValidationResult<string> ValidateDni(string dni, Guid currentId = default)
        {
            var output = new ValidationResult<string>
            {
                IsSuccess = true
            };

            if (string.IsNullOrEmpty(dni))
            {
                output.IsSuccess = false;
                output.Errors.Add("Cannot be empty!");
            }

            var repo = Entity.DepCon.Resolve<IStudentRepository>();

            if (currentId == default)
            {
                var currentStudentinRepo = repo.GetStudentByDni(dni);

                if (currentStudentinRepo != null)
                {
                    output.IsSuccess = false;
                    output.Errors.Add("This DNI is already in db!");
                }

            }

            if (currentId != default)
            {
                var studentRepo = repo.Find(currentId);

                if (studentRepo == null)
                {
                    output.IsSuccess = false;
                    output.Errors.Add("Not found in DB");
                }

            }

            if (output.IsSuccess == true)
                output.ValidatedResult = dni;

            return output;

        }

        public static ValidationResult<string> ValidateName(string name)
        {
            var output = new ValidationResult<string>
            {
                IsSuccess = true
            };

            if (string.IsNullOrEmpty(name))
            {
                output.IsSuccess = false;
                output.Errors.Add("Cannot be empty!!");
            }

            if (output.IsSuccess)
                output.ValidatedResult = name;

            return output;

        }

        public static ValidationResult<int> ValidateChair(string chairText, Guid currentId = default)
        {
            var output = new ValidationResult<int>
            {
                IsSuccess = true
            };

            if (String.IsNullOrEmpty(chairText))
            {
                output.IsSuccess = false;
                output.Errors.Add("Cannot be empty");
            }

            var chairNumber = 0;
            var isConversionOk = int.TryParse(chairText, out chairNumber);
            if (!isConversionOk)
            {
                output.IsSuccess = false;
                output.Errors.Add("Cannot be a letter");
            }

            if (isConversionOk)
            {
                var repo = Entity.DepCon.Resolve<IStudentRepository>();
                var studentInChair = repo.QueryAll().FirstOrDefault(s => s.Chair == chairNumber);

                if (studentInChair != default && studentInChair.Id != currentId)
                {
                    output.IsSuccess = false;
                    output.Errors.Add("Place taken!");
                }

            }

            if (output.IsSuccess)
                output.ValidatedResult = chairNumber;

            return output;

        }

        #endregion

    }
}
