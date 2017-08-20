using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rapporti.Models.ManageViewModels
{
    public class ChangeNomeViewModel
    {
        public string OldName { get; set; }

        public string NewName { get; set; }
    }
}
