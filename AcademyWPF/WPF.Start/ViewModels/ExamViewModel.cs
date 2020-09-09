using Common.Lib.Core;
using Common.Lib.Core.Context;
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
    public class ExamViewModel : GenericViewModel
    {
        #region Properties!!

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


        private DateTime _date = DateTime.Now;

        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
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


        private string _grade;

        public string Grade
        {
            get 
            { 
                return _grade; 
            }
            set 
            { 
                _grade = value;
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


        private int _examsInDict;

        public int ExamsInDict
        {
            get
            {
                return _examsInDict;
            }
            set
            {
                _examsInDict = value;
                RaisePropertyChanged();
            }
        }

        #endregion


        private List<Exam> _exams = new List<Exam>();

        public List<Exam> Exams
        {
            get
            {
                return _exams;
            }
            set
            {
                _exams = value;
                RaisePropertyChanged();
            }
        }


        private Exam _currentExam;

        public Exam CurrentExam
        {
            get
            {
                return _currentExam;
            }
            set
            {
                _currentExam = value;
                RaisePropertyChanged();
                GetInfoExam(CurrentExam.SubjectId);
            }
        }



        private List<Student> _studentsToGrade = new List<Student>();

        public List<Student> StudentsToGrade
        {
            get
            {
                return _studentsToGrade;
            }
            set
            {
                _studentsToGrade = value;
                RaisePropertyChanged();
            }
        }

        
        private Student _currentStudentToGrade;

        public Student CurrentStudentToGrade
        {
            get
            {
                return _currentStudentToGrade;
            }
            set
            {
                _currentStudentToGrade = value;
                RaisePropertyChanged();
            }
        }



        private List<StudentExam> _studentsGraded = new List<StudentExam>();

        public List<StudentExam> StudentsGraded
        {
            get
            {
                return _studentsGraded;
            }
            set
            {
                _studentsGraded = value;
                RaisePropertyChanged();
            }
        }


        private StudentExam _currentstudentsGraded;

        public StudentExam CurrentStudentsGraded
        {
            get
            {
                return _currentstudentsGraded;
            }
            set
            {
                _currentstudentsGraded = value;
                RaisePropertyChanged();
            }
        }


        #region Commands

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


        private ICommand _addGradeCommand;

        public ICommand AddGradeCommand
        {
            get
            {
                if (_addGradeCommand == null)
                    _addGradeCommand = new RelayCommand(new Action(AddGrade), () => CanRegisterGrade());

                return _addGradeCommand;
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


        private ICommand _deleteCommand;

        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                    _deleteCommand = new RelayCommand(new Action(Delete));

                return _deleteCommand;
            }
        }


        private ICommand _deleteGradeCommand;

        public ICommand DeleteGradeCommand
        {
            get
            {
                if (_deleteGradeCommand == null)
                    _deleteGradeCommand = new RelayCommand(new Action(DeleteGrade));

                return _deleteGradeCommand;
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


        private ICommand _editGradeCommand;

        public ICommand EditGradeCommand
        {
            get
            {
                if (_editGradeCommand == null)
                    _editGradeCommand = new RelayCommand(new Action(EditGrade));

                return _editGradeCommand;
            }
        }

        #endregion


        private void GetInfo()
        {
            var repo = Entity.DepCon.Resolve<IExamRepository>();
            Exams = repo.QueryAll().ToList();
            ExamsInDict = repo.GetNumberExams();

            var repoSub = Entity.DepCon.Resolve<ISubjectRepository>();
            SubjectsToSelect = repoSub.QueryAll().ToList();

        }

        private void GetInfoExam(Guid currentSubjectId)
        {
           
            var repoExamStu = Entity.DepCon.Resolve<IRepository<StudentExam>>();
            StudentsGraded = repoExamStu.QueryAll().Where(x => x.ExamId == CurrentExam.Id).ToList();

            var repoSub = Entity.DepCon.Resolve<ISubjectRepository>();
            var students = repoSub.Find(currentSubjectId).Students;

            var listYet = new List<Student>();

            foreach (var student in students)
            {
                if (repoExamStu.QueryAll().Any(x => x.StudentId == student.Id && x.ExamId == CurrentExam.Id))
                    continue;
                else
                    listYet.Add(student);
            }

            StudentsToGrade = listYet;
        }

        private void Clear()
        {
            this.Name = null;
            this.Date = DateTime.Now;
            this.Id = default;
            this.SubjectSelected = default;
            this.Grade = null;
        }

        private void Save()
        {
            
            ValidationResult<string> vrName = Exam.ValidateName(this.Name);
            ValidationResult vrSubject = Exam.ValidateSubject(this.SubjectSelected);
            ValidationResult vrDate = Exam.ValidateDate(this.Date);


            if (vrName.IsSuccess && vrSubject.IsSuccess && vrDate.IsSuccess)
            {
                var newExam = new Exam()
                {
                    Name = vrName.ValidatedResult,
                    Id = this.Id,
                    Date = this.Date,
                    SubjectId = this.SubjectSelected.Id,
                };

                var sr = newExam.Save();

                if (sr.IsSuccess)
                    MessageToUser = $"The exam {newExam.Name} for {this.SubjectSelected.Name} have just been added!";
            }

            else
            {
                var errors = string.Empty;
                errors += vrName.AllErrors;
                errors += vrSubject.AllErrors;
                errors += vrDate.AllErrors;
                MessageToUser = errors;
            }

            Clear();
            GetInfo();
        }

        private void Edit()
        {
            this.Name = CurrentExam.Name;
            this.Id = CurrentExam.Id;
            this.SubjectSelected = CurrentExam.Subject;
            this.Date = CurrentExam.Date;
            int index = SubjectsToSelect.IndexOf(SubjectsToSelect.Single(s => s.Id == CurrentExam.SubjectId));
            this.SubjectSelected = SubjectsToSelect[index];
        }

        private void Delete()
        {
            var repo = Entity.DepCon.Resolve<IRepository<Exam>>();
            var examDelete = repo.Find(CurrentExam.Id);
            var nomExam = examDelete.Name;

            if (examDelete == null)
                MessageToUser = "Check!! This exam cannot be found in database!";

            else
            {
                var sr = examDelete.Delete();

                if (sr.IsSuccess)
                    MessageToUser = $"The teacher {nomExam} has just been deleted!";

                else
                    MessageToUser = sr.AllErrors;
            }

            Clear();
            GetInfo();
        }

        private void AddGrade()
        {

            ValidationResult<double> vrGrade = StudentExam.ValidateGrade(this.Grade);
            ValidationResult vrStudent = StudentExam.ValidateStudent(this.CurrentStudentToGrade, this.CurrentExam);


            if (vrGrade.IsSuccess)
            {
                var studentExam = new StudentExam()
                {
                    Id = this.Id,
                    StudentId = CurrentStudentToGrade.Id,
                    ExamId = CurrentExam.Id,
                    Grade = vrGrade.ValidatedResult
                };

                var sr = studentExam.Save();

                if (!sr.IsSuccess)
                    MessageToUser = "Check!! There has been problems!";
                else
                    MessageToUser = $"{CurrentStudentToGrade.Name} {CurrentStudentToGrade.LastName} has been graded in the exam of {CurrentExam.Name} with a {vrGrade.ValidatedResult}";
            }
            else
            {
                var errors = string.Empty;

                errors += vrGrade.AllErrors;

                MessageToUser = errors;
            }

            Clear();
            GetInfo();

        }

        private void DeleteGrade()
        {
            var repo = Entity.DepCon.Resolve<IRepository<StudentExam>>();
            var examDelete = repo.Find(CurrentStudentsGraded.Id);
            var nomExam = examDelete.Student.CompleteName;

            if (examDelete == null)
                MessageToUser = "Check!! This exam cannot be found in database!";

            else
            {
                var sr = examDelete.Delete();

                if (sr.IsSuccess)
                    MessageToUser = $"The teacher {nomExam} has just been deleted!";

                else
                    MessageToUser = sr.AllErrors;
            }

            Clear();
            GetInfo();
        }

        private void EditGrade()
        {
            this.Grade = CurrentStudentsGraded.Grade.ToString();
            this.CurrentStudentToGrade = CurrentStudentsGraded.Student;
            this.CurrentExam = CurrentStudentsGraded.Exam;
            this.Id = CurrentStudentsGraded.Id;
        }

        private bool CanRegister()
        {
            if (this.Name != null && this.Date != null && this.SubjectSelected != null)
                return true;
            else
                return false;
        }

        private bool CanRegisterGrade()
        {
            if (this.CurrentExam != null && this.CurrentStudentToGrade != null && this.Grade != null)
                return true;
            else
                return false;
        }
    }
}
