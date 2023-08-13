using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Azienda
{
    /// <summary>
    /// Logica di interazione per App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            this.MainWindow = new Views.MainWindowView();

            this.MainWindow.DataContext = new ViewModels.MainWindowViewModel();
            // la view non ha nessun legame con la view model
            // è solo qui che si collega 
            // programmatore splittato dal grafico

            this.MainWindow.Show();
        }
    }
}
