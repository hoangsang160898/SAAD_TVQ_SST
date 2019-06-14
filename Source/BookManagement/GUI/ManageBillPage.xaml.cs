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

namespace GUI
{
    /// <summary>
    /// Interaction logic for ManageBillPage.xaml
    /// </summary>
    public partial class ManageBillPage : Page
    {
        int currentPage = 0;
        public ManageBillPage()
        {
            var bills = new List<PhieuThuTienDTO>();
            bills.Add(new PhieuThuTienDTO(1, 899, 2, "06/03/2019", 0, "Patterns of Enterprise Application Architecture","Leo Nguyen",889));
            bills.Add(new PhieuThuTienDTO(2, 999, 3, "06/02/2019", 4, "The Clean Coder", "aaG oaahT", 999));
            bills.Add(new PhieuThuTienDTO(3, 1409, 1, "06/02/2019", 3, "Patterns of Enterprise Application Architecture","Le Sang", 1410));
            bills.Add(new PhieuThuTienDTO(4, 234, 2, "06/02/2019", 4, "Implementing Domain-Driven Design", "Leo Nguyen", 234));
            bills.Add(new PhieuThuTienDTO(5, 888, 4, "06/01/2019", 0, "Patterns of Enterprise Application Architecture","Nguyen Thi Thu Quyen", 888));
            bills.Add(new PhieuThuTienDTO(6, 456, 5, "06/01/2019", 7, "Implementing Domain-Driven Design", "Mr Phong Truong Ho Phong", 456));
            bills.Add(new PhieuThuTienDTO(7, 123, 6, "05/29/2019", 4, "Patterns of Enterprise Application Architecture","Dang Vinh Phat", 123));
            bills.Add(new PhieuThuTienDTO(8, 543, 7, "05/29/2019", 10, "Domain-Driven Design Reference","Nguyen Quang Phu", 543));
            bills.Add(new PhieuThuTienDTO(9, 222, 8, "05/28/2019", 4, "Domain-Driven Design Reference", "Nguyen Van Phuoc", 222));
            bills.Add(new PhieuThuTienDTO(10, 100.9, 9, "05/27/2019", 3, "Patterns of Enterprise Application Architecture","Le Tuong Qui", 101));
            bills.Add(new PhieuThuTienDTO(11, 222, 11, "05/26/2019", 0, "Patterns of Enterprise Application Architecture","Chau Hoang Phuc", 222.5));
            bills.Add(new PhieuThuTienDTO(12, 654, 13, "05/26/2019", 4, "Patterns of Enterprise Application Architecture","Truong Quang", 654));
            bills.Add(new PhieuThuTienDTO(13, 1234, 16, "05/25/2019", 2, "Patterns of Enterprise Application Architecture","Huynh Lam Phu Si", 1234));
            bills.Add(new PhieuThuTienDTO(14, 123.23, 23, "05/20/2019", 4, "Building Microservices", "Phan Quoc Phong", 123.23));
            bills.Add(new PhieuThuTienDTO(15, 1090.8, 25, "05/20/2019", 6, "Building Microservices", "Pham Ngoc Son", 1090.8));
            Global.Bills = bills;

            var booksBoughtBillPreview = new List<ChiTietHoaDonBanSachDTO>();
            /*booksBoughtBillPreview.Add(new ChiTietHoaDonBanSachDTO(1, 1, "Python Crash Course, 2nd Edition", "Eric Matthes", 3, 161.65, "products/1.jpg"));
            booksBoughtBillPreview.Add(new ChiTietHoaDonBanSachDTO(2, 2, "Patterns of Enterprise Application Architecture", "Martin Fowler", 1, 80.62, "products/7.jpg"));
            booksBoughtBillPreview.Add(new ChiTietHoaDonBanSachDTO(3, 3, "The Clean Coder", "Robert C. Martin", 2, 59.85, "products/3.jpg"));
            booksBoughtBillPreview.Add(new ChiTietHoaDonBanSachDTO(4, 4, "Refactoring", "Martin Fowler", 4, 59.85, "products/4.jpg"));
            booksBoughtBillPreview.Add(new ChiTietHoaDonBanSachDTO(5, 5, "Clean Architecture", "Robert C. Martin", 6, 54.11, "products/5.jpg"));
            booksBoughtBillPreview.Add(new ChiTietHoaDonBanSachDTO(6, 6, "Building Microservices", "Sam Newman", 7, 48.69, "products/6.jpg"));*/
            Global.BookBoughtBillsPreview = booksBoughtBillPreview;

            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ListViewBills.ItemsSource = Global.Bills.Skip(0).Take(8);
            if (currentPage == 0)
            {
                btnPrev.Visibility = Visibility.Collapsed;
            }
            else
            {
                btnPrev.Visibility = Visibility.Visible;
            }
            if (Global.Bills.Count() <= 8 || currentPage == (Global.Bills.Count() / 8))
            {
                btnNext.Visibility = Visibility.Collapsed;
            }
            else
            {
                btnNext.Visibility = Visibility.Visible;
            }
        }
        private void ScrollViewerBills_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {

            if (currentPage < Global.Bills.Count() / 8)
            {
                currentPage++;
            }
            ListViewBills.ItemsSource = Global.Bills.Skip(currentPage * 8).Take(8);

            if (currentPage == 0)
            {
                btnPrev.Visibility = Visibility.Collapsed;
            }
            else
            {
                btnPrev.Visibility = Visibility.Visible;
            }
            if (Global.Bills.Count() <= 8 || currentPage == (Global.Bills.Count() / 8))
            {
                btnNext.Visibility = Visibility.Collapsed;
            }
            else
            {
                btnNext.Visibility = Visibility.Visible;
            }
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage > 0)
            {
                currentPage--;
            }
            ListViewBills.ItemsSource = Global.Bills.Skip(currentPage * 8).Take(8);

            if (currentPage == 0)
            {
                btnPrev.Visibility = Visibility.Collapsed;
            }
            else
            {
                btnPrev.Visibility = Visibility.Visible;
            }
            if (Global.Bills.Count() <= 8 || currentPage == (Global.Bills.Count() / 8))
            {
                btnNext.Visibility = Visibility.Collapsed;
            }
            else
            {
                btnNext.Visibility = Visibility.Visible;
            }
        }
        private void selectItemBill(object sender, MouseButtonEventArgs e)
        {
            if (ListViewBills.SelectedItems.Count > 0)
            {
                PhieuThuTienDTO item = (PhieuThuTienDTO)ListViewBills.SelectedItems[0];
                DetailBill.Visibility = Visibility.Visible;
                ListViewProductsBought.ItemsSource = Global.BookBoughtBillsPreview;
                Label_SummaryPriceOfBill.Content = item.SoTienHoaDonBanSach;
                Label_PaidPriceOfBill.Content = item.SoTienThu;
            }
        }
        private void ScrollViewerProducts_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void Btn_BackManageBills_Click(object sender, RoutedEventArgs e)
        {
            DetailBill.Visibility = Visibility.Collapsed;
        }
    }
    public class BooleanBooksConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (value)
            {
                case 0:
                    return "Collapsed";
            }
            return "Visible";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value == true)
                    return "Collapsed";
                else
                    return "Visible";
            }
            return "Visible";
        }
    }
}
