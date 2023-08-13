using AppBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AppBase.ViewModels
{
    internal class PersonaViewModel : BaseViewModel
    {
        private Models.Persona _persona = null;

        public PersonaViewModel(Models.Persona model)
        {
            _persona = model;
        }

        public string Nome
        {             
            get { return _persona.Nome; }
                   
            set
            {
                _persona.Nome = value;
                OnPropertyChanged();
            }
        }

        public string Cognome
        {
            get { return _persona.Cognome; }

            set
            {
                _persona.Cognome = value;
                OnPropertyChanged();
            }
        }

        public DateTime DataDiNascita
        {
            get { return _persona.DataDiNascita; }

            set
            {
                _persona.DataDiNascita = value;
                OnPropertyChanged();
            }
        }

        //public Models.GenereEnum Genere
        //{
        //    get { return _persona.Genere; }

        //    set
        //    {
        //        _persona.Genere = value;
        //        OnPropertyChanged();
        //    }
        //}

        public string Email
        {
            get { return _persona.Email; }

            set
            {
                _persona.Email = value;
                OnPropertyChanged();
            }
        }

        
        public GenereEnum Genere 
        { 
            get => _persona.Genere; 
            
            set 
            { 
                _persona.Genere = value; 
                OnPropertyChanged(); 
                OnPropertyChanged((nameof(Colore))); 
            } 
        }

        public Brush Colore => Genere == Models.GenereEnum.Maschio ? Brushes.Blue : Genere == Models.GenereEnum.Femmina ? Brushes.Pink : Brushes.Green;

        public override string ToString()
        {
            return _persona.ToString();
        }
    }
}
