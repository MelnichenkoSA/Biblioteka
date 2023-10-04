using System;
using System.Collections.Generic;
using System.Linq;
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
        public MainWindow()
        {
            InitializeComponent();

            User newUser = new User(1, "Имя", "Фамилия");
            libraryManager.AddUser(newUser);

            Book newBook = new Book("Название книги", "Автор книги", new DateTime(2023, 1, 1), 5);
            libraryManager.AddBook(newBook);
        }

        private LibraryManager libraryManager = new LibraryManager();

        private void FindUserButton_Click(object sender, RoutedEventArgs e)
        {
            int userId = int.Parse(userIdTextBox.Text);
            User foundUser = libraryManager.FindUser(userId);
        }

        private void IssueBookButton_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = userki.SelectedItem as User;
            Book selectedBook = Booki.SelectedItem as Book;
            if (selectedUser != null && selectedBook != null)
            {
                libraryManager.IssueBook(selectedUser, selectedBook);
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
    }
}
