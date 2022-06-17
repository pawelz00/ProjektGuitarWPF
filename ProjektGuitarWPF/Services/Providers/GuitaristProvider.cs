using Microsoft.EntityFrameworkCore.Internal;
using ProjektGuitarWPF.Database;
using ProjektGuitarWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGuitarWPF.Services.Providers
{
    public class GuitaristProvider : IGuitaristProvider
    {
        private readonly DbContextFactory contextFactory;

        public GuitaristProvider(DbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public List<Guitarist> GetAllGuitarists()
        {
            using (DataContext context = contextFactory.CreateDbContext())
            {
                return context.Guitarists.ToList();
            }
        }
    }
}
