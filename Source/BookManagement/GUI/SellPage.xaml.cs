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
        private List<ChiTietHoaDonBanSachDTO> listChiTietHoaDon = new List<ChiTietHoaDonBanSachDTO>();
        private KhachHangDTO khachHangMuaHang;
        public SellPage()
        {

            // test books
        //    var books = new List<SachDTO>();
        /*    books.Add(new SachDTO(1, "Python Crash Course, 2nd Edition", "Eric Matthes", 59.5, 161.65, 10, 1, "Information Technology", "05/2019", "05/26/2019", "products/1.jpg", "products/1_cover.jpg"));
            books.Add(new SachDTO(2, "Patterns of Enterprise Application Architecture", "Martin Fowler", 65, 80.62, 5, 1, "Information Technology", "05/2019", "05/26/2019", "products/7.jpg", "products/7_cover.jpg"));
            books.Add(new SachDTO(3, "The Clean Coder", "Robert C. Martin", 55.1, 59.85, 5, 1, "Information Technology", "05/2019", "05/26/2019", "products/3.jpg", "products/3_cover.jpg"));
            books.Add(new SachDTO(4, "Refactoring", "Martin Fowler", 55.1, 59.85, 5, 1, "Information Technology", "05/2019", "05/26/2019", "products/4.jpg", "products/4_cover.jpg"));
            books.Add(new SachDTO(5, "Clean Architecture", "Robert C. Martin", 46, 54.11, 5, 1, "Information Technology", "05/2019", "05/26/2019", "products/5.jpg", "products/5_cover.jpg"));
            books.Add(new SachDTO(6, "Building Microservices", "Sam Newman", 41.25, 48.69, 5, 1, "Information Technology", "05/2019", "05/26/2019", "products/6.jpg", "products/6_cover.jpg"));
            books.Add(new SachDTO(7, "Clean Code", "Robert C. Martin", 60, 67.7, 5, 1, "Information Technology", "05/2019", "05/26/2019", "products/2.jpg", "products/2_cover.jpg"));
            books.Add(new SachDTO(8, "Domain-Driven Design", "Gregor Hohpe", 70, 75.04, 5, 1, "Information Technology", "05/2019", "05/26/2019", "products/8.jpg", "products/8_cover.jpg"));
            books.Add(new SachDTO(9, "Domain-Driven Design Reference", "Eric Evans", 21, 25.5, 5, 1, "Information Technology", "05/2019", "05/26/2019", "products/9.jpg", "products/9_cover.jpg"));
            books.Add(new SachDTO(10, "Domain-Driven Design Distilled", "Vaughn Vernon", 47, 50.22, 5, 1, "Information Technology", "05/2019", "05/26/2019", "products/10.jpg", "products/10_cover.jpg"));
            books.Add(new SachDTO(11, "Implementing Domain-Driven Design", "Vaughn Vernon", 71.2, 78.22, 5, 1, "Information Technology", "05/2019", "05/26/2019", "products/11.jpg", "products/11_cover.jpg"));*/

            // test categories
        /*    var types = new List<TheLoaiDTO>();
            types.Add(new TheLoaiDTO(0, "All types"));
            types.Add(new TheLoaiDTO(1, "Information Technology"));
            types.Add(new TheLoaiDTO(2, "Math"));
            types.Add(new TheLoaiDTO(3, "English"));
            types.Add(new TheLoaiDTO(4, "Biology"));
            Global.Categories = types;*/

            //test bill
            var booksBoughtBill = new List<ChiTietHoaDonBanSachDTO>();
          /*  booksBoughtBill.Add(new ChiTietHoaDonBanSachDTO(1, 1, "Python Crash Course, 2nd Edition", "Eric Matthes", 3, 161.65, "products/1.jpg"));
            booksBoughtBill.Add(new ChiTietHoaDonBanSachDTO(2, 2, "Patterns of Enterprise Application Architecture", "Martin Fowler", 1, 80.62, "products/7.jpg"));
            booksBoughtBill.Add(new ChiTietHoaDonBanSachDTO(3, 3, "The Clean Coder", "Robert C. Martin", 2, 59.85, "products/3.jpg"));
            booksBoughtBill.Add(new ChiTietHoaDonBanSachDTO(4, 4, "Refactoring", "Martin Fowler", 4, 59.85, "products/4.jpg"));
            booksBoughtBill.Add(new ChiTietHoaDonBanSachDTO(5, 5, "Clean Architecture", "Robert C. Martin", 6, 54.11, "products/5.jpg"));
            booksBoughtBill.Add(new ChiTietHoaDonBanSachDTO(6, 6, "Building Microservices", "Sam Newman", 7, 48.69, "products/6.jpg"));*/
            Global.BookBoughtBills = booksBoughtBill;

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
            ProductsBought.Visibility = Visibility.Visible;
        }

        private void Btn_DeleteAll_Click(object sender, RoutedEventArgs e)
        {
            listChiTietHoaDon.Clear();
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
            countProductBuy.Badge = 0;

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
        }
    }
}
