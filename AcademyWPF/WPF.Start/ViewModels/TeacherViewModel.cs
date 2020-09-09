using Common.Lib.Core;
using Common.Lib.Infrastructure;
using Infraestructure.Commands;
using P.BL.Infraestructure.Interfaces;
using P.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace WPF.Start.ViewModels
{
    class TeacherViewModel : GenericViewModel
    {
        #region Properties!

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


        private int _teaInDict;

        public int TeaInDict
        {
            get
            {
                return _teaInDict;
            }
            set
            {
                _teaInDict = value;
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

        
        #endregion

        private List<Teacher> _teachers = new List<Teacher>();

        public List<Teacher> Teachers
        {
            get
            {
                return _teachers;
            }
            set
            {
                _teachers = value;
                RaisePropertyChanged();
            }
        }


        private Teacher _currentTeacher;

        public Teacher CurrentTeacher
        {
            get
            {
                return _currentTeacher;
            }
            set
            {
                _currentTeacher = value;
                RaisePropertyChanged();
            }
        }


        public List<string> CreditsToSelect { get; set; } = new List<string> (new string[] { "3", "6", "9" });


        private string _creditsSelected;

        public string CreditsSelected
        {
            get 
            { 
                return _creditsSelected; 
            }
            set 
            { 
                _creditsSelected = value;
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
            this.Id = default;
            this.CreditsToSelect = null;
            this.CreditsSelected = null;
        }

        private void GetInfo()
        {
            var repoTea = Entity.DepCon.Resolve<ITeacherRepository>();
            Teachers = repoTea.QueryAll().ToList();
            TeaInDict = repoTea.GetNumberTeachers();
        }

        private void Edit()
        {
            this.Name = CurrentTeacher.Name;
            this.LastName1 = CurrentTeacher.LastName1;
            this.LastName2 = CurrentTeacher.LastName2;
            this.Id = CurrentTeacher.Id;
            this.CreditsSelected = CurrentTeacher.MaxCredits.ToString();
        }

        private void Delete()
        {
            var repo = Entity.DepCon.Resolve<ITeacherRepository>();
            var teaDelete = repo.Find(CurrentTeacher.Id);
            var nomTea = teaDelete.CompleteName;

            if (teaDelete == null)
                MessageToUser = "This teacher cannot be found in database, are you sure he hasn't been deleted yet?";

            else
            {
                var sr = teaDelete.Delete();

                if (sr.IsSuccess)
                    MessageToUser = $"The teacher {nomTea} has just been deleted!";

                else
                    MessageToUser = sr.AllErrors;
            }

            Clear();
            GetInfo();

        }

        private void Save()
        {
            ValidationResult<string> vrName = Teacher.ValidateName(this.Name);
            ValidationResult<string> vrLastName1 = Teacher.ValidateName(this.LastName1);
            ValidationResult<string> vrLastName2 = Teacher.ValidateName(this.LastName2);
            ValidationResult<int> vrCredits = Teacher.ValidateCredits(this.CreditsSelected);


            if (vrName.IsSuccess && vrLastName1.IsSuccess && vrLastName2.IsSuccess && vrCredits.IsSuccess)
            {
                var newTeacher = new Teacher()
                {
                    Name = vrName.ValidatedResult,
                    LastName1 = vrLastName1.ValidatedResult,
                    LastName2 = vrLastName2.ValidatedResult,
                    Id = this.Id,
                    MaxCredits = vrCredits.ValidatedResult
                    
                };

                var sr = newTeacher.Save();

                if (sr.IsSuccess)
                    MessageToUser = $"The teacher {newTeacher.CompleteName} have just been added! Let's work!!";

                Clear();
                GetInfo();
            }

        }

        private bool CanRegister()
        {
            if (this.Name != null && this.LastName1 != null && this.LastName2 != null && this.CreditsSelected != null)
                return true;
            else
                return false;
        }
    }
}
