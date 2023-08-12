using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF.Models
{

    public interface IUtenteService
    {
        IList<Utente> Utenti { get; }
    }

    class UtenteService : IUtenteService
    {
        private List<Utente> _utenti = null;

        public UtenteService()
        {
            _utenti = new List<Utente>();
            _utenti.Add(new Utente() { TipoUtente = "Strutturato", RAL = "100" });
            _utenti.Add(new Utente() { TipoUtente = "Tempo determinato", RAL = "50" });
            _utenti.Add(new Utente() { TipoUtente = "Spazzacamino", RAL = "3" });
        }

        //public IList<Utente> Utenti => _utenti;
        //lambda form, iList è iteratore
        public IList<Utente> Utenti
        {
            get { return _utenti; }
        }
    }
}
