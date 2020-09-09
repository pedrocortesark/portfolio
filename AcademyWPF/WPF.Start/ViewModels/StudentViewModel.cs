using Common.Lib.Core;
using Common.Lib.Core.Context;
using Common.Lib.Infrastructure;
using Infraestructure.Commands;
using P.BL.Infraestructure.Interfaces;
using P.BL.Models;
using P.DAL.EFCore;
using P.DAL.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WPF.Start.Infraestructure;

namespace WPF.Start.ViewModels
{
    public class StudentViewModel : GenericViewModel
    {

        #region Propiedades!

        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }

        private string _lastName1;

        public string LastName1
        {
            get
            {
                return _lastName1;
            }
            set
            {
                _lastName1 = value;
                RaisePropertyChanged();
            }
        }


        private string _lastName2;

        public string LastName2
        {
            get
            {
                return _lastName2;
            }
            set
            {
                _lastName2 = value;
                RaisePropertyChanged();
            }
        }


        private string _dni;

        public string Dni
        {
            get
            {
                return _dni;
            }
            set
            {
                _dni = value;
                RaisePropertyChanged();
            }
        }


        private string _chair;

        public string Chair
        {
            get
            {
                return _chair;
            }
            set
            {
                _chair = value;
                RaisePropertyChanged();

            }
        }

        private int _stdInDict;

        public int StdInDict
        {
            get 
            { 
                return _stdInDict; 
            }
            set 
            { 
                _stdInDict = value;
                RaisePropertyChanged();
            }
        }

        private string _messageToUser;

        public string MessageToUser
        {
            get 
            { 
                return _messageToUser; 
            }
            set 
            { 
                _messageToUser = value;
                RaisePropertyChanged();
            }
        }



        private Guid _id = default;

