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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestWPF
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    ///     
    public partial class MainWindow : Window
    {
        public bool login_success;

        public MainWindow()
        {
            InitializeComponent();
            login_success = false;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NewClick(object sender, RoutedEventArgs e)
        {
        }

        private void ExitEvent(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
