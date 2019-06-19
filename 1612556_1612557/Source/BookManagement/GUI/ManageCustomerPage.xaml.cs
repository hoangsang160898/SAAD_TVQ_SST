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
    /// Interaction logic for ManageCustomer.xaml
    /// </summary>
    public partial class ManageCustomerPage : Page
    {
        private int idCustomer;
        public ManageCustomerPage()
        {
           /* var customers = new List<KhachHangDTO>();
            customers.Add(new KhachHangDTO(1, "Leo Nguyen", "D1/3, duong 385, phuong Tang Nhon A, Quan 9, TPHCM", "1612556@student.hcmus.edu.com", "0399029922", 0));
            customers.Add(new KhachHangDTO(2, "Le Hoang Sang", "O dau do trong thanh pho", "1612557@student.hcmus.edu.com", "0432423423", 0.5));
            customers.Add(new KhachHangDTO(3, "Nguyen Thi Thu Quyen", "Ki tuc xa Quan 5", "thuquyen@gmail.com", "0312312312", 0.4));
            customers.Add(new KhachHangDTO(4, "Truong Quang", "Ki tuc xa Quan 5", "truongquang@student.hcmus.edu.com", "0399029922", 0));
            customers.Add(new KhachHangDTO(5, "Huynh Lam Phu Si", "O dau do trong thanh pho", "hlphusi@student.hcmus.edu.com", "0234531223", 1));
            customers.Add(new KhachHangDTO(6, "Nguyen Van Phuoc", "O dau do trong thanh pho", "nvphuoc@student.hcmus.edu.com", "0321321322", 0));
            customers.Add(new KhachHangDTO(7, "Phan Quoc Phong", "O dau do trong thanh pho", "pqphong@student.hcmus.edu.com", "0987651232", 0));
            customers.Add(new KhachHangDTO(8, "Truong Ho Phong", "O dau do trong thanh pho", "thphong@student.hcmus.edu.com", "0123412234", 0.2));
            customers.Add(new KhachHangDTO(9, "Hoang Trung Duc", "O dau do trong thanh pho", "htduc@student.hcmus.edu.com", "0213221321", 1));
            customers.Add(new KhachHangDTO(10, "Chau Hoang Phuc", "O dau do trong thanh pho", "chphuc@student.hcmus.edu.com", "012312312", 0));
            customers.Add(new KhachHangDTO(11, "Le Quoc Duy Quang", "O dau do trong thanh pho", "lqduyquang@student.hcmus.edu.com", "0312312321", 0.7));
            customers.Add(new KhachHangDTO(12, "Dang Vinh Phat", "Go Vap - TPHCM", "dvphat@student.hcmus.edu.com", "0564565456", 0));
            Global.Customers = customers;*/

            InitializeComponent();
            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
           if (txtSearch.Text == "")
            {
                ListViewCustomers.ItemsSource = KhachHangBUS.loadAll();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ListViewCustomers.ItemsSource = KhachHangBUS.loadAll();
        }
        private void ScrollViewerCustomers_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }
        //private void selectItemCustomer(object sender, MouseButtonEventArgs e)
        //{
        //    if (ListViewCustomers.SelectedItems.Count > 0)
        //    {
        //        KhachHangDTO item = (KhachHangDTO)ListViewCustomers.SelectedItems[0];

        //    }
        //}
        private void Btn_Debt_Click(object sender, RoutedEventArgs e)
        {
            KhachHangDTO item = (KhachHangDTO)((Button)sender).DataContext;
            Debt_IdCustomer.Content = idCustomer =item.MaKH;
            Debt_NameCustomer.Content = item.HoTen;
            Debt_PhoneNumberCustomer.Content = item.Sdt;
            Debt_TextBoxCustomer.Text = item.TienNo.ToString();
            ScrollViewer_Customers.IsEnabled = false;
            Debt.Visibility = Visibility.Visible;
            
        }

        private void btn_CloseDebt(object sender, RoutedEventArgs e)
        {
            ScrollViewer_Customers.IsEnabled = true;
            Debt.Visibility = Visibility.Collapsed;
            ListViewCustomers.ItemsSource = KhachHangBUS.loadAll();
        }

        private void Debt_BtnCusomer_Click(object sender, RoutedEventArgs e)
        {
            ScrollViewer_Customers.IsEnabled = true;
            Debt.Visibility = Visibility.Collapsed;
            if ( !KhachHangBUS.changeDebt(int.Parse(Debt_IdCustomer.Content.ToString()), double.Parse(Debt_TextBoxCustomer.Text)))
            {
                MessageBox.Show("Giá trị nhập không hợp lệ!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            ListViewCustomers.ItemsSource = KhachHangBUS.loadAll();
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            ListViewCustomers.ItemsSource = KhachHangBUS.searchCustomer(txtSearch.Text);
        }

        private void Debt_TextBoxCustomer_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regrex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            e.Handled = !regrex.IsMatch(e.Text);
        }

       
    }
    public class BooleanDebtConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((Double)value)
            {
                case 0:
                    return "False";
            }
            return "True";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value == true)
                    return "True";
                else
                    return "False";
            }
            return "False";
        }
    }
}
