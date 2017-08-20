using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rapporti.Models.AssegnazioniViewModels
{
    public class IndexAssegnazioneViewModel
    {
        public int ID { get; set; }
        [EmailAddress]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Display(GroupName = "Gruppi")]
        public List<string> Gruppi { get; set; } = new List<string>();
    }
}
