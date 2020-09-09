using Common.Lib.Core;
using P.BL.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for TeacherViewUC.xaml
    /// </summary>
    public partial class TeacherViewUC : UserControl
    {
        public TeacherViewUC()
        {
            InitializeComponent();

            var vm = new TeacherViewModel();
            this.DataContext = vm;

        }
    }
}
