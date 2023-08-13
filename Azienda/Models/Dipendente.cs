using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBase.Models
{
    public abstract class Dipendente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public string Email { get; set; }
        public GenereEnum Genere { get; set; }
        public decimal Stipendio { get; set; }


        public override string ToString()
        {
            return $"{Nome} {Cognome}";
        }
    }

    public enum GenereEnum
    {
        Maschio,
        Femmina,
        Altro
    }
}
