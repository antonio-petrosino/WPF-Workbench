using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.CodeDom.Compiler;
using System.Windows;

namespace TestWPF.ViewModels
{

    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<object> executeMethod;
        private Predicate<object> CanExecuteMethod;

        public RelayCommand(Action<object> executeMethod, Predicate<object> CanExecuteMethod)
        {
            this.executeMethod = executeMethod;
            this.CanExecuteMethod = CanExecuteMethod;
        }

        public RelayCommand(Action<object> Execute) : this(Execute, null)
        { }

        public bool CanExecute(object parameter)
        {
            return (CanExecuteMethod == null) ? true : CanExecuteMethod.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            executeMethod.Invoke(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public void Destroy()
        {
            CanExecuteMethod = _ => false;
            executeMethod = _ => { return; };
        }

        public void Destroy(Action<object> executeMethod)
        {
            CanExecuteMethod = _ => false;
            this.executeMethod = executeMethod;
        }
    }

    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            //if (PropertyChanged != null)
            //    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            // elvis operator , se non è null invoca l'evento
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class loginViewModel : ViewModelBase
    {
        private Models.IUtenteService _utenteService = null;

        public RelayCommand CheckCredentialCmd { get; private set; }


        //public event PropertyChangedEventHandler PropertyChanged;

        public loginViewModel(Models.IUtenteService utenteService_toPass)
        {
            _utenteService = utenteService_toPass;
            _txtStatoConnessione = "Non connesso";
            CheckCredentialCmd = new RelayCommand(param => Logging(), param => UtenteSelezionato != null);
        }

        public IList<Models.Utente> Utenti
        {
            get { return _utenteService.Utenti; }
        }

        //public Models.Utente UtenteSelezionato { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        private Models.Utente _utenteSelezionato = null;

        public Models.Utente UtenteSelezionato
        {
            get { return _utenteSelezionato; }
            set
            {
                // se il valore selezionato è uguale al precedente non faccio nulla
                if (_utenteSelezionato == value) return;
                _utenteSelezionato = value;

                OnPropertyChanged();
                CheckCredentialCmd.RaiseCanExecuteChanged();
            }
        }

        private string _txtStatoConnessione { get; set; }
        public string TextStatoConnessione
        {
            get { return _txtStatoConnessione; }
            set // sollevo handler, ma chi lo intercetta? è automatico con il binding
            {
                _txtStatoConnessione = value;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TextStatoConnessione"));
                // elvis operator , se non è null invoca l'evento
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextStatoConnessione)));
                OnPropertyChanged();
                //OnPropertyChanged(null); // refresh di tutti i controlli
            }
        }
        public bool CheckCredential()
        {

            if (UtenteSelezionato.TipoUtente == null)
            {
                return false;
            }
            else
            {
                TextStatoConnessione = "Accesso in corso...";
                return (Username == "admin" && Password == "admin" && UtenteSelezionato.TipoUtente == "Strutturato");
            }
        }


        public void Logging()
        {
            if (CheckCredential())
            {
                TextStatoConnessione = "Connesso";
                MainWindow main = new MainWindow();
                main.Show();
                //this.Close();
            }
            else
            {
                MessageBox.Show("Username o password errati");

            }
        }
    }
}
