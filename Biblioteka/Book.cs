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
        public string Title { get; set; } // Название книги
        public string Author { get; set; } // Автор книги
        public short Acr { get; set; } // Год выпуска книги
        public int Count { get; set; } // Количество экземпляров книги
        public DateTime Age { get; set; }
        public User IssuedTo { get; set; } // Пользователь, котором

        public Book(string title, string author, DateTime age, int count)
        {
            Title = title;
            Author = author;
            Age = age;
            Count = count;
        }
    }
}
