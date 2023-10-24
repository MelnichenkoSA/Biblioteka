using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Biblioteka.Model;

namespace Biblioteka
{
    internal class ViewModell : INotifyPropertyChanged
    {
        private User selectedUsery;
        public ObservableCollection<User> users { get; set; }

        private Book selectedBooky;
        public ObservableCollection<Book> books { get; set; }

        public ObservableCollection<User> usersback { get; set; }

        public ObservableCollection<Book> booksback { get; set; }

        private string selectedName;
        private string selectedFamily;
        private string selectedTitle;
        private int selectedCount;
        private string selectedAuthor;
        private int selectedArc;
        private string selectedBookSearch;
        private string selectedUserSearch;

        private RelayCommand addUserCommand;
        private RelayCommand addBookCommand;
        private RelayCommand findBookCommand;
        private RelayCommand findUserCommand;
        private RelayCommand issueCommand;
        private RelayCommand checkedFilterCommand;
        private RelayCommand uncheckedFilterCommand;

        public ViewModell()
        {
            usersback= new ObservableCollection<User>();
            booksback= new ObservableCollection<Book>();
            users = usersback;
            books = booksback;
        }
        public RelayCommand AddUserCommand
        {
            get
            {
                return addUserCommand ??
                  (addUserCommand = new RelayCommand(obj =>
                  {
                      string name = SelectedName;
                      string family = SelectedFamily;

                      User newUser = new User(GetNextUserId(), name, family);

                      AddUser(newUser);

                  }));
            }
        }
        public RelayCommand AddBookCommand
        {
            get
            {
                return addBookCommand ??
                  (addBookCommand = new RelayCommand(obj =>
                  {
                      string author = SelectedAuthor;
                      string title = SelectedTitle;
                      int count = SelectedCount;
                      int Acr = SelectedArc;

                      Book newBook = new Book(title, author, count, Acr);

                      AddBook(newBook);

                  }));
            }
        }
        public RelayCommand FindBookCommand
        {
            get
            {
                return findBookCommand ??
                  (findBookCommand = new RelayCommand(obj =>
                  {
                      books.Clear();

                      string searchText = (SelectedBookSearch);

                      Book foundBook = FindBook(searchText);

                      if (foundBook != null)
                      {
                          books.Add(foundBook);
                      }
                      else
                      {
                          MessageBox.Show("Книга не найдена.");
                      }
                  }));
            }
        }
        public RelayCommand FindUserCommand
        {
            get
            {
                return findUserCommand ??
                  (findUserCommand = new RelayCommand(obj =>
                  {
                      users.Clear();

                      string searchText = (SelectedUserSearch);

                      User foundUser = FindUser(searchText);

                      if (foundUser != null)
                      {
                          users.Add(foundUser);
                      }
                      else
                      {
                          MessageBox.Show("Пользователь не найден.");
                      }
                  }));
            }
        }
        public RelayCommand IssueCommand
        {
            get
            {
                return issueCommand ??
                  (issueCommand = new RelayCommand(obj =>
                  {
                      User selectedUser = SelectedUsery as User;
                      Book selectedBook = SelectedBooky as Book;
                      if (selectedUser != null && selectedBook != null)
                      {
                          if (selectedBook.Count > 0)
                          {
                              IssueBook(selectedUser, selectedBook);
                          }
                          else
                          {
                              MessageBox.Show("Книги кончились");
                          }
                      }
                  }));
            }
        }
        public RelayCommand CheckedFilterCommand
        {
            get
            {
                return checkedFilterCommand ??
                  (checkedFilterCommand = new RelayCommand(obj =>
                  {
                      Filter();
                  }));
            }
        }

        public RelayCommand UnCheckedFilterCommand
        {
            get
            {
                return uncheckedFilterCommand ??
                  (uncheckedFilterCommand = new RelayCommand(obj =>
                  {
                      Refresher();
                  }));
            }
        }


        public User SelectedUsery
        {
            get { return selectedUsery; }
            set
            {
                selectedUsery = value;
                OnPropertyChanged("SelectedUsery");
            }
        }
        public Book SelectedBooky
        {
            get { return selectedBooky; }
            set
            {
                selectedBooky = value;
                OnPropertyChanged("SelectedBooky");
            }
        }
        public string SelectedName
        {
            get { return selectedName; }
            set
            {
                selectedName = value;
                OnPropertyChanged("SelectedName");
            }
        }
        public string SelectedFamily
        {
            get { return selectedFamily; }
            set
            {
                selectedFamily = value;
                OnPropertyChanged("SelectedFamily");
            }
        }
        public string SelectedTitle
        {
            get { return selectedTitle; }
            set
            {
                selectedTitle = value;
                OnPropertyChanged("SelectedTitle");
            }
        }
        public string SelectedAuthor
        {
            get { return selectedAuthor; }
            set
            {
                selectedAuthor = value;
                OnPropertyChanged("SelectedAuthor");
            }
        }
        public int SelectedCount
        {
            get { return selectedCount; }
            set
            {
                selectedCount = value;
                OnPropertyChanged("SelectedCount");
            }
        }
        public int SelectedArc
        {
            get { return selectedArc; }
            set
            {
                selectedArc = value;
                OnPropertyChanged("SelectedPhone");
            }
        }
        public string SelectedUserSearch
        {
            get { return selectedUserSearch; }
            set
            {
                selectedUserSearch = value;
                OnPropertyChanged("SelectedUsery");
            }
        }
        public string SelectedBookSearch
        {
            get { return selectedBookSearch; }
            set
            {
                selectedBookSearch = value;
                OnPropertyChanged("SelectedUsery");
            }
        }

        private int nextUserId = 1;
        private int GetNextUserId()
        {
            return nextUserId++;
        }
        private void Filter()
        {
            books.Clear();
            foreach (Book book in booksback)
            {
                if (book.vydana == true)
                    books.Add(book);
            }
        }
        private void Refresher()
        {
            books.Clear();
            foreach (Book book in booksback)
            {
                books.Add(book);
            }
        }

        /////////////////////////////////////////////////////////////////////

        public User FindUser(string userName)
        {
            return usersback.FirstOrDefault(user => user.Name.Equals(userName, StringComparison.OrdinalIgnoreCase));
        }

        public Book FindBook(string bookTitle)
        {
            return booksback.FirstOrDefault(book => book.Title.Equals(bookTitle, StringComparison.OrdinalIgnoreCase));
        }

        public void IssueBook(User user, Book book)
        {
            if (user != null && book != null && book.Count > 0 && book.IssuedTo == null)
            {
                user.Books.Add(book);
                book.IssuedTo = user;
                book.Count--;
                book.Vydana = true;
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
            usersback.Add(user);
        }

        public void AddBook(Book book)
        {
            booksback.Add(book);
        }

        /////////////////////////////////////////////////////////////////////

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}
