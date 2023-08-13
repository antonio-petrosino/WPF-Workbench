using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBase.ViewModels
{
    public class RappresentanteViewModel : ImpiegatoViewModel
    {
        public RappresentanteViewModel(Models.Dipendente model) : base(model)
        {
        }

        public decimal Diaria
        {
            get { return ((Models.Rappresentante)model).Diaria; }
            set { ((Models.Rappresentante)model).Diaria = value; OnPropertyChanged(); }
        }

        public decimal Totale => ((Models.Rappresentante)model).Totale;
        
    }
    
}
