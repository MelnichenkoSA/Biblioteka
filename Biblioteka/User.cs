using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    internal class User
    {
        public int Id;
        public string Name;
        public string Family;
        public List<Book> Books;

        public User(string Name, string Family)
        {
            this.Name = Name;
            this.Family = Family;
            Id = 1;
        }

        public void OtDie (Book book)
        {
            
        }
    }
}
