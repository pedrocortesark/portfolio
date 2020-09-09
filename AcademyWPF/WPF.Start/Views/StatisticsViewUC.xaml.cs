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
    /// Interaction logic for StatisticsViewUC.xaml
    /// </summary>
    public partial class StatisticsViewUC : UserControl
    {
        public StatisticsViewUC()
        {
            InitializeComponent();

            var vm = new StatisticsViewModel();
            this.DataContext = vm;
        }
    }
}
