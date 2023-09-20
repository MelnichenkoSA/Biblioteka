using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    internal class Book
    {
        public string Author;
        public short Acr;
        public List<DateTime> Data;
        public int Count;

        public Book(string Author, short Acr, int Count) 
        {
            this.Author = Author;
            this.Acr = Acr;
            this.Count = Count;
        }
    }
}
