using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBase.Models
{
    internal class Persona
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataDiNascita { get; set; }

        public GenereEnum Genere { get; set; }

        public string Email { get; set; }


        public override string ToString() => $"{Nome} {Cognome}";
    }
    
    public enum GenereEnum
    {
        Maschio,
        Femmina,
        Altro
    }


}
