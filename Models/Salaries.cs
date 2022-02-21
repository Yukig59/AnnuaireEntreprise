#nullable disable
using Annuaire.Contexts;
using Annuaire.Methods;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            context.Entry(this).State = EntityState.Modified;

            try
            {
                context.Salarie.Add(this);
                var result = context.SaveChanges();
                if (result == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        public bool Delete()
        {
            context.Database.EnsureDeleted();
            try
            {
                 context.Salarie.Remove(this);
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
                context.Entry(this).State = EntityState.Modified;
                context.Salarie.Update(this);
                var result = context.SaveChanges();
                if (result == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }catch (Exception)
            {
                throw;
            }
        }
    }
}
