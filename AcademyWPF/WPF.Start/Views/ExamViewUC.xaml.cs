using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.Start.ViewModels;

namespace WPF.Start.Views
{
    /// <summary>
    /// Interaction logic for ExamViewUC.xaml
    /// </summary>
    public partial class ExamViewUC : UserControl
    {
        public ExamViewUC()
        {
            InitializeComponent();

            var vm = new ExamViewModel();
            this.DataContext = vm;
            
        }
    }
}
