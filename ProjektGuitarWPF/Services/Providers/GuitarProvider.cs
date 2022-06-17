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
    public class GuitarProvider : IGuitarProvider
    {
        private readonly DbContextFactory contextFactory;

        public GuitarProvider(DbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public List<Guitar> GetAllGuitars()
        {
            using (DataContext context = contextFactory.CreateDbContext())
            {
                return context.Guitars.ToList();
            }
        }
    }
}
