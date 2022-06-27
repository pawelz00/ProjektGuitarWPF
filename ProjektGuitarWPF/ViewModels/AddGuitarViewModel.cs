using ProjektGuitarWPF.Database;
using ProjektGuitarWPF.Models;
using ProjektGuitarWPF.Services.Providers;
using ProjektGuitarWPF.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjektGuitarWPF.ViewModels
{
    /// <summary>
    /// ViewModel class for AddGuitar View
    /// </summary>
    public class AddGuitarViewModel : ViewModelBase
    {
        public IGuitarProvider provider;
        public ICommand AddGuitarCommand { get; set; }
        public ICommand UpdateGuitarCommand { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public int ProducerId { get; set; }
        public int TypeId { get; set; }
        public int StringsId { get; set; }

        public AddGuitarViewModel()
        {
            UpdateGuitarCommand = new RelayCommand(UpdateGuitar);
            AddGuitarCommand = new RelayCommand(AddGuitar);
            provider = new GuitarProvider(new DbContextFactory());
        }

        private void UpdateGuitar()
        {
            if (Name == String.Empty || Name == null || ProducerId == 0 || StringsId == 0 || TypeId == 0 || StringsId > 4 || StringsId < 0 || TypeId > 5 || TypeId < 0)
            {
                return;
            }

            else
            {
                provider.UpdateGuitar(new Guitar()
                {
                    Name = this.Name,
                    ReleaseDate = this.Created,
                    ProducerId = this.ProducerId,
                    StringsId = this.StringsId,
                    TypeId = this.TypeId,
                });

                Name = "Pomyślny update!";
            }
            OnPropertyChanged(nameof(Name));
        }

        public void AddGuitar()
        {
            bool nameExists = provider.GuitarExists(Name);

            if (nameExists || Name == String.Empty || Name == null || ProducerId == 0 || StringsId == 0 || TypeId == 0 || StringsId > 4 || StringsId < 0 || TypeId > 5 || TypeId < 0)
            {
                return;
            }

            else
            {
                provider.CreateGuitar(new Guitar()
                {
                    Name = this.Name,
                    ReleaseDate = this.Created,
                    ProducerId = this.ProducerId,
                    StringsId = this.StringsId,
                    TypeId = this.TypeId,
                });

                Name = "Pomyślnie dodano!";
            }
            OnPropertyChanged(nameof(Name));
        }
    }
}
