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
    /// <summary>
    /// ViewModel class for AddGuitarist View
    /// </summary>
    public class AddGuitaristViewModel : ViewModelBase
    {
        public IGuitaristProvider guitaristprovider;
        public IGuitarProvider guitarprovider;
        public ICommand AddGuitaristCommand { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int GuitarId { get; set; }

        public AddGuitaristViewModel()
        {
            AddGuitaristCommand = new RelayCommand(AddGuitarist);
            guitaristprovider = new GuitaristProvider(new DbContextFactory());
            guitarprovider = new GuitarProvider(new DbContextFactory());
        }

        public void AddGuitarist()
        {
            bool guitarExists = guitarprovider.GuitarExists(GuitarId);

            if (Name == null || Name == String.Empty || GuitarId < 0 || !guitarExists)
                return;

            guitaristprovider.CreateGuitarist(GuitarId, new Guitarist()
            {
                FullName = Name,
                DateOfBirth = this.DateOfBirth
            });
            Name = "Pomyślnie dodano!";
            OnPropertyChanged(nameof(Name));
        }
    }
}
