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
        private List<ChiTietHoaDonBanSachDTO> listChiTietHoaDon = Global.BookBoughtBills;
        private KhachHangDTO khachHangMuaHang;
        public SellPage()
        {

       

            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            int countBooksBought = 0;
            listChiTietHoaDon.ForEach(i =>
            {
                countBooksBought += i.SoLuong;
            });
            countProductBuy.Badge = countBooksBought;
            ListViewProducts.ItemsSource = Global.Books;
            Combobox_CategoriesBook.ItemsSource = Global.Categories;
        }

        private void BtnBuyProduct_Click(object sender, RoutedEventArgs e)
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
           /* if (Global.BookBoughtBills != null)
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
            ProductsBought.Visibility = Visibility.Visible;*/


            if (listChiTietHoaDon.Count > 0)
            {
                double sumPrice = 0;
                listChiTietHoaDon.ForEach(i => {
                    sumPrice += i.SoLuong * i.Sach.DonGiaBan;
                    i.TongDonGia = i.SoLuong * i.Sach.DonGiaBan;
                });
         
                ListViewProductsBought.ItemsSource = new List<ChiTietHoaDonBanSachDTO>();
                ListViewProductsBought.ItemsSource = listChiTietHoaDon;
                Label_SummaryPriceOfBill.Content = sumPrice;
                ShoppingCart_Empty.Visibility = Visibility.Collapsed;
                ShoppingCart_NoEmprty.Visibility = Visibility.Visible;
            }
            else
            {
                ShoppingCart_Empty.Visibility = Visibility.Visible;
                ShoppingCart_NoEmprty.Visibility = Visibility.Collapsed;
            }
            Global.BookBoughtBills = listChiTietHoaDon;
            ProductsBought.Visibility = Visibility.Visible;
        }

        private void Btn_DeleteAll_Click(object sender, RoutedEventArgs e)
        {
            listChiTietHoaDon.Clear();
            Global.BookBoughtBills.Clear();
            ListViewProductsBought.ItemsSource = listChiTietHoaDon;
            Label_SummaryPriceOfBill.Content = "";
            countProductBuy.Badge = 0;
            ShoppingCart_Empty.Visibility = Visibility.Visible;
            ShoppingCart_NoEmprty.Visibility = Visibility.Collapsed;
        }

        private void Btn_BuyMore_Click(object sender, RoutedEventArgs e)
        {
            int countBooksBought = 0;
            listChiTietHoaDon.ForEach(i =>
            {
                countBooksBought += i.SoLuong;
            });
            countProductBuy.Badge = countBooksBought;
        
            ProductsBought.Visibility = Visibility.Collapsed;
        }

        private void Btn_Pay_Click(object sender, RoutedEventArgs e)
        {
            Receipt.Visibility = Visibility.Visible; 
            double sumPrice = 0;
            listChiTietHoaDon.ForEach(i =>
            {
                sumPrice += i.SoLuong * i.Sach.DonGiaBan;
            });
            ListViewProductsBoughtPreview.ItemsSource = new List<ChiTietHoaDonBanSachDTO>();
            ListViewProductsBoughtPreview.ItemsSource = listChiTietHoaDon;
            Label_SumPriceFinal.Content = sumPrice;
            Global.BookBoughtBills = listChiTietHoaDon;
        }

        private void BtnRemoveFromShoppingCart_Click(object sender, RoutedEventArgs e)
        {
            ChiTietHoaDonBanSachDTO item = (ChiTietHoaDonBanSachDTO)((Button)sender).DataContext;
           // MessageBox.Show(item.TenSach);
            if (listChiTietHoaDon.Count <= 0)
            {
                countProductBuy.Badge = 0;
                ShoppingCart_Empty.Visibility = Visibility.Visible;
                ShoppingCart_NoEmprty.Visibility = Visibility.Collapsed;
            }
            else
            {
                int countBooksBought = 0;
                double sumPrice = 0;
               
                listChiTietHoaDon.ForEach(i =>
                {
                    countBooksBought += i.SoLuong;
                    sumPrice += i.SoLuong * i.Sach.DonGiaBan;
                    if (i.Sach.MaSach == item.Sach.MaSach)
                    {
                        countBooksBought -= i.SoLuong;
                        sumPrice -= i.SoLuong * i.Sach.DonGiaBan;
                    }
                });
                listChiTietHoaDon.RemoveAll(i => (i.Sach.MaSach == item.Sach.MaSach));
                countProductBuy.Badge = countBooksBought;
                ListViewProductsBought.ItemsSource = new List<ChiTietHoaDonBanSachDTO>();
                ListViewProductsBought.ItemsSource = listChiTietHoaDon;
                Label_SummaryPriceOfBill.Content = sumPrice;
                Global.BookBoughtBills = listChiTietHoaDon;
            }
        }

        private void Combobox_countBookBought_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             ChiTietHoaDonBanSachDTO item = (ChiTietHoaDonBanSachDTO)((ComboBox)sender).DataContext; //Ở đây không dùng messagebox được. muốn test thì gán giá trị vào label nào đó test
            int countBooksBought = 0;
            double sumPrice = 0;
               listChiTietHoaDon.ForEach(i => {
                   if (i.Sach.MaSach == item.Sach.MaSach)
                   {
                       i.SoLuong = item.SoLuong;
                   }
                   countBooksBought += i.SoLuong;
                   sumPrice = sumPrice + i.SoLuong * i.Sach.DonGiaBan;
                   i.TongDonGia = i.Sach.DonGiaBan * i.SoLuong;
               });
               countProductBuy.Badge = countBooksBought;
           // ListViewProductsBought.ItemsSource = new List<ChiTietHoaDonBanSachDTO>();
            ListViewProductsBought.ItemsSource = listChiTietHoaDon;
            Label_SummaryPriceOfBill.Content = sumPrice;
        }

        private void Btn_BackBuyingMore_Click(object sender, RoutedEventArgs e)
        {
            ProductsBought.Visibility = Visibility.Collapsed;
            countProductBuy.Badge = 0;
        }

        private void Combobox_CategoriesBook_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Combobox_CategoriesBook.SelectedValue != null)
            {
                ListViewProducts.ItemsSource = SachBUS.loadByMaLoai(Combobox_CategoriesBook.SelectedValue.ToString());
            }
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            string textToSearch = txtSearch.Text;
            ListViewProducts.ItemsSource = SachBUS.loadBySearch(textToSearch, Combobox_CategoriesBook.SelectedValue.ToString());
        }

        private void Btn_BackShoppingCart_Click(object sender, RoutedEventArgs e)
        {
            Receipt.Visibility = Visibility.Collapsed;
        }

        private void Btn_PlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            if (khachHangMuaHang == null)
            {
                KhachHangDTO khachHang = new KhachHangDTO();
                khachHang.HoTen = TextBox_FullNameCustomer.Text;
                khachHang.Email = TextBox_EmailCustomer.Text;
                khachHang.DiaChi = TextBox_AddressCustomer.Text;
                khachHang.Sdt = TextBox_PhoneNumberCustomer.Text;
                khachHang.TienNo = 0;

                KhachHangBUS.addCustomer(khachHang);
                khachHangMuaHang = new KhachHangDTO(KhachHangBUS.getLastedID(), khachHang.HoTen, khachHang.DiaChi, khachHang.Email, khachHang.Sdt, khachHang.TienNo);
                LogKhachHangDTO logKhachHang = new LogKhachHangDTO();
                logKhachHang.MaKH = khachHangMuaHang.MaKH;
                logKhachHang.ThoiGian = datePickerNgayMua.ToString();
                logKhachHang.TienNo = 0;
                LogKhachHangBUS.insertToLog(logKhachHang);
            }
           listChiTietHoaDon.ForEach(i =>
             {
                 if (SachBUS.CheckUpdateSoLuong(i.Sach.MaSach.ToString(),i.SoLuong.ToString()) == false)
                 {
                     MessageBox.Show("Lượng tồn sau khi bán của sách " + i.Sach.TenSach + " không hợp lệ", "Thông báo");
                     return;
                 }
             });


             if (KhachHangBUS.checkNoToiDa(khachHangMuaHang.MaKH.ToString()) == false)
             {
                 MessageBox.Show("Khách hàng " + khachHangMuaHang.HoTen + " có tiền nợ vượt mức cho phép mua hàng", "Thông báo");
                 return;
             }

             // Cập nhật lại số lượng sách
             listChiTietHoaDon.ForEach(i =>
             {
                 if (SachBUS.updateSoLuong(i.Sach.MaSach.ToString(),i.SoLuong.ToString()) == false)
                 {
                     MessageBox.Show("Có lỗi xảy ra trong quá trình cập nhật số lượng sách", "Thông báo");
                     return;
                 }
             });
             // Cập nhật hóa đơn bán sách
             HoaDonBanSachDTO hoaDon = new HoaDonBanSachDTO();
             hoaDon.TongTien = double.Parse(Label_SummaryPriceOfBill.Content.ToString());
             hoaDon.MaKH = khachHangMuaHang.MaKH;
             hoaDon.NgayTaoHoaDon = datePickerNgayMua.ToString();
             if (HoaDonBanSachBUS.insertHoaDon(hoaDon) == false)
             {
                 MessageBox.Show("Có lỗi xảy ra trong quá trình tạo hóa đơn", "Thông báo");
                 return;
             }
            // Cập nhật chi tiết hóa đơn bán sách
            hoaDon = HoaDonBanSachBUS.getLastHoaDon();
            listChiTietHoaDon.ForEach(i =>
            {
                i.MaHoaDon = hoaDon.MaHoaDon;
                if (ChiTietHoaDonBanSachBUS.insertChiTietHoaDon(i) == false)
                {
                    MessageBox.Show("Có lỗi xảy ra trong quá trình cập nhật chi tiết hóa đơn bán sách", "Thông báo");
                    return;
                }
            });
            // Cập nhật tiền nợ của khách hàng
            double noTangThem = double.Parse(Label_SummaryPriceOfBill.Content.ToString()) - double.Parse(TextBox_PayCustomer.Text);
            double tienNoMoi = khachHangMuaHang.TienNo + noTangThem;
            if (tienNoMoi != khachHangMuaHang.TienNo)
            {
                if (KhachHangBUS.changeDebt(khachHangMuaHang.MaKH, tienNoMoi) == false)
                {
                    MessageBox.Show("Cập nhật tiền nợ của khách hàng thất bại", "Thông báo");
                    return;
                }
            }
            //Tạo log sách
            listChiTietHoaDon.ForEach(i =>
            {
                LogSachDTO logSach = new LogSachDTO();
                logSach.MaSach = i.Sach.MaSach;
                logSach.SoLuong = i.Sach.SoLuong - i.SoLuong;
                logSach.ThoiGian = datePickerNgayMua.ToString();
                logSach.HanhDong = "Sell a book";
                if (LogSachBUS.insertToLog(logSach) == false)
                {
                    MessageBox.Show("Có lỗi xảy ra trong quá trình tạo log sách", "Thông báo");
                    return;
                }
            });
            // Tạo log khách hàng
            if (tienNoMoi != khachHangMuaHang.TienNo)
            {
                LogKhachHangDTO logKhachHang = new LogKhachHangDTO();
                logKhachHang.MaKH = khachHangMuaHang.MaKH;
                logKhachHang.ThoiGian = datePickerNgayMua.ToString();
                logKhachHang.TienNo = tienNoMoi;
                if (LogKhachHangBUS.insertToLog(logKhachHang) == false)
                {
                    MessageBox.Show("Có lỗi xảy ra trong quá trình tạo log khách hàng", "Thông báo");
                    return;
                }
            }

            // Tạo phiếu thu tiền
            PhieuThuTienSachDTO phieuThu = new PhieuThuTienSachDTO();
            phieuThu.HoaDonBanSach = hoaDon;
            phieuThu.SoTienThu = double.Parse(TextBox_PayCustomer.Text);
            if (PhieuThuTienSachBUS.insert(phieuThu) == false)
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình tạo phiếu thu tiền", "Thông báo");
                return;
            }
            MessageBox.Show("Thanh toán thành công", "Thông báo");
            listChiTietHoaDon.Clear();
            Global.BookBoughtBills.Clear();
            countProductBuy.Badge = 0;
            Global.Books = SachBUS.loadAll();
            Global.Customers = KhachHangBUS.loadAll();
        }

        private void TextBox_PhoneNumberCustomer_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBox_PayCustomer_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regrex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            e.Handled = !regrex.IsMatch(e.Text);
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text == "")
            {
                ListViewProducts.ItemsSource = SachBUS.loadByMaLoai(Combobox_CategoriesBook.SelectedValue.ToString());
            }
        }

       

        private void TextBox_PhoneNumberCustomer_TextChanged(object sender, TextChangedEventArgs e)
        {
            KhachHangDTO khachHang = KhachHangBUS.searchByPhone(TextBox_PhoneNumberCustomer.Text);
            if (khachHang != null)
            {
                TextBox_FullNameCustomer.Text = khachHang.HoTen;
                TextBox_EmailCustomer.Text = khachHang.Email;
                TextBox_AddressCustomer.Text = khachHang.DiaChi;
                TextBox_DebtCustomer.Text = khachHang.TienNo.ToString();
                khachHangMuaHang = new KhachHangDTO(khachHang.MaKH, khachHang.HoTen,khachHang.DiaChi, khachHang.Email, khachHang.Sdt, khachHang.TienNo);
            }
            else
            {
                khachHangMuaHang = null;
            }
           
        }
    }
}
