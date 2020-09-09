using Common.Lib.Core;
using Common.Lib.Core.Context;
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
    class StatisticsViewModel : GenericViewModel
    {

        #region Properties

        private double _maxGradeStu;

        public double MaxGradeStu
        {
            get 
            { 
                return _maxGradeStu; 
            }
            set 
            {
                _maxGradeStu = value;
                RaisePropertyChanged();
            }
        }

        private double _maxGradeExa;

        public double MaxGradeExa
        {
            get 
            { 
                return _maxGradeExa; 
            }
            set 
            { 
                _maxGradeExa = value;
                RaisePropertyChanged();
            }
        }

        private double _maxGradeSub;

        public double MaxGradeSub
        {
            get
            {
                return _maxGradeSub;
            }
            set
            {
                _maxGradeSub = value;
                RaisePropertyChanged();
            }
        }


        private double _minGradeStu;

        public double MinGradeStu
        {
            get
            {
                return _minGradeStu;
            }
            set
            {
                _minGradeStu = value;
                RaisePropertyChanged();
            }
        }

        private double _minGradeExa;

        public double MinGradeExa
        {
            get
            {
                return _minGradeExa;
            }
            set
            {
                _minGradeExa = value;
                RaisePropertyChanged();
            }
        }


        private double _minGradeSub;

        public double MinGradeSub
        {
            get
            {
                return _minGradeSub;
            }
            set
            {
                _minGradeSub = value;
                RaisePropertyChanged();
            }
        }


        private double _averageStu;

        public double AverageStu
        {
            get
            {
                return _averageStu;
            }
            set
            {
                _averageStu = value; 
                RaisePropertyChanged();
            }
        }

        private double _averageSub;

        public double AverageSub
        {
            get
            {
                return _averageSub;
            }
            set
            {
                _averageSub = value;
                RaisePropertyChanged();
            }
        }


        private double _averageExa;

        public double AverageExa
        {
            get
            {
                return _averageExa;
            }
            set
            {
                _averageExa = value;
                RaisePropertyChanged();
            }
        }


        private string _messageStu;

        public string MessageStu
        {
            get
            {
                return _messageStu;
            }
            set
            {
                _messageStu = value;
                RaisePropertyChanged();
            }
        }


        private string _messageSub;

        public string MessageSub
        {
            get
            {
                return _messageSub;
            }
            set
            {
                _messageSub = value;
                RaisePropertyChanged();
            }
        }


        private string _messageExa;

        public string MessageExa
        {
            get
            {
                return _messageExa;
            }
            set
            {
                _messageExa = value;
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
            }
        }


        private List<Subject> _subjects;

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


        private List<Student> _students;

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


        private ICommand _getStatisticsStuCommand;

        public ICommand GetStatisticsStuCommand
        {
            get
            {
                if (_getStatisticsStuCommand == null)
                    _getStatisticsStuCommand = new RelayCommand(new Action(GetStatisticsStu), () => CanRegisterStu());

                return _getStatisticsStuCommand;
            }
        }


        private ICommand _getStatisticsExaCommand;

        public ICommand GetStatisticsExaCommand
        {
            get
            {
                if (_getStatisticsExaCommand == null)
                    _getStatisticsExaCommand = new RelayCommand(new Action(GetStatisticsExa), () => CanRegisterExa());

                return _getStatisticsExaCommand;
            }
        }


        private ICommand _getStatisticsSubCommand;

        public ICommand GetStatisticsSubCommand
        {
            get
            {
                if (_getStatisticsSubCommand == null)
                    _getStatisticsSubCommand = new RelayCommand(new Action(GetStatisticsSub), () => CanRegisterSub());

                return _getStatisticsSubCommand;
            }
        }

        #endregion


        private void GetInfo()
        {
            var repoEx = Entity.DepCon.Resolve<IExamRepository>();
            Exams = repoEx.QueryAll().ToList();

            var repoSub = Entity.DepCon.Resolve<ISubjectRepository>();
            Subjects = repoSub.QueryAll().ToList();

            var repoStu = Entity.DepCon.Resolve<IStudentRepository>();
            Students = repoStu.QueryAll().ToList();

        }

        private void GetStatisticsStu()
        {
            var repo = Entity.DepCon.Resolve<IRepository<StudentExam>>();
            var grades = repo
                .QueryAll()
                .Where(x => x.StudentId == CurrentStudent.Id)
                .Select(x => x.Grade)
                .OrderBy(x => x)
                .ToList();

            if (grades.Count != 0)
            {
                MinGradeStu = grades[0];
                MaxGradeStu = grades[grades.Count - 1];

                var sum = 0.0;
                foreach (var element in grades)
                {
                    sum += element;
                }

                var average = sum / grades.Count;
                AverageStu = Math.Round(average, 2);
                MessageStu = $"These are the statistics of the student {CurrentStudent.Name}";
            }
            else
            {
                MessageStu = "This student hadn't done any exam yet!!";
                MinGradeStu = 0;
                MaxGradeStu = 0;
                AverageStu = 0;
            }
            
        }

        private void GetStatisticsSub()
        {
            var repoEx = Entity.DepCon.Resolve<IExamRepository>();
            var exams = repoEx
                .QueryAll()
                .Where(x => x.SubjectId == CurrentSubject.Id)
                .Select(x => x.Id)
                .ToList();

            var repo = Entity.DepCon.Resolve<IRepository<StudentExam>>();
            var grades = new List<double>();

            foreach (var exam in exams)
            {
                var examStu = repo
                .QueryAll()
                .Where(x => x.ExamId == exam)
                .Select(x => x.Grade)
                .ToList();

                foreach (var examGrade in examStu)
                {
                    grades.Add(examGrade);
                }
                MessageSub = $"This is the statistics of the subject {CurrentSubject.Name}";
            }

            if (grades.Count != 0)
            {
                var gradesSorted = grades.OrderBy(x => x).ToList();

                MinGradeSub = gradesSorted[0];
                MaxGradeSub = gradesSorted[gradesSorted.Count - 1];

                var sum = 0.0;
                foreach (var element in gradesSorted)
                    sum += element;

                var average = sum / grades.Count;
                AverageSub = average;
            }
            else
            {
                MinGradeSub = 0.0;
                MaxGradeSub = 0.0;
                AverageSub = 0.0;
                MessageSub = "There isn't any exams in this subject!!";
            }


            
        }

        private void GetStatisticsExa()
        {
            var repo = Entity.DepCon.Resolve<IRepository<StudentExam>>();
            var grades = repo
                .QueryAll()
                .Where(x => x.ExamId == CurrentExam.Id)
                .Select(x => x.Grade)
                .OrderBy(x => x)
                .ToList();

            if (grades.Count != 0)
            {
                MinGradeExa = grades[0];
                MaxGradeExa = grades[grades.Count - 1];

                var sum = 0.0;
                foreach (var element in grades)
                {
                    sum += element;
                }

                var average = sum / grades.Count;
                AverageExa = Math.Round(average, 2);
                MessageExa = $"This is the statistics of the exam {CurrentExam.Name}";
            }
            else
            {
                MessageExa = "There isn't any exams done!!";
                MinGradeExa = 0;
                MaxGradeExa = 0;
                AverageExa = 0;
            }
            
        }

        private bool CanRegisterStu()
        {
            if (CurrentStudent == null)
                return false;
            else
                return true;
        }

        private bool CanRegisterExa()
        {
            if (CurrentExam == null)
                return false;
            else
                return true;
        }

        private bool CanRegisterSub()
        {
            if (CurrentSubject == null)
                return false;
            else
                return true;
        }

    }
}
