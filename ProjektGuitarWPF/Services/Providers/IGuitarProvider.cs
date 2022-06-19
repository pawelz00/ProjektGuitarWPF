using ProjektGuitarWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGuitarWPF.Services.Providers
{
    public interface IGuitarProvider
    {
        List<Guitar> GetAllGuitars();
        void CreateGuitar(Guitar guitar);
    }
}
