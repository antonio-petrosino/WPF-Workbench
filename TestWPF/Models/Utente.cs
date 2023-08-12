using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF.Models
{
    public class Utente
    {
        public string TipoUtente { get; set; }
        public string RAL { get; set; }

        public Utente()
        {
            TipoUtente = "";
            RAL = "";
        }
    }
}
