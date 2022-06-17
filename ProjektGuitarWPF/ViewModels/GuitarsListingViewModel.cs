using ProjektGuitarWPF.Database;
using ProjektGuitarWPF.Models;
using ProjektGuitarWPF.Models.Records;
using ProjektGuitarWPF.Services.Providers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjektGuitarWPF.ViewModels
{
    public class GuitarsListingViewModel : ViewModelBase
    {
        private IGuitarProvider provider;
        private ICommand _refreshData;
        public ObservableCollection<GuitarRecord> guitarRecords { get; } = new ObservableCollection<GuitarRecord>();
        public GuitarRecord GuitarRecord { get; set; }

        public GuitarsListingViewModel()
        {
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
                    TypeId = guitar.TypeId,
                    ProducerId = guitar.ProducerId,
                    StringsId = guitar.StringsId
                });
            }
            //.ForEach(data => GuitarRecord.GuitarRecords.Add(new GuitarRecord()
            //{
            //    Id = data.Id,
            //    Name = data.Name,
            //    Created = data.ReleaseDate,
            //    TypeId = data.TypeId,
            //    ProducerId = data.ProducerId,
            //    StringsId = data.StringsId
            //}));
        }
    }
}
