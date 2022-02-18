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
    public class Services : Entity<Services>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public virtual ICollection<Salaries> Salaries { get; set; }
        private DatabaseContext context = new DatabaseContext();

        public bool Create()
        {
            context.Database.EnsureCreated();
            Services services = new Services();
            services.Name = Name;
            try
            {
                context.Service.Add(services);
                var result = context.SaveChanges();

                if (result != 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
       
        public bool Delete()
        {
            context.Database.EnsureCreated();
            try
            {
                context.Service.Remove(this);
                var result = context.SaveChanges();
                if (result == 1 )
                {
                    return true;
                }
                else { return false; }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Services> GetAll()
        {
            context.Database.EnsureCreated();
            try
            {
                IEnumerable<Services> Services = context.Service.AsNoTracking().ToList();

                return Services;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Services GetById(int id)
        {
            context.Database.EnsureCreated();
            try
            {
               var service =  context.Service.Find(id);
               return service;
              
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
                 context.Service.Update(this);
                var result = context.SaveChanges();
                var returnresult =   (result == 1) ?  true :  false;
                return returnresult;
            }catch (Exception)
            {
                throw;
            }
        }
    }
}
