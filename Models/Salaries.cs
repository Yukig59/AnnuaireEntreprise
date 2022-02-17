#nullable disable
using Annuaire.Contexts;
using Annuaire.Methods;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annuaire.Models
{
    public class Salaries : Entity<Salaries>
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int TelFixe { get; set; }
        public int TelPortable { get; set; }
        public string Email { get; set; }
        public int ServicesId { get; set; }
        public int SiteId { get; set; }
        public virtual Services Services { get; set; }
        public virtual Sites Site { get; set; }
        private DatabaseContext context = new DatabaseContext();
        public bool Create()
        {
            context.Database.EnsureCreated();
            Salaries salaries = new Salaries();
            salaries.Nom = Nom;
            salaries.Prenom = Prenom;
            salaries.TelPortable = TelPortable;
            salaries.Email = Email; 
            salaries.TelFixe = TelFixe;
            salaries.ServicesId = Services.Id; 
            salaries.SiteId = Site.Id;
            try
            {
                context.Salarie.Add(salaries);
                var result = context.SaveChanges();
                if (result != 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }catch (Exception)
            {
                throw;
            }

        }

        public bool Delete()
        {
            context.Database.EnsureDeleted();
            try
            {
                var result = context.Salarie.Remove(this);

                if (result != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Salaries> GetAll()
        {
            context.Database.EnsureCreated();
            try
            {
                IEnumerable<Salaries> Salaries = context.Salarie.Include(o=> o.Services).Include(o=> o.Site).ToList();
                return Salaries;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Salaries GetById(int id)
        {
            context.Database.EnsureCreated();
            try
            {
                var salarie = context.Salarie.Find(id);
                return salarie;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Update()
        {
                context.Database.EnsureCreated();
                try
                {
                   var result =  context.Salarie.Update(this);
                var returnresult = (result != null) ? true : false;
                return returnresult;

            }
            catch (Exception)
                {
                    throw;
                }
            }
    }
}
