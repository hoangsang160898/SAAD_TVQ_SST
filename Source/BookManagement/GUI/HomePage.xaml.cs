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
using BUS;
using DTO;

namespace GUI
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            var books = new List<SachDTO>();
            books.Add(new SachDTO(1, "Python Crash Course, 2nd Edition", "Eric Matthes", 59.5, 161.65, 10, 1, "05/2019", "05/26/2019", "products/1.jpg", "products/1_cover.jpg"));
            books.Add(new SachDTO(2, "Clean Code", "Robert C. Martin", 60, 67.7, 5, 1, "05/2019", "05/26/2019", "products/2.jpg", "products/2_cover.jpg"));
            books.Add(new SachDTO(3, "The Clean Coder", "Robert C. Martin", 55.1, 59.85, 5, 1, "05/2019", "05/26/2019", "products/3.jpg", "products/3_cover.jpg"));
            books.Add(new SachDTO(3, "Refactoring", "Martin Fowler", 55.1, 59.85, 5, 1, "05/2019", "05/26/2019", "products/4.jpg", "products/4_cover.jpg"));
            books.Add(new SachDTO(5, "Clean Architecture", "Robert C. Martin", 46, 54.11, 5, 1, "05/2019", "05/26/2019", "products/5.jpg", "products/5_cover.jpg"));
            books.Add(new SachDTO(6, "Building Microservices", "Sam Newman", 41.25, 48.69, 5, 1, "05/2019", "05/26/2019", "products/6.jpg", "products/6_cover.jpg"));
            books.Add(new SachDTO(7, "Patterns of Enterprise Application Architecture", "Martin Fowler", 65, 80.62, 5, 1, "05/2019", "05/26/2019", "products/7.jpg", "products/7_cover.jpg"));
            books.Add(new SachDTO(8, "Domain-Driven Design", "Gregor Hohpe", 70, 75.04, 5, 1, "05/2019", "05/26/2019", "products/8.jpg", "products/8_cover.jpg"));
            books.Add(new SachDTO(9, "Domain-Driven Design Reference", "Eric Evans", 21, 25.5, 5, 1, "05/2019", "05/26/2019", "products/9.jpg", "products/9_cover.jpg"));
            books.Add(new SachDTO(10, "Domain-Driven Design Distilled", "Vaughn Vernon", 47, 50.22, 5, 1, "05/2019", "05/26/2019", "products/10.jpg", "products/10_cover.jpg"));
            books.Add(new SachDTO(11, "Implementing Domain-Driven Design", "Vaughn Vernon", 71.2, 78.22, 5, 1, "05/2019", "05/26/2019", "products/11.jpg", "products/11_cover.jpg"));
            Global.Books = books;

            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            countProductBuy.Badge = 0;
            ListViewProductsLastest.ItemsSource = Global.Books;
            ListViewProductsMostBought.ItemsSource = Global.Books;
        }
        //private void ScrollViewerProductsMostBought_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        //{
        //    ScrollViewer scrollviewer = sender as ScrollViewer;
        //    if (e.Delta > 0)
        //        scrollviewer.LineLeft();
        //    else
        //        scrollviewer.LineRight();
        //    e.Handled = true;
        //}
        private void BtnBuyProductLastest_Click(object sender, RoutedEventArgs e)
        {
            SachDTO item = (SachDTO)((Button)sender).DataContext;
            MessageBox.Show(item.TenSach);
        }
        private void BtnBuyProductMostBought_Click(object sender, RoutedEventArgs e)
        {
            SachDTO item = (SachDTO)((Button)sender).DataContext;
            MessageBox.Show(item.TenSach);
        }
    }
}
