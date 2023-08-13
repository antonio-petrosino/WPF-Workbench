using AppBase.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace AppBase.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {

        public RelayCommand AggiungiCommand { get; private set; }
        public RelayCommand EliminaCommand { get; private set; }

        private bool _chiuso = false;
        public bool Chiuso
        {
            get { System.Diagnostics.Debug.WriteLine("OK siamo passati dal GET"); return _chiuso; } 
            set { _chiuso = value; OnPropertyChanged(); System.Diagnostics.Debug.WriteLine("KO siamo passati dal SET"); }

        }


        private int _valore = 0;

        public int Valore
        {
            get { return _valore; }
            set
            {
                _valore = value;
                OnPropertyChanged();
            }
        }

        public String Title { get; set; }


        public Array GenereItems { get; private set; }

        private string _lastActionText = "Nessuna operazione effettuata.";
        public string LastActionText
        {
            get { return _lastActionText; }
            set {   
                _lastActionText = value;
                OnPropertyChanged();
            }
        }


        private PersonaViewModel _selectedItem = null;
        public PersonaViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem == value) return;
                
                _selectedItem = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FormEnabled));
                EliminaCommand.RaiseCanExecuteChanged();
            }
        }

        public MainWindowViewModel() {

            AggiungiCommand = new ViewModels.RelayCommand(AggiungiMethod);
            EliminaCommand = new ViewModels.RelayCommand(EliminaMethod, EliminaCanEx);

            if (IsDesignMode)
            {
                Title = "Applicazione di esempio: SIAMO IN DESIGN MODE";
            }
            else
            {
                Title = "Applicazione di esempio: NON siamo in design mode";
            }

            GenereItems = Enum.GetValues(typeof(GenereEnum));

            Items = PopulateFromDB();

        }


        private string _myProperty = "Test iniziale";

        public string MyProperty
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("OK siamo passati dal GET");
                return _myProperty;
            }

            set
            {
                System.Diagnostics.Debug.WriteLine("KO siamo passati dal SET");
                _myProperty = value;
                OnPropertyChanged(); // necessario alla sync
            }
        }


        //public Models.Persona[] Items { get; private set; }
        //public List<PersonaViewModel> Items { get; private set; }
        public ObservableCollection<PersonaViewModel> Items { get; private set; }

        //private List<PersonaViewModel> PopulateFromDB()
        private ObservableCollection<PersonaViewModel> PopulateFromDB()
        {

            var persone = new List<Models.Persona> {
            new Models.Persona() { Nome = "Mario", Cognome = "Rossi", DataDiNascita = new DateTime(1970, 1, 1), Genere = Models.GenereEnum.Maschio, Email= "mario.rossi@server.it"},
            new Models.Persona() { Nome = "Maria", Cognome = "Rossa", DataDiNascita = new DateTime(1991, 12, 1), Genere = Models.GenereEnum.Femmina, Email= "maria.rossa@server.it"},
            new Models.Persona() { Nome = "Gianni", Cognome = "Toloi", DataDiNascita = new DateTime(2001, 1, 12), Genere = Models.GenereEnum.Maschio, Email= "gianni.toloi@server.it"},
            new Models.Persona() { Nome = "Mario", Cognome = "Mazzitelli", DataDiNascita = new DateTime(1999, 3, 1), Genere = Models.GenereEnum.Maschio, Email= "mario.mazzitelli@server.it"},
            new Models.Persona() { Nome = "Altro", Cognome = "Mazzitelli", DataDiNascita = new DateTime(1999, 3, 1), Genere = Models.GenereEnum.Altro, Email= "mario.mazzitelli@server.it"},
            };

            //Items = persone.Select(p => new PersonaViewModel(p)).ToList();
            Items = new ObservableCollection<PersonaViewModel>(persone.Select(p => new PersonaViewModel(p)).ToList());
            Items.CollectionChanged += Items_CollectionChanged;
            //throw new NotImplementedException();
            return Items;
        }

        private void Items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var nuovi = e.NewItems;
            var rimossi = e.OldItems;
            //OnPropertyChanged(nameof(FormEnabled));
                      

            if(e.NewItems != null)
            {
                SelectedItem = (PersonaViewModel)e.NewItems[e.NewItems.Count -1];
                LastActionText = "Hai aggiunto un nuovo elemento.";
            }

            if(e.OldItems != null)
            {
                LastActionText = "Hai eliminato" + e.OldItems.Count + " elementi: " + e.OldItems[e.OldItems.Count - 1].ToString();
                //OnPropertyChanged();
            }

        }

        private void AggiungiMethod(object param)
        {
            Models.Persona persona = new Models.Persona();
            ViewModels.PersonaViewModel item = new ViewModels.PersonaViewModel(persona);
            Items.Add(item);
            //SelectedItem = item;
        }

        private void EliminaMethod(object param)
        {            
                Items.Remove(SelectedItem);                    
        }

        private bool EliminaCanEx(object param)
        {
            return _selectedItem != null;
        }

        public bool FormEnabled => _selectedItem != null;

    }
}
