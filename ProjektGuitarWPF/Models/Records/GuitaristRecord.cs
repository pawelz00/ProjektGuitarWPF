using ProjektGuitarWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGuitarWPF.Models.Records
{
    public class GuitaristRecord : ViewModelBase
    {
        private bool include;
        public bool Include
        {
            get => include;
            set
            {
                include = value;
                OnPropertyChanged("Include");
            }
        }
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
        private string fullName;

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; OnPropertyChanged("FullName"); }
        }

        private DateTime dateOfBirth;

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; OnPropertyChanged("DateOfBirth"); }
        }

        private string guitar;

        public string Guitar
        {
            get { return guitar; }
            set { guitar = value; OnPropertyChanged("Guitar"); }
        }
    }
}
