using ProjektGuitarWPF.Database;
using ProjektGuitarWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGuitarWPF.Services.Providers
{
    public class ProducerProvider : IProducerProvider
    {
        private readonly DbContextFactory contextFactory;

        public ProducerProvider(DbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }
        public void AddProducer(Producer producer)
        {
            using (DataContext context = contextFactory.CreateDbContext())
            {
                context.Producers.Add(producer);
                context.SaveChanges();
            }
        }

        public void DeleteProducer(Producer producer)
        {
            using (DataContext context = contextFactory.CreateDbContext())
            {
                context.Producers.Remove(producer);
                context.SaveChanges();
            }
        }

        public Producer GetProducer(int id)
        {
            using(DataContext context = contextFactory.CreateDbContext())
            {
                return context.Producers.FirstOrDefault(g => g.Id == id);
            }
        }

        public bool ProducerExists(string name)
        {
            using (DataContext context = contextFactory.CreateDbContext())
            {
                if (context.Producers.Any(g => g.Name == name))
                    return true;
                return false;
            }
        }
    }
}
