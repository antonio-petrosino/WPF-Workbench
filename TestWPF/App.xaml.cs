using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TestWPF
{
    /// <summary>
    /// Logica di interazione per App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e); //base è la classe padre

            Models.UtenteService utenteService = new Models.UtenteService();
            ViewModels.loginViewModel vm = new ViewModels.loginViewModel(utenteService);

            login login = new login(vm);

            //login login = new login(new Models.UtenteService());
            login.Show();
        }
    }
}
