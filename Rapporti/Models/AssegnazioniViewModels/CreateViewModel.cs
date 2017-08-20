using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapporti.Models.AssegnazioniViewModels
{
    public class CreateViewModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public bool Selezionato { get; set; }
    }
}
