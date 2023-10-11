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
        public int Acr { get; set; } // Год выпуска книги
        public int Count { get; set; } // Количество экземпляров книги
        public DateTime Age { get; set; }
        public User IssuedTo { get; set; } // Пользователь, котором
        public bool vydana { get; set; }

        public Book(string title, string author, int count, int acr)
        {
            Title = title;
            Author = author;
            Count = count;
            Acr = acr;
            vydana= false;
        }
    }
}
