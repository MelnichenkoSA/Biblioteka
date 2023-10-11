using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Biblioteka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<User> users;
        List<Book> books;
        LibraryManager libraryManager = new LibraryManager();
        public MainWindow()
        {
            InitializeComponent();
            users = libraryManager.Users;
            books = libraryManager.Books;

        }



        private void FindBookButton_Click(object sender, RoutedEventArgs e)
        {
            Booki.Items.Clear();

            string searchText = (bookTitleTextBox.Text);

            Book foundBook = libraryManager.FindBook(searchText);

            if (foundBook != null)
            {
                Booki.Items.Add(foundBook);
            }
            else
            {
                MessageBox.Show("Книга не найдена.");
            }
        }

        private void FindUserButton_Click(object sender, RoutedEventArgs e)
        {
            userki.Items.Clear();

            string searchText = (userIdTextBox.Text);

            User foundUser = libraryManager.FindUser(searchText);

            if (foundUser != null)
            {
                userki.Items.Add(foundUser);
            }
            else
            {
                MessageBox.Show("Пользователь не найден.");
            }
        }

        private void IssueBookButton_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = userki.SelectedItem as User;
            Book selectedBook = Booki.SelectedItem as Book;
            if (selectedUser != null && selectedBook != null)
            {
                if (selectedBook.Count > 0 ) 
                {
                    libraryManager.IssueBook(selectedUser, selectedBook);
                    RefreshBookListView();
                }
                else
                {
                    MessageBox.Show("Книги кончились");
                }
            }
        }

        private void ReturnBookButton_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = userki.SelectedItem as User;
            Book returnedBook = Booki.SelectedItem as Book;
            if (selectedUser != null && returnedBook != null)
            {
                libraryManager.ReturnBook(selectedUser, returnedBook);
            }
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTextBox.Text;
            string family = familyTextBox.Text;

            User newUser = new User(GetNextUserId(), name, family);

            libraryManager.AddUser(newUser);

            RefreshUserListView();
        }

        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            string author = authorTextBox.Text;
            string title = titleTextBox.Text;
            int count = int.Parse(countTextBox.Text);
            int Acr = int.Parse(arcTextBox.Text);

            Book newBook = new Book(title, author, count, Acr);

            libraryManager.AddBook(newBook);

            RefreshBookListView();

        }



        private void RefreshUserListView()
        {
            userki.Items.Clear();

            foreach (User user in libraryManager.Users)
            {
                userki.Items.Add(user);
            }

        }

        private void RefreshBookListView()
        {
            Booki.Items.Clear(); 

            foreach (Book book in libraryManager.Books)
            {
                Booki.Items.Add(book);
            }
        }

        private int nextUserId = 1; 

        private int GetNextUserId()
        {
            return nextUserId++;
        }

        private void Filter()
        {
            Booki.Items.Clear();
            foreach (Book book in libraryManager.Books)
            {
                if (book.vydana == true)
                    Booki.Items.Add(book);
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            RefreshBookListView();
        }
    }
}
