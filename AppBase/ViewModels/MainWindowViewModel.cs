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

        public MainWindowViewModel() {
            if (IsDesignMode)
            {
                Title = "Applicazione di esempio: SIAMO IN DESIGN MODE";
            }
            else
            {
                Title = "Applicazione di esempio: NON siamo in design mode";
            }
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
    }
}
