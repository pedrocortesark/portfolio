using Common.Lib.Core;
using Common.Lib.Infrastructure;
using Newtonsoft.Json;
using P.BL.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P.BL.Models
{
    public class Teacher : Entity
    {
        public string Name { get; set; }

        public string LastName1 { get; set; }

        public string LastName2 { get; set; }

        private string _completeName;

        public string CompleteName
        {
            get
            {
                _completeName = Name + " " + LastName1 + " " + LastName2;
                return _completeName;
            }
        }

        public int MaxCredits { get; set; }

        [JsonIgnore]
        public List<Subject> Subjects
        {
            get
            {
                var repo = Entity.DepCon.Resolve<ISubjectRepository>();
                var subjects = repo.QueryAll().Where(x => x.TeacherId == this.Id).ToList();
                return subjects;
            }
        }

        public int NumberSubjects
        {
            get
            {
                return Subjects.Count;
            }
        }

        public int NumberCredits
        {
            get
            {
                var numCredits = 0;
                foreach (var element in this.Subjects)
                    numCredits += element.Credits;

                return numCredits;
            }
        }

        public string SubjectsString
        {
            get
            {
                var subjects = string.Empty;

                if (Subjects.Count != 0)
                {
                    for (var i =0; i < Subjects.Count -1; i++)
                    {
                        subjects += Subjects[i].Name + ", ";
                    }

                    subjects += Subjects[Subjects.Count - 1].Name;
                    
                }
                else
                    subjects = "This teacher is not giving any subject";

                return subjects;
            }
        }


        public override ValidationResult Validate()
        {
            var output = base.Validate();

            ValidateName(output);
            ValidateCredits(output);

            return output;
        }

        public SaveResult<Teacher> Save()
        {
            var saveResult = base.Save<Teacher>();
            return saveResult;
        }

        public SaveResult<Teacher> Delete()
        {
            var saveResult = new SaveResult<Teacher>();
            
            var output = new ValidationResult()
            {
                IsSuccess = true
            };

            ValidateToDelete(output);

            if (output.IsSuccess)
            {
                saveResult = base.Delete<Teacher>();
            }
            else
            {
                saveResult.Validation = output;
            }
                
            return saveResult;
        }



        #region Domain Validations

        public void ValidateName(ValidationResult output)
        {
            var vr = ValidateName(this.CompleteName, this.Id);

            if (!vr.IsSuccess)
            {
                output.IsSuccess = false;
                output.Errors.AddRange(vr.Errors);
            }

        }

        public void ValidateToDelete(ValidationResult output)
        {
            var repo = Entity.DepCon.Resolve<ISubjectRepository>();
            var hasSubjects = repo.QueryAll().Any(s => s.TeacherId == this.Id);

            if (hasSubjects)
            {
                output.IsSuccess = false;
                output.Errors.Add("This teacher is currently giving subjets!! Change the subject's teacher before deleted it!");
            }
                
        }

        public void ValidateCredits(ValidationResult output)
        {
            var vr = ValidateCredits(this.MaxCredits.ToString());

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
                output.Errors.Add("Check!! Teacher's name cannot be empty.");
            }

            var repo = Entity.DepCon.Resolve<ITeacherRepository>();
            
            if (repo.QueryAll().ToList().Any(t => t.CompleteName == name && t.Id != currentId))
            {
                output.IsSuccess = false;
                output.Errors.Add($"Check!! This teacher has already hired!!");
            }
            

            if (output.IsSuccess)
                output.ValidatedResult = name;

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

            if (creditNumber % 3 != 0)
            {
                output.IsSuccess = false;
                output.Errors.Add("Check!! Credits must be multiple of 3!");
            }

            if (output.IsSuccess)
                output.ValidatedResult = creditNumber;

            return output;

        }

        #endregion

    }
}
