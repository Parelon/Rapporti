using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rapporti.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    [Table("Utenti")]
    public class Utente : IdentityUser<int>
    {
        public string Nome { get; set; }

        public List<Assegnazione> Assegnazioni { get; set; }
        
        [ForeignKey("AutoreId")]
        public virtual List<Rapporto> RapportiScritti { get; set; }

        [ForeignKey("DestinatarioId")]
        public virtual List<Rapporto> RapportiRicevuti { get; set; }
    }
}
