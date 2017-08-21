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
        [InverseProperty("RapportiScritti")]
        public Utente Autore { get; set; }
        public int AutoreId { get; set; }
        
        [Display(Name = "Gruppo")]
        public Gruppo Gruppo { get; set; }
        public int GruppoId { get; set; }

        [Display(Name = "Destinatario")]
        [InverseProperty("RapportiRicevuti")]
        public Utente Destinatario { get; set; }
        public int? DestinatarioId { get; set; }
    }
}
