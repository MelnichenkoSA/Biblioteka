using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    internal class Book : INotifyPropertyChanged
    {
        public string title { get; set; } 
        public string author { get; set; } 
        public int acr { get; set; } 
        public int count { get; set; } 
        public DateTime age { get; set; }
        public User issuedTo { get; set; } 
        public bool vydana { get; set; }

        public string Title
        {
            get { return title; }

            set 
            { 
                title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Author
        {
            get { return author; }

            set
            {
                author = value;
                OnPropertyChanged("Author");
            }
        }
        public int Acr
        {
            get { return acr; }

            set
            {
                acr = value;
                OnPropertyChanged("Acr");
            }
        }
        public int Count
        {
            get { return count; }

            set
            {
                count = value;
                OnPropertyChanged("Count");
            }
        }
        public DateTime Age
        {
            get { return age; }

            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }
        public User IssuedTo
        {
            get { return issuedTo; }

            set
            {
                issuedTo = value;
                OnPropertyChanged("IssuedTo");
            }
        }
        public bool Vydana
        {
            get { return vydana; }

            set
            {
                vydana = value;
                OnPropertyChanged("Vydana");
            }
        }

        //The message is not supported on this version of Telegram.
        public Book(string title, string author, int count, int acr)
        {
            title = title;
            author = author;
            count = count;
            acr = acr;
            vydana= false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
