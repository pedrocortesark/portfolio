using Common.Lib.Core;
using Common.Lib.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Views;
using WPF.Start.Infraestructure;
using WPF.Start.ViewModels;
using WPF.Start.Views;

namespace Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            GenericViewModel.ShowMessageAction = (s) => MessageBox.Show(s);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var menu = new BaseMenu();
            this.Close();
            menu.ShowDialog();
            
        }

    
    }
}
