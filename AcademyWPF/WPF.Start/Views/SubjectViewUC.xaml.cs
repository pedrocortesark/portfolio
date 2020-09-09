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
    /// Interaction logic for SubjectViewUC.xaml
    /// </summary>
    public partial class SubjectViewUC : UserControl
    {
        public SubjectViewUC()
        {
            InitializeComponent();

            var vm = new SubjectViewModel();
            this.DataContext = vm;

        }
    }
}