        public Guid Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                RaisePropertyChanged();
            }
        }



        #endregion


        private List<Student> _students = new List<Student>();

        public List<Student> Students
        {
            get
            {
                return _students;
            }
            set
            {
                _students = value;
                RaisePropertyChanged();
            }
        }


        private Student _currentStudent;

        public Student CurrentStudent
        {
            get
            {
                return _currentStudent;
            }
            set
            {
                _currentStudent = value;
                RaisePropertyChanged();
            }
        }


        private List<Subject> _subjectsToSelect;

        public List<Subject> SubjectsToSelect
        {
            get
            {
                return _subjectsToSelect;
            }
            set
            {
                _subjectsToSelect = value;
                RaisePropertyChanged();
            }
        }

        private Subject _subjectSelected;

        public Subject SubjectSelected
        {
            get
            {
                return _subjectSelected;
            }
            set
            {
                _subjectSelected = value;
                RaisePropertyChanged();
            }
        }


        #region Commands

        private ICommand _saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                    _saveCommand = new RelayCommand(new Action(Save), () => CanRegister());

                return _saveCommand;
            }
        }


        private ICommand _getInfoCommand;

        public ICommand GetInfoCommand
        {
            get
            {
                if (_getInfoCommand == null)
                    _getInfoCommand = new RelayCommand(new Action(GetInfo));

                return _getInfoCommand;
            }
        }


        private ICommand _delete;

        public ICommand DeleteCommand
        {
            get
            {
                if (_delete == null)
                    _delete = new RelayCommand(new Action(Delete));

                return _delete;
            }
        }


        private ICommand _editCommand;

        public ICommand EditCommand
        {
            get
            {
                if (_editCommand == null)
                    _editCommand = new RelayCommand(new Action(Edit));

                return _editCommand;
            }
        }

        private ICommand _matriculateCommand;

        public ICommand MatriculateCommand
        {
            get
            {
                if (_matriculateCommand == null)
                    _matriculateCommand = new RelayCommand(new Action(Matriculate));

                return _matriculateCommand;
            }
        }


        private ICommand _clearCommand;

        public ICommand ClearCommand
        {
            get
            {
                if (_clearCommand == null)
                    _clearCommand = new RelayCommand(new Action(Clear));

                return _clearCommand;
            }
        }

        #endregion


        private void Clear()
        {
            this.Name = null;
            this.LastName1 = null;
            this.LastName2 = null;
            this.Dni = null;
            this.Chair = null;
            this.Id = default;
        }

        private void Edit()
        {

            this.Name = CurrentStudent.Name;
            this.LastName1 = CurrentStudent.LastName;
            this.LastName2 = CurrentStudent.LastName2;
            this.Dni = CurrentStudent.Dni;
            this.Chair = CurrentStudent.Chair.ToString();
            this.Id = CurrentStudent.Id;
        }

        private void Delete()
        {
            var repo = Entity.DepCon.Resolve<IStudentRepository>();
            var stdDelete = repo.Find(CurrentStudent.Id);

            var repo1 = Entity.DepCon.Resolve<IRepository<StudentExam>>();
            var repo2 = Entity.DepCon.Resolve<IRepository<StudentSubject>>();

            if (stdDelete == null)
            {
                MessageToUser = "Cannot find this student in our database... Are your sure you haven't deleted it already??";
            }
            else
            {
                if (repo1.QueryAll().Any(x => x.StudentId == stdDelete.Id) || repo2.QueryAll().Any(x => x.StudentId == stdDelete.Id))
                {
                    MessageToUser = "This student is currently matriculated in some subjects!";
                }
                else
                {
                    var nomStd = stdDelete.CompleteName;
                    stdDelete.Delete();
                    MessageToUser = $"El estudiante {nomStd} acaba de ser eliminad@!";
                }
            }





            //if (repo1.QueryAll().Any(x => x.StudentId == stdDelete.Id) || repo2.QueryAll().Any(x => x.StudentId == stdDelete.Id))
            //{
            //    MessageToUser = "This student is currently matriculated in some subjects!";
            //}
            //else
            //{
            //    var nomStd = stdDelete.CompleteName;

            //    if (stdDelete == null)
            //        MessageToUser = "Este estudiante no se encuentra en la base de datos, seguro que no ha sido ya eliminad@?";

            //    else
            //    {
            //        stdDelete.Delete();
            //        MessageToUser = $"El estudiante {nomStd} acaba de ser eliminad@!";
            //    }
            //}

            

            Clear();
            GetInfo();

        }

        private void Save()
        {
            
            ValidationResult<string> vrName = Student.ValidateName(this.Name);
            ValidationResult<string> vrLastName1 = Student.ValidateName(this.LastName1);
            ValidationResult<string> vrLastName2 = Student.ValidateName(this.LastName2);
            ValidationResult<string> vrDni = Student.ValidateDni(this.Dni, Id);
            ValidationResult<int> vrChair = Student.ValidateChair(this.Chair, Id);

            if (vrDni.IsSuccess && vrName.IsSuccess && vrChair.IsSuccess && vrLastName1.IsSuccess && vrLastName2.IsSuccess)
            {
                var newStudent = new Student()
                {
                    Name = vrName.ValidatedResult,
                    LastName = vrLastName1.ValidatedResult,
                    LastName2 = vrLastName2.ValidatedResult,
                    Dni = vrDni.ValidatedResult,
                    Chair = vrChair.ValidatedResult,
                    Id = this.Id
                };

                var sr = newStudent.Save();

                if (sr.IsSuccess)
                    MessageToUser = $"The student {newStudent.CompleteName} have just been matriculated! Make him pay the fee!!";

                Clear();
                GetInfo();

            }
            else
            {
                var errors = string.Empty;
                errors += vrName.AllErrors;
                errors += vrDni.AllErrors;
                errors += vrChair.AllErrors;
                MessageToUser = errors;
            }

        }

        private void Matriculate()
        {
            var vrSubject = StudentSubject.ValidateSubject(this.Id, SubjectSelected.Id);
            var vrNumStudents = StudentSubject.ValidateMaxStudents(SubjectSelected);


            if (vrSubject.IsSuccess && vrNumStudents.IsSuccess)
            {
                if (this.Id != default)
                {
                    var StdSbj = new StudentSubject()
                    {
                        StudentId = this.Id,
                        SubjectId = SubjectSelected.Id
                    };

                    var sr = StdSbj.Save();

                    if (!sr.IsSuccess)
                        MessageToUser = "Check!! There has been problems!";
                    else
                        MessageToUser = $"{this.Name} {this.LastName1} has been matriculated in {SubjectSelected.Name}";
                }
                else
                    MessageToUser = "Check!! First you must select a student to matriculate!";
            }
            else
            {
                var errors = string.Empty;

                errors += vrSubject.AllErrors;
                errors += vrNumStudents.AllErrors;

                MessageToUser = errors;
            }
            
            Clear();
            GetInfo();
        }

        private void GetInfo()
        {
            var repoStu = Entity.DepCon.Resolve<IStudentRepository>();
            Students = repoStu.QueryAll().ToList();
            StdInDict = repoStu.GetNumberStudents();

            var repoSub = Entity.DepCon.Resolve<ISubjectRepository>();
            SubjectsToSelect = repoSub.QueryAll().ToList();
        }

        private bool CanRegister()
        {
            if (this.Name != null && this.LastName1 != null && this.LastName2 != null && this.Dni != null && this.Chair != null)
                return true;
            else
                return false;
        }

    }
}
