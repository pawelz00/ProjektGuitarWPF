using ProjektGuitarWPF.Database;
using ProjektGuitarWPF.Models;
using ProjektGuitarWPF.Services.Providers;
using ProjektGuitarWPF.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjektGuitarWPF.ViewModels
{
    public class AddGuitarViewModel
    {
        public IGuitarProvider provider;
        public ICommand AddGuitarCommand { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public int ProducerId { get; set; }
        public int TypeId { get; set; }
        public int StringsId { get; set; }

        public AddGuitarViewModel()
        {
            AddGuitarCommand = new RelayCommand(AddGuitar);
            provider = new GuitarProvider(new DbContextFactory());
        }

        public void AddGuitar()
        {
            provider.CreateGuitar(new Guitar()
            {
                Name = this.Name,
                ReleaseDate = this.Created,
                ProducerId = this.ProducerId,
                StringsId = this.StringsId,
                TypeId = this.TypeId,
            });
        }
    }
}
