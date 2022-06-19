using ProjektGuitarWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGuitarWPF.Models.Records
{
    public class GuitarRecord : ViewModelBase
    {
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        private DateTime created;

        public DateTime Created
        {
            get { return created; }
            set { created = value; OnPropertyChanged("Created"); }
        }

        private string typeId;

        public string TypeId
        {
            get { return typeId; }
            set { typeId = value; OnPropertyChanged("TypeId"); }
        }
        private string stringsId;

        public string StringsId
        {
            get { return stringsId; }
            set { stringsId = value; OnPropertyChanged("StringsId"); }
        }

        private string producerId;

        public string ProducerId
        {
            get { return producerId; }
            set { producerId = value; OnPropertyChanged("ProducerId"); }
        }

        private ObservableCollection<GuitarRecord> _guitarRecords;
        public ObservableCollection<GuitarRecord> GuitarRecords
        {
            get
            {
                return _guitarRecords;
            }
            set
            {
                _guitarRecords = value;
                OnPropertyChanged("GuitarRecords");
            }
        }
    }
}
