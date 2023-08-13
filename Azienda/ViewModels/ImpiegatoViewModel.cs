using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AppBase.ViewModels
{
    public class ImpiegatoViewModel: BaseViewModel
    {
        protected Models.Dipendente model = null;

        public ImpiegatoViewModel(Models.Dipendente model)
        {
            this.model = model;
        }

        public string Nome
        {
            get { return model.Nome; }
            set { model.Nome = value; OnPropertyChanged(); }
        }

        public string Cognome
        {
            get { return model.Cognome; }
            set { model.Cognome = value; OnPropertyChanged(); }
        }

        public DateTime DataNascita
        {
            get { return model.DataNascita; }
            set { model.DataNascita = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get { return model.Email; }
            set { model.Email = value; OnPropertyChanged(); }
        }

        public Models.GenereEnum Genere
        {
            get { return model.Genere; }
            set { model.Genere = value; OnPropertyChanged(); }
        }

        public decimal Stipendio
        {
            get { return model.Stipendio; }
            set { model.Stipendio = value; OnPropertyChanged(); }
        }

        public override string ToString()
        {
            return model.ToString();
        }


    }
}
