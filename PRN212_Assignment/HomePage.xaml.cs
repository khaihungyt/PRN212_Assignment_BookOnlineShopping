using PRN212_Assignment.Models;
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
using System.Windows.Shapes;

namespace PRN212_Assignment
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        public HomePage()
        {
            InitializeComponent();
            using (Prn212AssignmentBookShoppingContext context = new Prn212AssignmentBookShoppingContext())
            {
                lvBookList.ItemsSource = context.Books.Select(e =>new{
                    BookName= e.BookName,
                    AuthorName= e.Author.AuthorName.ToString(),
                    GenreName=e.Genre.GenreName,
                    Quantity = e.Quantity,
                    Price=e.PriceOutput
                }).ToList();
            }
        }


        private void lvBookList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BookDetail bookDetail= new BookDetail();
            bookDetail.Show();
            this.Close();
        }
    }
}
