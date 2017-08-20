using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rapporti.Models
{
    [Table("Ruoli")]
    public class Ruolo : IdentityRole<int>
    {
    }
}
