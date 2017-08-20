using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rapporti.Models
{
    [Table("Rapporti")]
    public class Rapporto
    {
        [Key]
        public int Id { get; set; }

        public string Testo { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Inserito il")]
        public DateTime Data { get; set; }
        
        [Display(Name = "Autore")]
        public Utente AutoreUtente { get; set; }
        public int AutoreUtenteId { get; set; }
        
        [Display(Name = "Gruppo")]
        public virtual Gruppo Gruppo { get; set; }
        public int GruppoId { get; set; }

        [Display(Name = "Destinatario")]
        public virtual Utente DestinatarioUtente { get; set; }
        public int? DestinatarioUtenteId { get; set; }
    }
}
