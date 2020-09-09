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
    public class Exam : Entity
    {   
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public Guid SubjectId { get; set; }

        public Subject Subject
        {
            get
            {
                var repo = Entity.DepCon.Resolve<ISubjectRepository>();
                return repo.Find(this.SubjectId);
            }
        }

        public override ValidationResult Validate()
        {
            var output = base.Validate();

            ValidateName(output);
            ValidateSubject(output);
            ValidateDate(output);

            return output;
        }

        public SaveResult<Exam> Save()
        {
            var saveResult = base.Save<Exam>();
            return saveResult;
        }

        public SaveResult<Exam> Delete()
        {
            var saveResult = new SaveResult<Exam>();

            var output = new ValidationResult()
            {
                IsSuccess = true
            };

            ValidateToDelete(output);

            if (output.IsSuccess)
                saveResult = base.Delete<Exam>();
            
            else
                saveResult.Validation = output;

            return saveResult;
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

        public void ValidateDate(ValidationResult output)
        {
            var vr = ValidateDate(this.Date);

            if (!vr.IsSuccess)
            {
                output.IsSuccess = false;
                output.Errors.AddRange(vr.Errors);
            }

        }

        public void ValidateToDelete(ValidationResult output)
        {
            var repo = Entity.DepCon.Resolve<IRepository<StudentExam>>();
            var hasExams = repo.QueryAll().Any(s => s.ExamId == this.Id);

            if (hasExams)
            {
                output.IsSuccess = false;
                output.Errors.Add("This exam model has currently information about exams already made. You must delete this exams before deleting the model.");
            }

        }

        public void ValidateSubject(ValidationResult output)
        {
            var vr = ValidateSubject(this.Subject);

            if (!vr.IsSuccess)
            {
                output.IsSuccess = false;
                output.Errors.AddRange(vr.Errors);
            }
        }

        #endregion

        #region Static validations

        public static ValidationResult<string> ValidateName(string name)
        {
            var output = new ValidationResult<string>
            {
                IsSuccess = true
            };

            if (string.IsNullOrEmpty(name))
            {
                output.IsSuccess = false;
                output.Errors.Add("Check!! Exam's name cannot be empty!!");
            }

            if (output.IsSuccess)
                output.ValidatedResult = name;

            return output;

        }

        public static ValidationResult ValidateDate(DateTime date)
        {
            var output = new ValidationResult<string>
            {
                IsSuccess = true
            };

            if (date.CompareTo(DateTime.Now) >= 0)
            {
                output.IsSuccess = false;
                output.Errors.Add("Check!! The date cannot be after today!!");
            }

            return output;
        }

        public static ValidationResult ValidateSubject(Subject subject)
        {
            var output = new ValidationResult<string>
            {
                IsSuccess = true
            };

            var repo = Entity.DepCon.Resolve<ISubjectRepository>();
            if (!repo.QueryAll().Any(x=>x.Id == subject.Id))
            {
                output.IsSuccess = false;
                output.Errors.Add("Chek!! This subject doesn't exist in the academy!");
            }

            if (subject.NumberStudents == 0)
            {
                output.IsSuccess = false;
                output.Errors.Add("Chek!! This subject hasn't any students matriculated!");
            }


            return output;
        }

        #endregion
    }
}
