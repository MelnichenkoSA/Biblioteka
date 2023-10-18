using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    internal class LibraryManager
    {
        private ObservableCollection<User> users = new ObservableCollection<User>();
        private ObservableCollection<Book> books = new ObservableCollection<Book>();

        public ObservableCollection<User> Users
        {
            get { return users; }
        }

        public ObservableCollection<Book> Books
        {
            get { return books; }
        }

        public User FindUser(string userName)
        {
            return users.FirstOrDefault(user => user.Name.Equals(userName, StringComparison.OrdinalIgnoreCase));
        }

        public Book FindBook(string bookTitle)
        {
            return books.FirstOrDefault(book => book.Title.Equals(bookTitle, StringComparison.OrdinalIgnoreCase));
        }

        public void IssueBook(User user, Book book)
        {
            if (user != null && book != null && book.Count > 0 && book.IssuedTo == null)
            {
                user.Books.Add(book);
                book.IssuedTo = user;
                book.Count--;
                book.vydana= true;
            }
        }

        public void ReturnBook(User user, Book book)
        {
            if (user != null && book != null && user.Books.Contains(book))
            {
                user.Books.Remove(book);
                book.IssuedTo = null;
                book.Count++;
            }
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }
    }
}
