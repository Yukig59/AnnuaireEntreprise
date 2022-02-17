using Annuaire.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annuaire.Models
{
    public class Services : Entity<Services>
    {
        public string Name { get; set; }
        public virtual ICollection<Salaries>? Salaries { get; set; }
    }
}
