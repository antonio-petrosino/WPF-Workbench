using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBase.Models
{
    internal class Rappresentante : Dipendente
    {
        public decimal Diaria { get; set; }
        public decimal Totale => Stipendio + Diaria;
    }
}
