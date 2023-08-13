using AppBase;
using AppBase.Models;
using AppBase.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Azienda.ViewModels
{
    
    public class MainWindowViewModel : BaseViewModel
    {

        public RelayCommand DettaglioCommand { get; private set; }

        private string _titolo = "";
        public string Titolo
        {
            get { return _titolo; }
            set { _titolo = value; OnPropertyChanged(); }
        }


        public MainWindowViewModel()
        {
            if (IsDesignMode)
                Titolo = "Siamo in fase di design.";
            else
            {
                  Titolo = "Siamo in fase di esecuzione.";
            }


            Dipendente[] arrayFromDB = new Dipendente[]
            {
                new Impiegato(){Nome = "Maria", Cognome = "Rossi", DataNascita = new DateTime(1980, 1, 1), Email = "mario.rossi@mail.it", Stipendio = 1000m, Genere = GenereEnum.Femmina},
                new Impiegato(){Nome = "Gianna", Cognome = "Verdi", DataNascita = new DateTime(1980, 1, 1), Email = "mario.rossi@mail.it", Stipendio = 2000m, Genere = GenereEnum.Femmina},
                new Impiegato(){Nome = "Pasquale", Cognome = "Bianchi", DataNascita = new DateTime(1980, 1, 1), Email = "mario.rossi@mail.it", Stipendio = 3000m, Genere = GenereEnum.Maschio},
                new Impiegato(){Nome = "Antonio", Cognome = "Petrosino", DataNascita = new DateTime(1980, 1, 1), Email = "mario.rossi@mail.it", Stipendio = 4000m, Genere = GenereEnum.Maschio},
                new Rappresentante(){Nome = "Mario", Cognome = "Il Rappresentante", DataNascita = new DateTime(1980, 1, 1), Email = "mario.rappresentante@email.it", Genere = GenereEnum.Maschio, Diaria = 300m, Stipendio = 1000m},
                new Rappresentante(){Nome = "Filippo", Cognome = "Nzoth", DataNascita = new DateTime(1980, 1, 1), Email = "mario.rappresentante@email.it", Genere = GenereEnum.Maschio, Diaria = 300m, Stipendio = 1000m},
                new Rappresentante(){Nome = "AnziNo", Cognome = "Prott", DataNascita = new DateTime(1980, 1, 1), Email = "mario.rappresentante@email.it", Genere = GenereEnum.Femmina, Diaria = 600m, Stipendio = 1000m},
                new Rappresentante(){Nome = "Giorgia", Cognome = "Spett", DataNascita = new DateTime(1980, 1, 1), Email = "mario.rappresentante@email.it", Genere = GenereEnum.Femmina, Diaria = 7300m, Stipendio = 10000m}
            };

            Dipendenti = new ObservableCollection<Dipendente>(arrayFromDB);

            DettaglioCommand = new RelayCommand(dettaglioMethod, dettaglioCanExec);
        }

        //private void Items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        //{
        //    var nuovi = e.NewItems;
        //    var rimossi = e.OldItems;
        //    //OnPropertyChanged(nameof(FormEnabled));


        //    if (e.NewItems != null)
        //    {
        //        SelectedItem = (PersonaViewModel)e.NewItems[e.NewItems.Count - 1];
        //        LastActionText = "Hai aggiunto un nuovo elemento.";
        //    }

        //    if (e.OldItems != null)
        //    {
        //        LastActionText = "Hai eliminato" + e.OldItems.Count + " elementi: " + e.OldItems[e.OldItems.Count - 1].ToString();
        //        //OnPropertyChanged();
        //    }

        //}

        public BaseViewModel DipendenteVM { get; private set; }
        private Dipendente _dipendenteSelezionato = null;
        
        public Dipendente DipendenteSelezionato
        {
            get => _dipendenteSelezionato;
            set
            {
                _dipendenteSelezionato = value;
                OnPropertyChanged();
                if (value.GetType() == typeof(Impiegato)) DipendenteVM = new ImpiegatoViewModel(value);

                if (value.GetType() == typeof(Rappresentante)) DipendenteVM = new RappresentanteViewModel(value); 

                OnPropertyChanged(nameof(DipendenteVM));
                DettaglioCommand.RaiseCanExecuteChanged();
                

            }
        }



        private void dettaglioMethod(object param)
        {

            BaseViewModel viewModel = null;
            if (_dipendenteSelezionato is Impiegato)
                viewModel = new ImpiegatoViewModel(_dipendenteSelezionato);

            if (_dipendenteSelezionato is Rappresentante)
                viewModel = new RappresentanteViewModel(_dipendenteSelezionato);

            WindowService.ShowDialog("Dettaglio Dipendente", viewModel);
        }

        private bool dettaglioCanExec(object param)
        {
            return _dipendenteSelezionato != null;
        }

        public ObservableCollection<Dipendente> Dipendenti { get; private set; }

    }
}
