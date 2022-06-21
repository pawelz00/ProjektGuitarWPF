using ProjektGuitarWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGuitarWPF.Services.Providers
{
    /// <summary>
    /// Interface for working with database entities (Guitars table)
    /// </summary>
    public interface IGuitarProvider
    {
        List<Guitar> GetAllGuitars();
        void CreateGuitar(Guitar guitar);
        void DeleteGuitar(Guitar guitar);
    }
}
