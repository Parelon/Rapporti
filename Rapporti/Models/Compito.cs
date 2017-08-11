using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapporti.Models
{
    public class Compito
    {
        public int Id { get; set; }
        public string UtenteId { get; set; }
        public string GruppoId { get; set; }
    }
}
