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
        public string[,] Data;
        public int Count;
        public int Counter;

        public Book(string Author, short Acr, int Count) 
        {
            this.Author = Author;
            this.Acr = Acr;
            this.Count = Count;
            Data = new string[1,Count];
            Counter = 0;
        }

        public void Die(User user)
        {
            Data[1, Counter] = Convert.ToString(user.Id);
            Counter += 1;
        }
    }
}
