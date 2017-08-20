using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rapporti.Models
{
    public class Assegnazione
    {
        [Key]
        public int Id { get; set; }

        public Gruppo Gruppo { get; set; }
        public int GruppoId { get; set; }
        
        public Utente Utente { get; set; }
        public int UtenteId { get; set; }
    }
}
