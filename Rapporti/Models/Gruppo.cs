using Rapporti.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rapporti.Models
{
    public class Gruppo
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual List<Assegnazione> Assegnazioni { get; set; }
        public virtual List<Rapporto> Rapporti { get; set; }
    }
}
