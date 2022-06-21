using ProjektGuitarWPF.Database;
using ProjektGuitarWPF.Models;
using ProjektGuitarWPF.Models.Records;
using ProjektGuitarWPF.Services.Providers;
using ProjektGuitarWPF.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjektGuitarWPF.ViewModels
{
    /// <summary>
    /// ViewModel class for GuitarsListing View
    /// </summary>
    public class GuitarsListingViewModel : ViewModelBase
    {
        private IGuitarProvider provider;

        public ObservableCollection<GuitarRecord> guitarRecords { get; } = new ObservableCollection<GuitarRecord>();
        public GuitarRecord GuitarRecord { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand DeleteGuitarsCommand { get; set; }

        public GuitarsListingViewModel()
        {
            DeleteGuitarsCommand = new RelayCommand(DeleteGuitars);
            RefreshCommand = new RelayCommand(Refresh);
            this.provider = new GuitarProvider(new DbContextFactory());
            GetAll();
        }

        public void GetAll()
        {
            var guitars = provider.GetAllGuitars();
            foreach (var guitar in guitars)
            {
                guitarRecords.Add(new GuitarRecord()
                {
                    Id = guitar.Id,
                    Name = guitar.Name,
                    Created = guitar.ReleaseDate,
                    TypeId = guitar.Type.Name,
                    ProducerId = guitar.Producer.Name,
                    StringsId = guitar.Strings.Name
                });
            }
        }

        public void Refresh()
        {
            guitarRecords.Clear();
            GetAll();
        }

        public void DeleteGuitars()
        {
            var guitarsToDelete = guitarRecords.Where(x => x.Include).ToList();

            foreach(var guitar in guitarsToDelete)
            {
                provider.DeleteGuitar(new Guitar() { Id = guitar.Id});
            }
            Refresh();
        }
    }
}
