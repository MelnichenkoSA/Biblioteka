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

namespace Biblioteka
{
    internal class ViewModel : INotifyPropertyChanged
    {

        public LibraryManager libraryManager;

        private User selectedUsery;
        public ObservableCollection<User> users;

        private Book selectedBooky;
        public ObservableCollection<Book> books;

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
        public ViewModel()
        {
            LibraryManager libraryManager = new LibraryManager();
            Users = libraryManager.Users;
            Books = libraryManager.Books;
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

                      libraryManager.AddUser(newUser);

                      RefreshUserListView();
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

                      libraryManager.AddBook(newBook);

                      RefreshBookListView();
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
                      Books.Clear();

                      string searchText = (SelectedBookSearch);

                      Book foundBook = libraryManager.FindBook(searchText);

                      if (foundBook != null)
                      {
                          Books.Add(foundBook);
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
                      Users.Clear();

                      string searchText = (SelectedUserSearch);

                      User foundUser = libraryManager.FindUser(searchText);

                      if (foundUser != null)
                      {
                          Users.Add(foundUser);
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
                      User selectedUser = Users.SelectedItem as User;
                      Book selectedBook = Books.SelectedItem as Book;
                      if (selectedUser != null && selectedBook != null)
                      {
                          if (selectedBook.Count > 0)
                          {
                              libraryManager.IssueBook(selectedUser, selectedBook);
                              RefreshBookListView();
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
        public RelayCommand UncheckedFiterCommand
        {
            get
            {
                return uncheckedFilterCommand ??
                  (uncheckedFilterCommand = new RelayCommand(obj =>
                  {
                      RefreshBookListView();
                  }));
            }
        }



        public ObservableCollection<User> Users
        {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged("Users");
            }
        }
        public ObservableCollection<Book> Books
        {
            get { return books; }
            set
            {
                books = value;
                OnPropertyChanged("Books");
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
        private void RefreshUserListView()
        {
            Users.Clear();

            foreach (User user in libraryManager.Users)
            {
                Users.Add(user);
            }

        }
        private void RefreshBookListView()
        {
            Books.Clear();

            foreach (Book book in libraryManager.Books)
            {
                Books.Add(book);
            }
        }
        private void Filter()
        {
            Books.Clear();
            foreach (Book book in libraryManager.Books)
            {
                if (book.vydana == true)
                    Books.Add(book);
            }
        }








        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}
