using ProjektGuitarWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGuitarWPF.Services.Providers
{
    /// <summary>
    /// Interface for working with database entities (Guitarists table)
    /// </summary>
    public interface IGuitaristProvider
    {
        List<Guitarist> GetAllGuitarists();
        void CreateGuitarist(int guitarId, Guitarist guitarist);
        void DeleteGuitarist(Guitarist guitarist);
    }
}
