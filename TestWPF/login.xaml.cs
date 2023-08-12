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
using System.Windows.Shapes;
using TestWPF.Models;

namespace TestWPF
{
    /// <summary>
    /// Logica di interazione per login.xaml
    /// </summary>
    public partial class login : Window
    {
        //private Models.IUtenteService utenteService = null;
        public login(ViewModels.loginViewModel vm)
        {
            InitializeComponent();

            //utenteService = utenteService_toPass;

            DataContext = vm;

            //cmbTipoUtente.ItemsSource = utenteService.Utenti;
            //cmbTipoUtente.DisplayMemberPath = "TipoUtente";

        }

        /*private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if ((DataContext as ViewModels.loginViewModel).CheckCredential(txtUsername.Text, txtPassword.Text, cmbTipoUtente.SelectedItem))
            {
                (DataContext as ViewModels.loginViewModel).TextStatoConnessione = "Connesso";
                MainWindow main = new MainWindow();
                main.Show();
                //this.Close();
            }
            else
            {
                MessageBox.Show("Username o password errati");
                
            }

            
        }*/


        /*private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnLogin_Click(sender, e);
            }
            
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnLogin_Click(sender, e);
            }
        }*/
    }
}
