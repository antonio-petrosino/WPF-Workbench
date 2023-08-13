using AppBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace AppBase.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {
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

        public MainWindowViewModel() {
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

        private List<PersonaViewModel> PopulateFromDB()
        {

            var persone  = new List<Models.Persona> {
            new Models.Persona() { Nome = "Mario", Cognome = "Rossi", DataDiNascita = new DateTime(1970, 1, 1), Genere = Models.GenereEnum.Maschio, Email= "mario.rossi@server.it"},
            new Models.Persona() { Nome = "Maria", Cognome = "Rossa", DataDiNascita = new DateTime(1991, 12, 1), Genere = Models.GenereEnum.Femmina, Email= "maria.rossa@server.it"},
            new Models.Persona() { Nome = "Gianni", Cognome = "Toloi", DataDiNascita = new DateTime(2001, 1, 12), Genere = Models.GenereEnum.Maschio, Email= "gianni.toloi@server.it"},
            new Models.Persona() { Nome = "Mario", Cognome = "Mazzitelli", DataDiNascita = new DateTime(1999, 3, 1), Genere = Models.GenereEnum.Maschio, Email= "mario.mazzitelli@server.it"},
            new Models.Persona() { Nome = "Altro", Cognome = "Mazzitelli", DataDiNascita = new DateTime(1999, 3, 1), Genere = Models.GenereEnum.Altro, Email= "mario.mazzitelli@server.it"},
            };

            Items = persone.Select(p => new PersonaViewModel(p)).ToList();

            //throw new NotImplementedException();
            return Items;
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
        public List<PersonaViewModel> Items { get; private set; }


    }
}
