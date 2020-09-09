using Common.Lib.Core;
using Common.Lib.Core.Context;
using Common.Lib.Infrastructure;
using Newtonsoft.Json;
using P.BL.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P.BL.Models
{
    public class Subject : Entity
    {
        public string Name { get; set; }


        private string _teacherName;

        public string TeacherName
        {
            get
            {
                if (string.IsNullOrEmpty(_teacherName))
                {
                    var repo = Entity.DepCon.Resolve<ITeacherRepository>();
                    var teacherName = repo.Find(TeacherId).CompleteName;
                    _teacherName = teacherName;
                }
                return _teacherName;
            }
            
        }

        public string Season { get; set; }

        public int Credits { get; set; }

        public int StudentsMatr
        {
            get
            {
                return Students.Count;
            }
        }

        public int NumberStudents { get; set; }

        [JsonIgnore]
        public List<Student> Students
        {
            get
            {
                var repo = Entity.DepCon.Resolve<IRepository<StudentSubject>>();
                var students = repo.QueryAll()
                    .Where(x => x.SubjectId == this.Id)
                    .Select(x=>x.Student)
                    .ToList();
                return students;
            }
        }

        public Guid TeacherId { get; set; }

        [JsonIgnore]
        public List<Exam> Exams
        {
            get
            {
                var repo = Entity.DepCon.Resolve<IExamRepository>();
                var exams = repo.QueryAll().Where(x=>x.SubjectId==this.Id).ToList();
                return exams;
            }
        }

        public override ValidationResult Validate()
        {
            var output = base.Validate();

            ValidateName(output);
            ValidateNumberStudents(output);
            ValidateSeason(output);
            ValidateCredits(output);
            ValidateTeacher(output);

            return output;
        }

        public SaveResult<Subject> Save()
        {
            var saveResult = base.Save<Subject>();
            return saveResult;
        }

        public SaveResult<Subject> Delete()
        {
            var saveResult = base.Delete<Subject>();
            return saveResult;
        }

        #region Domain Validations

        public void ValidateName(ValidationResult output)
        {
            var vr = ValidateName(this.Name, this.Id);

            if (!vr.IsSuccess)
            {
                output.IsSuccess = false;
                output.Errors.AddRange(vr.Errors);
            }

        }

        public void ValidateNumberStudents(ValidationResult output)
        {
            var vr = ValidateNumberStudents(this.NumberStudents.ToString());

            if (!vr.IsSuccess)
            {
                output.IsSuccess = false;
                output.Errors.AddRange(vr.Errors);
            }
        }
        
        public void ValidateSeason(ValidationResult output)
        {
            var vr = ValidateNumberStudents(this.NumberStudents.ToString());

            if (!vr.IsSuccess)
            {
                output.IsSuccess = false;
                output.Errors.AddRange(vr.Errors);
            }
        }

        public void ValidateCredits(ValidationResult output)
        {
            var vr = ValidateCredits(this.Credits.ToString());

            if (!vr.IsSuccess)
            {
                output.IsSuccess = false;
                output.Errors.AddRange(vr.Errors);
            }
        }

        public void ValidateTeacher(ValidationResult output)
        {
            var vr = ValidateTeacher(this.Credits.ToString(), this.TeacherId, this.Id);

            if (!vr.IsSuccess)
            {
                output.IsSuccess = false;
                output.Errors.AddRange(vr.Errors);
            }
        }

        #endregion

        #region Static Validations

        public static ValidationResult<string> ValidateName(string name, Guid currentId = default)
        {
            var output = new ValidationResult<string>
            {
                IsSuccess = true
            };

            if (string.IsNullOrEmpty(name))
            {
                output.IsSuccess = false;
                output.Errors.Add("Check!! Subject's name cannot be empty!");
            }

            var repo = Entity.DepCon.Resolve<ISubjectRepository>();

            if (currentId == default && repo.QueryAll().ToList().Any(s => s.Name == name))
            {
                output.IsSuccess = false;
                output.Errors.Add("Check!! There is another subject with this name!!");
            }


            if (output.IsSuccess)
                output.ValidatedResult = name;

            return output;

        }

        public static ValidationResult<int> ValidateNumberStudents(string numberText)
        {
            var output = new ValidationResult<int>
            {
                IsSuccess = true
            };

            if (String.IsNullOrEmpty(numberText))
            {
                output.IsSuccess = false;
                output.Errors.Add("Check!! The students' number field cannot be empty");
            }

            var studentsNumber = 0;
            var isConversionOk = int.TryParse(numberText, out studentsNumber);
            if (!isConversionOk)
            {
                output.IsSuccess = false;
                output.Errors.Add("Check!! This number is not correct");
            }

            if (studentsNumber > 20)
            {
                output.IsSuccess = false;
                output.Errors.Add("Check!! This numberof students is too large to one teacher");
            }

            if (output.IsSuccess)
                output.ValidatedResult = studentsNumber;

            return output;

        }

        public static ValidationResult<int> ValidateCredits(string creditText)
        {
            var output = new ValidationResult<int>
            {
                IsSuccess = true
            };

            if (String.IsNullOrEmpty(creditText))
            {
                output.IsSuccess = false;
                output.Errors.Add("Check!! The students' number field cannot be empty");
            }

            var creditNumber = 0;
            var isConversionOk = int.TryParse(creditText, out creditNumber);
            if (!isConversionOk)
            {
                output.IsSuccess = false;
                output.Errors.Add("Check!! This number is not correct");
            }

            if (creditNumber%3 != 0)
            {
                output.IsSuccess = false;
                output.Errors.Add("Check!! Credits must be multiple of 3!");
            }

            if (output.IsSuccess)
                output.ValidatedResult = creditNumber;

            return output;

        }

        public static ValidationResult<string> ValidateSeason(string season)
        {
            var output = new ValidationResult<string>
            {
                IsSuccess = true
            };

            if (String.IsNullOrEmpty(season))
            {
                output.IsSuccess = false;
                output.Errors.Add("Check!! Your must select one of the two seasons avaiable");
            }

            if (season != "Fall" && season != "Spring")
            {
                output.IsSuccess = false;
                output.Errors.Add("Check!! Your must select one of the two seasons avaiable");
            }

            if (output.IsSuccess)
            {
                output.ValidatedResult = season;
            }

            return output;
        }

        public static ValidationResult ValidateTeacher(string creditsText, Guid teacherId, Guid currentSubjectId = default)
        {
            var output = new ValidationResult<string>
            {
                IsSuccess = true
            };

            var creditNumber = 0;
            var isConversionOk = int.TryParse(creditsText, out creditNumber);
            
            var repo = Entity.DepCon.Resolve<ITeacherRepository>();
            var teacherSelected = repo.Find(teacherId);

            if (currentSubjectId == default && (teacherSelected.NumberCredits + creditNumber) > teacherSelected.MaxCredits)
            {
                output.IsSuccess = false;
                output.Errors.Add("Check!! This teacher doesn't have enough free hours to give this subject. Look for another one!!");
            }

            return output;
        }

        #endregion

    }
}
