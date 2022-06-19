using ProjektGuitarWPF.Database;
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
    public class GuitaristsListingViewModel : ViewModelBase
    {
        private IGuitaristProvider provider;
        public ObservableCollection<GuitaristRecord> guitaristsRecords { get; } = new ObservableCollection<GuitaristRecord>();
        public GuitaristRecord GuitaristRecord { get; set; }
        public ICommand RefreshCommand { get; set; }

        public GuitaristsListingViewModel()
        {
            RefreshCommand = new RelayCommand(Refresh);
            this.provider = new GuitaristProvider(new DbContextFactory());
            GetAll();
        }

        public void GetAll()
        {
            var guitarists = provider.GetAllGuitarists();
            foreach (var guitarist in guitarists)
            {
                guitaristsRecords.Add(new GuitaristRecord()
                {
                    Id = guitarist.Id,
                    FullName = guitarist.FullName,
                    DateOfBirth = guitarist.DateOfBirth,
                    Guitar = guitarist.GuitaristsGuitars.Select(g => g.Guitar.Name).FirstOrDefault()
                });
            }
        }

        public void Refresh()
        {
            guitaristsRecords.Clear();
            GetAll();
        }
    }
}
