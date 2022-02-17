using Annuaire.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annuaire.Methods
{
    public interface Entity<T>
    {
        public int Id { get; set; }
        public bool Create();
        public bool Update();
        public bool Delete();
        public T GetById(int id);
        public IEnumerable<T> GetAll();

    }
}
