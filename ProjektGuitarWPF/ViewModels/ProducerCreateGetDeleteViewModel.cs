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
    public class ProducerCreateGetDeleteViewModel : ViewModelBase
    {
        public IProducerProvider provider;
        public string ProducerName { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public ICommand DeleteProducerCommand { get; set; }
        public ICommand AddProducerCommand { get; set; }
        public ICommand GetProducerCommand { get; set; }
        public ProducerCreateGetDeleteViewModel()
        {
            GetProducerCommand = new RelayCommand(GetProducer);
            AddProducerCommand = new RelayCommand(CreateProducer);
            DeleteProducerCommand = new RelayCommand(DeleteProducer);
            provider = new ProducerProvider(new DbContextFactory());
        }

        public void CreateProducer()
        {
            if (provider.ProducerExists(Name))
            {
                ProducerName = "Producent istnieje";
            }
            else if (Name == null || !IsAllLetters(Name))
            {
                ProducerName = "Błędne dane";
            }
            else 
            {
                provider.AddProducer(new Producer()
                {
                    Name = this.Name
                });
                Name = String.Empty;
                ProducerName = "Pomyślnie dodano";
            }
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(ProducerName));
        }
        public void DeleteProducer()
        {
            var producer = provider.GetProducer(Id);
            if (producer != null)
            {
                provider.DeleteProducer(producer);
                ProducerName = "Usunięto!";
            }

            else
                ProducerName = "Podaj właściwe ID";

            OnPropertyChanged("ProducerName");
        }
        public void GetProducer()
        {
            var producer = provider.GetProducer(this.Id);

            if(producer == null)
                ProducerName = "Nie znaleziono";
            else
                ProducerName = producer.Name;

            OnPropertyChanged("ProducerName");
        }

        public static bool IsAllLetters(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }
    }
}
