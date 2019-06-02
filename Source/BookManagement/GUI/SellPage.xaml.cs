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
using DTO;
using BUS;
using System.Text.RegularExpressions;

namespace GUI
{
    /// <summary>
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SellPage : Page
    {
        public SellPage()
        {

            // test books
            var books = new List<SachDTO>();
            books.Add(new SachDTO(1, "Python Crash Course, 2nd Edition", "Eric Matthes", 59.5, 161.65, 10, 1, "05/2019", "05/26/2019", "products/1.jpg", "products/1_cover.jpg"));
            books.Add(new SachDTO(2, "Patterns of Enterprise Application Architecture", "Martin Fowler", 65, 80.62, 5, 1, "05/2019", "05/26/2019", "products/7.jpg", "products/7_cover.jpg"));
            books.Add(new SachDTO(3, "The Clean Coder", "Robert C. Martin", 55.1, 59.85, 5, 1, "05/2019", "05/26/2019", "products/3.jpg", "products/3_cover.jpg"));
            books.Add(new SachDTO(4, "Refactoring", "Martin Fowler", 55.1, 59.85, 5, 1, "05/2019", "05/26/2019", "products/4.jpg", "products/4_cover.jpg"));
            books.Add(new SachDTO(5, "Clean Architecture", "Robert C. Martin", 46, 54.11, 5, 1, "05/2019", "05/26/2019", "products/5.jpg", "products/5_cover.jpg"));
            books.Add(new SachDTO(6, "Building Microservices", "Sam Newman", 41.25, 48.69, 5, 1, "05/2019", "05/26/2019", "products/6.jpg", "products/6_cover.jpg"));
            books.Add(new SachDTO(7, "Clean Code", "Robert C. Martin", 60, 67.7, 5, 1, "05/2019", "05/26/2019", "products/2.jpg", "products/2_cover.jpg"));
            books.Add(new SachDTO(8, "Domain-Driven Design", "Gregor Hohpe", 70, 75.04, 5, 1, "05/2019", "05/26/2019", "products/8.jpg", "products/8_cover.jpg"));
            books.Add(new SachDTO(9, "Domain-Driven Design Reference", "Eric Evans", 21, 25.5, 5, 1, "05/2019", "05/26/2019", "products/9.jpg", "products/9_cover.jpg"));
            books.Add(new SachDTO(10, "Domain-Driven Design Distilled", "Vaughn Vernon", 47, 50.22, 5, 1, "05/2019", "05/26/2019", "products/10.jpg", "products/10_cover.jpg"));
            books.Add(new SachDTO(11, "Implementing Domain-Driven Design", "Vaughn Vernon", 71.2, 78.22, 5, 1, "05/2019", "05/26/2019", "products/11.jpg", "products/11_cover.jpg"));

            // test categories
            var types = new List<TheLoaiDTO>();
            types.Add(new TheLoaiDTO(0, "All types"));
            types.Add(new TheLoaiDTO(1, "Information Technology"));
            types.Add(new TheLoaiDTO(2, "Math"));
            types.Add(new TheLoaiDTO(3, "English"));
            types.Add(new TheLoaiDTO(4, "Biology"));
            Global.Categories = types;

            //test bill
            var booksBoughtBill = new List<ChiTietHoaDonBanSachDTO>();
            booksBoughtBill.Add(new ChiTietHoaDonBanSachDTO(1, 1, "Python Crash Course, 2nd Edition", "Eric Matthes", 3, 161.65, "products/1.jpg"));
            booksBoughtBill.Add(new ChiTietHoaDonBanSachDTO(2, 2, "Patterns of Enterprise Application Architecture", "Martin Fowler", 1, 80.62, "products/7.jpg"));
            booksBoughtBill.Add(new ChiTietHoaDonBanSachDTO(3, 3, "The Clean Coder", "Robert C. Martin", 2, 59.85, "products/3.jpg"));
            booksBoughtBill.Add(new ChiTietHoaDonBanSachDTO(4, 4, "Refactoring", "Martin Fowler", 4, 59.85, "products/4.jpg"));
            booksBoughtBill.Add(new ChiTietHoaDonBanSachDTO(5, 5, "Clean Architecture", "Robert C. Martin", 6, 54.11, "products/5.jpg"));
            booksBoughtBill.Add(new ChiTietHoaDonBanSachDTO(6, 6, "Building Microservices", "Sam Newman", 7, 48.69, "products/6.jpg"));
            Global.BookBoughtBills = booksBoughtBill;

            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (Global.BookBoughtBills == null)
            {
                countProductBuy.Badge = 0;
            }
            else
            {
                int countBooksBought = 0;
                for (int i = 0; i < Global.BookBoughtBills.Count; i++)
                {
                    countBooksBought += Global.BookBoughtBills[i].SoLuong;
                }
                countProductBuy.Badge = countBooksBought;
            }
            ListViewProducts.ItemsSource = Global.Books;
            Combobox_CategoriesBook.ItemsSource = Global.Categories;
        }

        private void BtnBuyProduct_Click(object sender, RoutedEventArgs e)
        {
            SachDTO item = (SachDTO)((Button)sender).DataContext;
            MessageBox.Show(item.TenSach);
            int countBooksBought = 0;
            for (int i = 0; i < Global.BookBoughtBills.Count; i++)
            {
                countBooksBought += Global.BookBoughtBills[i].SoLuong;
            }
            countProductBuy.Badge = countBooksBought;
        }

        private void ScrollViewerProducts_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void Loaded_CategoriesBook(object sender, RoutedEventArgs e)
        {
            Combobox_CategoriesBook.SelectedIndex = 0;
        }

        private void BtnShoppingCart_Click(object sender, RoutedEventArgs e)
        {
            if (Global.BookBoughtBills != null)
            {
                double sumPrice = 0;
                for (int i = 0; i < Global.BookBoughtBills.Count; i++)
                {
                    sumPrice += Global.BookBoughtBills[i].SoLuong * Global.BookBoughtBills[i].DonGiaBan;
                }
                ListViewProductsBought.ItemsSource = Global.BookBoughtBills;
                Label_SummaryPriceOfBill.Content = sumPrice;
                ShoppingCart_Empty.Visibility = Visibility.Collapsed;
                ShoppingCart_NoEmprty.Visibility = Visibility.Visible;
            }
            else
            {
                ShoppingCart_Empty.Visibility = Visibility.Visible;
                ShoppingCart_NoEmprty.Visibility = Visibility.Collapsed;
            }
            ProductsBought.Visibility = Visibility.Visible;
        }

        private void Btn_DeleteAll_Click(object sender, RoutedEventArgs e)
        {
            Global.BookBoughtBills.Clear();
            ListViewProductsBought.ItemsSource = Global.BookBoughtBills;
            Label_SummaryPriceOfBill.Content = "";
            countProductBuy.Badge = 0;
            ShoppingCart_Empty.Visibility = Visibility.Visible;
            ShoppingCart_NoEmprty.Visibility = Visibility.Collapsed;
        }

        private void Btn_BuyMore_Click(object sender, RoutedEventArgs e)
        {
            int countBooksBought = 0;
            for (int i = 0; i < Global.BookBoughtBills.Count; i++)
            {
                countBooksBought += Global.BookBoughtBills[i].SoLuong;
            }
            countProductBuy.Badge = countBooksBought;
            ProductsBought.Visibility = Visibility.Collapsed;
        }

        private void Btn_Pay_Click(object sender, RoutedEventArgs e)
        {
            Receipt.Visibility = Visibility.Visible;
            ListViewProductsBoughtPreview.ItemsSource = Global.BookBoughtBills;
            double sumPrice = 0;
            for (int i = 0; i < Global.BookBoughtBills.Count; i++)
            {
                sumPrice += Global.BookBoughtBills[i].SoLuong * Global.BookBoughtBills[i].DonGiaBan;
            }
            ListViewProductsBought.ItemsSource = Global.BookBoughtBills;
            Label_SumPriceFinal.Content = sumPrice;
        }

        private void BtnRemoveFromShoppingCart_Click(object sender, RoutedEventArgs e)
        {
            ChiTietHoaDonBanSachDTO item = (ChiTietHoaDonBanSachDTO)((Button)sender).DataContext;
            MessageBox.Show(item.TenSach);
            if (Global.BookBoughtBills == null)
            {
                countProductBuy.Badge = 0;
                ShoppingCart_Empty.Visibility = Visibility.Visible;
                ShoppingCart_NoEmprty.Visibility = Visibility.Collapsed;
            }
            else
            {
                int countBooksBought = 0;
                double sumPrice = 0;
                for (int i = 0; i < Global.BookBoughtBills.Count; i++)
                {
                    countBooksBought += Global.BookBoughtBills[i].SoLuong;
                    sumPrice += Global.BookBoughtBills[i].TongDonGia;
                }
                countProductBuy.Badge = countBooksBought;
                ListViewProductsBought.ItemsSource = Global.BookBoughtBills;
                Label_SummaryPriceOfBill.Content = sumPrice;
            }
        }

        private void Combobox_countBookBought_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChiTietHoaDonBanSachDTO item = (ChiTietHoaDonBanSachDTO)((ComboBox)sender).DataContext; //Ở đây không dùng messagebox được. muốn test thì gán giá trị vào label nào đó test
            //Label_SummaryPriceOfBill.Content = item.TenSach;
            int countBooksBought = 0;
            double sumPrice = 0;
            for (int i = 0; i < Global.BookBoughtBills.Count; i++)
            {
                countBooksBought += Global.BookBoughtBills[i].SoLuong;
                sumPrice += Global.BookBoughtBills[i].TongDonGia;
            }
            countProductBuy.Badge = countBooksBought;
            ListViewProductsBought.ItemsSource = Global.BookBoughtBills;
            Label_SummaryPriceOfBill.Content = sumPrice;
        }

        private void Btn_BackBuyingMore_Click(object sender, RoutedEventArgs e)
        {
            ProductsBought.Visibility = Visibility.Collapsed;
            countProductBuy.Badge = 0;
        }

        private void Combobox_CategoriesBook_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_BackShoppingCart_Click(object sender, RoutedEventArgs e)
        {
            Receipt.Visibility = Visibility.Collapsed;
        }

        private void Btn_PlaceOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_PhoneNumberCustomer_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBox_PayCustomer_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
