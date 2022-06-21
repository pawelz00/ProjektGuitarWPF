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
    }
}
