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
using WPF.Start.ViewModels;

namespace WPF.Start.ViewModels
{
    public class SubjectViewModel : GenericViewModel
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

        private string _numStudents;

        public string NumStudents
        {
            get
            {
                return _numStudents;
            }
            set
            {
                _numStudents = value;
                RaisePropertyChanged();
            }
        }

        private string _credits;

        public string Credits
        {
            get
            {
                return _credits;
            }
            set
            {
                _credits = value;
                RaisePropertyChanged();
            }
        }

        private string _season;

        public string Season
        {
            get
            {
                return _season;
            }
            set
            {
                _season = value;
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


        private int _sbjInDict;

        public int SbjInDict
        {
            get
            {
                return _sbjInDict;
            }
            set
            {
                _sbjInDict = value;
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

        private List<Subject> _subjects = new List<Subject>();

        public List<Subject> Subjects
        {
            get
            {
                return _subjects;
            }
            set
            {
                _subjects = value;
                RaisePropertyChanged();
            }
        }


        private Subject _currentSubject;

        public Subject CurrentSubject
        {
            get
            {
                return _currentSubject;
            }
            set
            {
                _currentSubject = value;
                RaisePropertyChanged();
            }
        }


        private List<Teacher> _teachersToSelect;

        public List<Teacher> TeachersToSelect
        {
            get
            {
                return _teachersToSelect;
            }
            set
            {
                _teachersToSelect = value;
                RaisePropertyChanged();
            }
        }
      
        public List<string> SeasonToSelect { get; set; } = new List<string>(new string[] { "Fall", "Spring"});
        

        private Teacher _teacherSelected;

        public Teacher TeacherSelected
        {
            get
            {
                return _teacherSelected;
            }
            set
            {
                _teacherSelected = value;
                RaisePropertyChanged();
            }
        }

        public List<string> CreditsToSelect { get; set; } = new List<string>(new string[] { "3", "6", "9" });


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
            this.TeacherSelected = null;
            this.Season = null;
            this.CreditsToSelect = null;
            this.CreditsSelected = null;
            this.NumStudents = null;
            this.Id = default;
        }

        private void GetInfo()
        {
            var repoSub = Entity.DepCon.Resolve<ISubjectRepository>();
            Subjects = repoSub.QueryAll().ToList();
            SbjInDict = repoSub.GetNumberSubjects();

            var repoTea = Entity.DepCon.Resolve<ITeacherRepository>();
            TeachersToSelect = repoTea.QueryAll().ToList();

        }

        private void Edit()
        {
            this.Name = CurrentSubject.Name;
            int index = TeachersToSelect.IndexOf(TeachersToSelect.Single(t => t.CompleteName == CurrentSubject.TeacherName));
            this.TeacherSelected = TeachersToSelect[index];
            this.Id = CurrentSubject.Id;
            this.Season = CurrentSubject.Season;
            this.NumStudents = CurrentSubject.NumberStudents.ToString();
            this.CreditsSelected = CurrentSubject.Credits.ToString();
        }

        private void Delete()
        {
            var repo = Entity.DepCon.Resolve<ISubjectRepository>();
            var subDelete = repo.Find(CurrentSubject.Id);
            var nomSub = subDelete.Name;

            if (subDelete == null)
            {
                MessageToUser = "This subject cannot be found in database.";
                MessageToUser += "\n\rAre you sure you haven't delete it already";
            }
                
            else
            {
                subDelete.Delete();
                MessageToUser = $"Subject {nomSub} have just been deleted!";
            }

            Clear();
            GetInfo();

        }

        private void Save()
        {
            ValidationResult<string> vrName = Subject.ValidateName(this.Name, this.Id);
            ValidationResult<string> vrSeason = Subject.ValidateSeason(this.Season);
            ValidationResult<int> vrNumStu = Subject.ValidateNumberStudents(this.NumStudents);
            ValidationResult<int> vrCredits = Subject.ValidateCredits(this.CreditsSelected);
            ValidationResult vrTeacher = Subject.ValidateTeacher(this.CreditsSelected, this.TeacherSelected.Id, this.Id);


            if (vrName.IsSuccess && TeacherSelected != null && vrNumStu.IsSuccess && vrSeason.IsSuccess && vrCredits.IsSuccess && vrTeacher.IsSuccess)
            {
                var newSubject = new Subject()
                {
                    Name = vrName.ValidatedResult,
                    Id = this.Id,
                    TeacherId = TeacherSelected.Id,
                    NumberStudents = vrNumStu.ValidatedResult,
                    Season = this.Season,
                    Credits = vrCredits.ValidatedResult

                };

                var sr = newSubject.Save();

                if (sr.IsSuccess)
                    MessageToUser = $"Subject {newSubject.Name} have just been added!";

                Clear();
                GetInfo();
            }

            else
            {
                var errors = string.Empty;
                errors += vrName.AllErrors;
                errors += vrSeason.AllErrors;
                errors += vrNumStu.AllErrors;
                errors += vrCredits.AllErrors;
                errors += vrTeacher.AllErrors;
                MessageToUser = errors;
            }
        }

        private bool CanRegister()
        {
            if (this.Name != null && this.TeacherSelected != null && this.Season != null && this.NumStudents != null && this.CreditsSelected != null)
                return true;
            else
                return false;
        }
    }
}
