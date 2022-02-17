#nullable disable
using Annuaire.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annuaire.Models
{
    public class Salaries : Entity<Salaries>
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int TelFixe { get; set; }
        public int TelPortable { get; set; }
        public string Email { get; set; }
        public virtual Services Services { get; set; }
        public virtual Sites Site { get; set; }
    }
}
