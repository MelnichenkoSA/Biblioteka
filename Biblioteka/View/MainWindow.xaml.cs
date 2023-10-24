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
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ViewModell();
        }
        /*


        private void ReturnBookButton_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = userki.SelectedItem as User;
            Book returnedBook = Booki.SelectedItem as Book;
            if (selectedUser != null && returnedBook != null)
            {
                libraryManager.ReturnBook(selectedUser, returnedBook);
            }
        }*/
    }
}
