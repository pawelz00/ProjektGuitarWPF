using ProjektGuitarWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGuitarWPF.Services.Providers
{
    public interface IProducerProvider
    {
        Producer GetProducer(int id);
        void DeleteProducer(Producer producer);
        void AddProducer(Producer producer);
    }
}
