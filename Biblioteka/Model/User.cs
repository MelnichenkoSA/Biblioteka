using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    internal class User : INotifyPropertyChanged
    {
        public int id { get; set; }
        public string name { get; set; }
        public string family { get; set; }

        public List<Book> Books;

        public int Id
        {
            get { return id; }

            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Name
        {
            get { return name; }

            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Family
        {
            get { return family; }

            set
            {
                family = value;
                OnPropertyChanged("Family");
            }
        }
        public User(int id, string name, string family)
        {
            this.id = id;
            this.name = name;
            this.family = family;
            Books = new List<Book>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
