using Annuaire.Contexts;
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
        public int Id { get; set; }
        public string Ville { get; set; }
        private DatabaseContext context = new DatabaseContext();
        public virtual ICollection<Salaries>? Salaries { get; set; }

        public bool Create()
        {
            context.Database.EnsureCreated();
            Sites site = new();
            site.Ville = Ville;
            try
            {
                context.Add(site);
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
            context.Database.EnsureCreated();
            try
            {
                context.Site.Remove(this);
                var result = context.SaveChanges();
                if (result == 1)
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

        public IEnumerable<Sites> GetAll()
        {
            context.Database.EnsureCreated();
                try
                {
                    IEnumerable<Sites> Sites = context.Site.ToList();
                    return Sites;
                }
                catch (Exception) 
                { 
                    throw;
                }
        }

        public Sites GetById(int id)
        {
            context.Database.EnsureCreated();
            try
            {
                var site = context.Site.Find(id);
                return site;
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
                context.Site.Update(this);
                var result =  context.SaveChanges();
                var returnresult = (result == 1) ? true : false;
                return returnresult;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
