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
    public class StudentSubject : Entity
    {
        [JsonIgnore]
        public Guid StudentId { get; set; }

        [JsonIgnore]
        public Guid SubjectId { get; set; }

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
        public Subject Subject
        {
            get
            {
                var repoSub = Entity.DepCon.Resolve<ISubjectRepository>();
                return repoSub.Find(this.SubjectId);
            }
        }


        public override ValidationResult Validate()
        {
            var output = base.Validate();

            ValidateSubject(output);
            ValidateMaxStudents(output);

            return output;
        }

        public SaveResult<StudentSubject> Save()
        {
            var saveResult = base.Save<StudentSubject>();
            return saveResult;
        }


        #region Domain validations

        public void ValidateSubject(ValidationResult output)
        {
            var vr = ValidateSubject(this.StudentId, this.SubjectId);

            if (!vr.IsSuccess)
            {
                output.IsSuccess = false;
                output.Errors.AddRange(vr.Errors);
            }
        }

        public void ValidateMaxStudents(ValidationResult output)
        {
            var vr = ValidateMaxStudents(this.Subject);

            if (!vr.IsSuccess)
            {
                output.IsSuccess = false;
                output.Errors.AddRange(vr.Errors);
            }
        }

        #endregion

        #region Static validations

        public static ValidationResult ValidateSubject(Guid studentId, Guid subjectId)
        {
            var output = new ValidationResult
            {
                IsSuccess = true
            };

            var repo = Entity.DepCon.Resolve<IRepository<StudentSubject>>();
            var subjectExist = repo.QueryAll().Where(x => x.StudentId == studentId).Any(x => x.SubjectId == subjectId);


            if (subjectExist)
            {
                output.IsSuccess = false;
                output.Errors.Add("Check!! This student is already been matriculated in this subject!");
            }

            return output;

        }

        public static ValidationResult ValidateMaxStudents(Subject subject)
        {
            var output = new ValidationResult<string>
            {
                IsSuccess = true
            };

            if ((subject.StudentsMatr + 1) > subject.NumberStudents)
            {
                output.IsSuccess = false;
                output.Errors.Add("Check!! This class is completed!!");
            }

            return output;
        }

        #endregion
    }
}
