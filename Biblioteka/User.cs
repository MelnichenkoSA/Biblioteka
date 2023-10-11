using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }

        public List<Book> Books;

        public User(int id, string name, string family)
        {
            Id = id;
            Name = name;
            Family = family;
            Books= new List<Book>();
        }
    }
}
