using Microsoft.EntityFrameworkCore;
using ProjektGuitarWPF.Database;
using ProjektGuitarWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGuitarWPF.Services.Providers
{
    /// <summary>
    /// Class for interacting with Guitars table in database (CRUD Operations)
    /// </summary>
    public class GuitarProvider : IGuitarProvider
    {
        private readonly DbContextFactory contextFactory;

        public GuitarProvider(DbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }
        public void CreateGuitar(Guitar guitar)
        {
            using (DataContext context = contextFactory.CreateDbContext())
            {
                context.Guitars.Add(guitar);
                context.SaveChanges();
            }
        }

        public List<Guitar> GetAllGuitars()
        {
            using (DataContext context = contextFactory.CreateDbContext())
            {
                return context.Guitars.Include(p => p.Producer).Include(s => s.Strings).Include(gt => gt.Type).ToList();
            }
        }

        public void DeleteGuitar(Guitar guitar)
        {
            using (DataContext context = contextFactory.CreateDbContext())
            {
                context.Guitars.Remove(guitar);
                context.SaveChanges();
            }
        }

        public bool GuitarExists(int Id)
        {
            using (DataContext context = contextFactory.CreateDbContext())
            {
                if (context.Guitars.Any(g => g.Id == Id))
                    return true;
                return false;
            }
        }

        public bool GuitarExists(string name)
        {
            using (DataContext context = contextFactory.CreateDbContext())
            {
                if (context.Guitars.Any(g => g.Name == name))
                    return true;
                return false;
            }
        }

        public void UpdateGuitar(Guitar guitar)
        {
            using (DataContext context = contextFactory.CreateDbContext())
            {
                var result = context.Guitars.SingleOrDefault(g => g.Name == guitar.Name);
                if (result != null)
                {
                    result.Name = guitar.Name;
                    result.ReleaseDate = guitar.ReleaseDate;
                    result.ProducerId = guitar.ProducerId;
                    result.StringsId = guitar.StringsId;
                    result.TypeId = guitar.TypeId;
                    context.SaveChanges();
                }
            }
        }
    }
}
