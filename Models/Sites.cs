using Annuaire.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annuaire.Models
{
    public class Sites : Entity<Sites>
    {
        public string Ville { get; set; }   

        public virtual ICollection<Salaries>? Salaries { get; set; }

    }
}
