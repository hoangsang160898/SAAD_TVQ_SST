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
        List<ChiTietHoaDonBanSachDTO> listChiTietHoaDon;
        public HomePage()
        {
            InitializeComponent();
            listChiTietHoaDon = Global.BookBoughtBills;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (Global.BookBoughtBills.Count <= 0)
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

            ListViewProductsLastest.ItemsSource = SachBUS.loadLastedBook();
            ListViewProductsMostBought.ItemsSource = SachBUS.loadMostBuy();
        }
        private void ScrollViewerProductsMostBought_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToHorizontalOffset(scv.HorizontalOffset - e.Delta);
            e.Handled = true;
        }
        private void ScrollViewerProductsLastest_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToHorizontalOffset(scv.HorizontalOffset - e.Delta);
            e.Handled = true;
        }
        private void BtnBuyProductLastest_Click(object sender, RoutedEventArgs e)
        {
            SachDTO item = (SachDTO)((Button)sender).DataContext;
            bool check = false;
            int countBooksBought = 0;
            if (listChiTietHoaDon == null)
                listChiTietHoaDon = new List<ChiTietHoaDonBanSachDTO>();
            listChiTietHoaDon.ForEach(i =>
            {
                countBooksBought += i.SoLuong;
                if (i.Sach.MaSach == item.MaSach)
                {
                    i.SoLuong++;
                    check = true;
                }
            });
            if (check == false)
            {
                var chiTietHoaDon = new ChiTietHoaDonBanSachDTO();
                chiTietHoaDon.Sach = item;
                chiTietHoaDon.SoLuong = 1;
                listChiTietHoaDon.Add(chiTietHoaDon);
            }
            countBooksBought++;
            countProductBuy.Badge = countBooksBought;
            Global.BookBoughtBills = listChiTietHoaDon;
        }
        private void BtnBuyProductMostBought_Click(object sender, RoutedEventArgs e)
        {
            SachDTO item = (SachDTO)((Button)sender).DataContext;
            bool check = false;
            int countBooksBought = 0;
            listChiTietHoaDon.ForEach(i =>
            {
                countBooksBought += i.SoLuong;
                if (i.Sach.MaSach == item.MaSach)
                {
                    i.SoLuong++;
                    check = true;
                }
            });
            if (check == false)
            {
                var chiTietHoaDon = new ChiTietHoaDonBanSachDTO();
                chiTietHoaDon.Sach = item;
                chiTietHoaDon.SoLuong = 1;
                listChiTietHoaDon.Add(chiTietHoaDon);
            }
            countBooksBought++;
            countProductBuy.Badge = countBooksBought;
            Global.BookBoughtBills = listChiTietHoaDon;
        }
    }
}
