using Common.Lib.Core;
using Common.Lib.Infrastructure;
using Newtonsoft.Json;
using P.BL.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P.BL.Models
{
    public class StudentExam : Entity
    {
        public Guid StudentId { get; set; }

        public Guid ExamId { get; set; }

        [JsonIgnore]
        public Student Student
        {
            get
            {
                var repoStd = Entity.DepCon.Resolve<IStudentRepository>();
                return repoStd.Find(this.StudentId);
            }
        }

        [JsonIgnore]
        public Exam Exam
        {
            get
            {
                var repoSub = Entity.DepCon.Resolve<IExamRepository>();
                return repoSub.Find(this.ExamId);
            }
        }

        public double Grade { get; set; }

        public override ValidationResult Validate()
        {
            var output = base.Validate();

            ValidateGrade(output);
            ValidateStudent(output);

            return output;
        }

        public SaveResult<StudentExam> Save()
        {
            var saveResult = base.Save<StudentExam>();
            return saveResult;
        }

        public SaveResult<StudentExam> Delete()
        {
            var saveResult = base.Delete<StudentExam>();
            return saveResult;
        }


        #region Domain validations

        public void ValidateGrade(ValidationResult output)
        {
            var vr = ValidateGrade(this.Grade.ToString());

            if (!vr.IsSuccess)
            {
                output.IsSuccess = false;
                output.Errors.AddRange(vr.Errors);
            }
        }

        public void ValidateStudent(ValidationResult output)
        {
            var vr = ValidateStudent(this.Student, this.Exam);

            if (!vr.IsSuccess)
            {
                output.IsSuccess = false;
                output.Errors.AddRange(vr.Errors);
            }
        }

        #endregion

        #region Static validations


        public static ValidationResult<double> ValidateGrade(string gradeText)
        {
            var output = new ValidationResult<double>
            {
                IsSuccess = true
            };

            if (String.IsNullOrEmpty(gradeText))
            {
                output.IsSuccess = false;
                output.Errors.Add("Check!! The grade cannot be empty!");
            }

            var gradeNumber = 0.0;
            gradeText = gradeText.Replace(".", ",");
            var isConversionOk = double.TryParse(gradeText, out gradeNumber);
            
            if (!isConversionOk)
            {
                output.IsSuccess = false;
                output.Errors.Add("Check!! This value is not right to be a grade!");
            }

            if (isConversionOk)
            {
                if (gradeNumber > 10 || gradeNumber < 0)
                {
                    output.IsSuccess = false;
                    output.Errors.Add("Check!! The grade must be between 0 and 10 points!!");
                }
               
            }

            if (output.IsSuccess)
                output.ValidatedResult = gradeNumber;

            return output;

        }

        public static ValidationResult ValidateStudent(Student student, Exam exam)
        {
            var output = new ValidationResult<double>
            {
                IsSuccess = true
            };

            var subject = exam.Subject;

            if (!exam.Subject.Students.Any(x=>x.Id==student.Id))
            {
                output.IsSuccess = false;
                output.Errors.Add("Check!! This student isn't in this subject!");
            }

            return output;
        }

        #endregion
    }
}
