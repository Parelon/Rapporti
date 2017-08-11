using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapporti.Models.CompitiViewModels
{
    public class GruppiUtenti
    {
        public ICollection<Rapporti.Models.Gruppo> gruppi { get; set; }
        public ICollection<Rapporti.Models.User> utenti { get; set; }
    }
}
