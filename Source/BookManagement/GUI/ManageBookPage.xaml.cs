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
    /// Interaction logic for ManagePage.xaml
    /// </summary>
    public partial class ManageBookPage : Page
    {
        SachDTO temp = new SachDTO();
        byte[] bytes;
        string imgLoc;
        string imgCoverLoc;
        bool isImageChange = false;
        bool isImageCoverChange = false;
        int soLuongBanDau = 0;
        public ManageBookPage()
        {


       //     var books = new List<SachDTO>();
          /*  books.Add(new SachDTO(1, "Python Crash Course, 2nd Edition", "Eric Matthes", 59.5, 161.65, 10, 1, "Information Technology", "05/2019", "05/26/2019", "products/1.jpg", "products/1_cover.jpg"));
            books.Add(new SachDTO(2, "Clean Code", "Robert C. Martin", 60, 67.7, 5, 1, "Information Technology", "05/2019", "05/26/2019", "products/2.jpg", "products/2_cover.jpg"));
            books.Add(new SachDTO(3, "The Clean Coder", "Robert C. Martin", 55.1, 59.85, 5,2, "Information Technology", "05/2019", "05/26/2019", "products/3.jpg", "products/3_cover.jpg"));
            books.Add(new SachDTO(4, "Refactoring", "Martin Fowler", 55.1, 59.85, 5, 1, "Information Technology", "05/2019", "05/26/2019", "products/4.jpg", "products/4_cover.jpg"));
            books.Add(new SachDTO(5, "Clean Architecture", "Robert C. Martin", 46, 54.11, 5, 1, "Information Technology", "05/2019", "05/26/2019", "products/5.jpg", "products/5_cover.jpg"));
            books.Add(new SachDTO(6, "Building Microservices", "Sam Newman", 41.25, 48.69, 5, 3, "Information Technology", "05/2019", "05/26/2019", "products/6.jpg", "products/6_cover.jpg"));
            books.Add(new SachDTO(7, "Patterns of Enterprise Application Architecture", "Martin Fowler", 65, 80.62, 5, 1, "Information Technology", "05/2019", "05/26/2019", "products/7.jpg", "products/7_cover.jpg"));
            books.Add(new SachDTO(8, "Domain-Driven Design", "Gregor Hohpe", 70, 75.04, 5, 1, "Information Technology", "05/2019", "05/26/2019", "products/8.jpg", "products/8_cover.jpg"));
            books.Add(new SachDTO(9, "Domain-Driven Design Reference", "Eric Evans", 21, 25.5, 5, 1, "Information Technology", "05/2019", "05/26/2019", "products/9.jpg", "products/9_cover.jpg"));
            books.Add(new SachDTO(10, "Domain-Driven Design Distilled", "Vaughn Vernon", 47, 50.22, 5, 1, "Information Technology", "05/2019", "05/26/2019", "products/10.jpg", "products/10_cover.jpg"));
            books.Add(new SachDTO(11, "Implementing Domain-Driven Design", "Vaughn Vernon", 71.2, 78.22, 5, 4, "Information Technology", "05/2019", "05/26/2019", "products/11.jpg", "products/11_cover.jpg"));*/
         //   Global.Books = books;

          /*  var types = new List<TheLoaiDTO>();
            types.Add(new TheLoaiDTO(0, "All types"));
            types.Add(new TheLoaiDTO(1, "Information Technology"));
            types.Add(new TheLoaiDTO(2, "Math"));
            types.Add(new TheLoaiDTO(3, "English"));
            types.Add(new TheLoaiDTO(4, "Biology"));
            Global.Categories = types;*/

           /* var typesBook = new List<TheLoaiDTO>();
            typesBook.Add(new TheLoaiDTO(1, "Information Technology"));
            typesBook.Add(new TheLoaiDTO(2, "Math"));
            typesBook.Add(new TheLoaiDTO(3, "English"));
            typesBook.Add(new TheLoaiDTO(4, "Biology"));
            Global.BookCategories = typesBook;*/

            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ListViewBooks.ItemsSource = Global.Books;
            Combobox_CategoriesBook.ItemsSource = Global.Categories;
            Textbox__book_type.ItemsSource = Global.BookCategories;
            Textbox__addBook_type.ItemsSource = Global.BookCategories;
        }
        private void Loaded_CategoriesBook(object sender, RoutedEventArgs e)
        {
            Combobox_CategoriesBook.SelectedIndex = 0;
            Textbox__addBook_type.SelectedIndex = 0;
        }
        private void ScrollViewerBooks_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }
        private void selectItemBook(object sender, MouseButtonEventArgs e)
        {
            if (ListViewBooks.SelectedItems.Count > 0)
            {
               SachDTO item = (SachDTO)ListViewBooks.SelectedItems[0];
                Img__book_avartar.ImageSource = item.HinhAnh;
                Img__book_cover.ImageSource = item.HinhAnhCover;
                Textbox__book_id.Text = item.TenSach;
                Textbox__book_author.Text = item.TacGia;
                Textbox__book_priceRoot.Text = item.DonGiaNhap.ToString();
                Textbox__book_priceSell.Text = item.DonGiaBan.ToString();
                Textbox__book_exist.Content = item.SoLuong.ToString();
                Textbox__book_type.SelectedIndex = item.MaLoai - 1;
                btn_AddExist.IsEnabled = true;
                temp = item;
            }
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            string textToSearch = txtSearch.Text;
            ListViewBooks.ItemsSource = SachBUS.loadBySearch(textToSearch, Combobox_CategoriesBook.SelectedValue.ToString());
        }

        private void Combobox_CategoriesBook_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Combobox_CategoriesBook.SelectedValue != null)
            {
                ListViewBooks.ItemsSource = SachBUS.loadByMaLoai(Combobox_CategoriesBook.SelectedValue.ToString());
            }
        }

        private void btnUpadateImgCover_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

           if (dlg.ShowDialog() == true)
            {
                imgCoverLoc = dlg.FileName.ToString();
                bytes = SachDTO.FileToByteArray(imgCoverLoc);
                Img__book_cover.ImageSource = SachDTO.BitmapImageFromBytes(bytes);
                isImageCoverChange = true;
            }
            
        }

        private void btnUpadateImgAvatar_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            if (dlg.ShowDialog() == true)
            {
                imgLoc = dlg.FileName.ToString();
                bytes = SachDTO.FileToByteArray(imgLoc);
                Img__book_avartar.ImageSource = SachDTO.BitmapImageFromBytes(bytes);
                isImageChange = true;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            addBook.Visibility = Visibility.Visible;
            reviewBook.Visibility = Visibility.Collapsed;
            ListViewBooks.IsEnabled = false;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            btnCancel.Visibility = Visibility.Visible;
            btnDone.Visibility = Visibility.Visible;
            btnAdd.Visibility = Visibility.Collapsed;
            btnUpdateImg_Avatar.Visibility = Visibility.Visible;
            btnUpdateImg_Cover.Visibility = Visibility.Visible;
            Textbox__book_type.IsEnabled = true;
            Textbox__book_id.IsEnabled = true;
            Textbox__book_priceRoot.IsEnabled = true;
            Textbox__book_priceSell.IsEnabled = true;
            Textbox__book_author.IsEnabled = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            btnCancel.Visibility = Visibility.Collapsed;
            btnDone.Visibility = Visibility.Collapsed;
            btnAdd.Visibility = Visibility.Visible;
            btnUpdateImg_Avatar.Visibility = Visibility.Collapsed;
            btnUpdateImg_Cover.Visibility = Visibility.Collapsed;
            Textbox__book_type.IsEnabled = false;
            Textbox__book_id.IsEnabled = false;
            Textbox__book_priceRoot.IsEnabled = false;
            Textbox__book_priceSell.IsEnabled = false;
            Textbox__book_author.IsEnabled = false;

            Textbox__book_id.Text = temp.TenSach;
            Textbox__book_author.Text = temp.TacGia;
            Textbox__book_priceRoot.Text = temp.DonGiaNhap.ToString();
            Textbox__book_priceSell.Text = temp.DonGiaBan.ToString();
            Textbox__book_exist.Content = temp.SoLuong.ToString();
            Textbox__book_type.SelectedIndex = temp.MaLoai - 1;
        }

        private void BtnDone_Click(object sender, RoutedEventArgs e)
        {
            btnCancel.Visibility = Visibility.Collapsed;
            btnDone.Visibility = Visibility.Collapsed;
            btnAdd.Visibility = Visibility.Visible;
            btnUpdateImg_Avatar.Visibility = Visibility.Collapsed;
            btnUpdateImg_Cover.Visibility = Visibility.Collapsed;
            Textbox__book_type.IsEnabled = false;
            Textbox__book_id.IsEnabled = false;
            Textbox__book_priceRoot.IsEnabled = false;
            Textbox__book_priceSell.IsEnabled = false;
            Textbox__book_author.IsEnabled = false;

            SachDTO newSach = new SachDTO();
            newSach.TenSach = Textbox__book_id.Text;
            newSach.TacGia = Textbox__book_author.Text;
            newSach.DonGiaNhap =double.Parse(Textbox__book_priceRoot.Text);
            newSach.DonGiaBan = double.Parse(Textbox__book_priceSell.Text);
            newSach.SoLuong = int.Parse(Textbox__book_exist.Content.ToString());
            newSach.MaLoai = int.Parse(Textbox__book_type.SelectedIndex.ToString()) + 1;
            newSach.MaSach = temp.MaSach;

            if (SachBUS.updateSach(newSach) == false)
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình cập nhật thông tin sách", "Thông báo");
                return;
            }
            if (isImageChange)
            {
                isImageChange = false;
                if (SachBUS.updateImage(newSach, imgLoc) == false)
                {
                    imgLoc = "";
                    MessageBox.Show("Có lỗi xảy ra trong quá trình cập nhật hình ảnh", "Thông báo");
                    return;
                }
                imgLoc = "";
                
            }
            if (isImageCoverChange)
            {
                isImageCoverChange = false;
                if (SachBUS.updateImageCover(newSach, imgCoverLoc) == false)
                {
                    imgCoverLoc = "";
                    MessageBox.Show("Có lỗi xảy ra trong quá trình cập nhật ảnh cover", "Thông báo");
                    return;
                }
                imgCoverLoc = "";
            }
            if (newSach.SoLuong != temp.SoLuong)
            {
                LogSachDTO logSach = new LogSachDTO();
                logSach.SoLuong = newSach.SoLuong;
                logSach.ThoiGian = DateTime.Now.ToString();
                logSach.MaSach = newSach.MaSach;
                logSach.HanhDong = "Update book";
                LogSachBUS.insertToLog(logSach);
            }
            Global.Books = SachBUS.loadAll();
            ListViewBooks.ItemsSource = Global.Books;
        }

        private void Btn_AddExist_Click(object sender, RoutedEventArgs e)
        {
            AddExistBookForm.Visibility = Visibility.Visible;
            IdBook.Content = temp.MaSach;
            NameBook.Content = temp.TenSach;
            AuthorBook.Content = temp.TacGia;
        }

        private void btn_CloseAddExist(object sender, RoutedEventArgs e)
        {
            AddExistBookForm.Visibility = Visibility.Collapsed;
        }

        private void AddExistBook_Click(object sender, RoutedEventArgs e)
        {
            AddExistBookForm.Visibility = Visibility.Collapsed;
            Textbox__book_exist.Content = countAddBook.Text;

        }

        private void CountAddBook_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnAddImgCover_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            if (dlg.ShowDialog() == true)
            {
                imgCoverLoc = dlg.FileName.ToString();
                bytes = SachDTO.FileToByteArray(imgCoverLoc);
                Img__addBook_avatar.ImageSource = SachDTO.BitmapImageFromBytes(bytes);
                isImageCoverChange = true;
            }
        }

        private void btnAddImgAvatar_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            if (dlg.ShowDialog() == true)
            {
                imgLoc = dlg.FileName.ToString();
                bytes = SachDTO.FileToByteArray(imgLoc);
               Img__addBook_cover.ImageSource = SachDTO.BitmapImageFromBytes(bytes);
                isImageChange = true;
            }
        }

        private void BtnDone_addBook_Click(object sender, RoutedEventArgs e)
        {
            addBook.Visibility = Visibility.Collapsed;
            reviewBook.Visibility = Visibility.Visible;
            ListViewBooks.IsEnabled = true;

            SachDTO newSach = new SachDTO();
            newSach.TenSach = Textbox__addBook_id.Text;
            newSach.TacGia = Textbox__book_author.Text;
            newSach.DonGiaNhap = int.Parse(Textbox__addBook_priceRoot.Text);
            newSach.DonGiaBan = int.Parse(Textbox__addBook_priceSell.Text);
            newSach.SoLuong = int.Parse(Textbox__addBook_exist.Text);
            newSach.NgaySX = "";
            newSach.NgayNhap = DateTime.Now.ToString();
            newSach.MaLoai = int.Parse(Textbox__addBook_type.SelectedValue.ToString());
            if (imgLoc == "")
            {
                MessageBox.Show("Vui lòng chọn hình ảnh","Thông báo");
                return;
            }
            if (imgCoverLoc == "")
            {
                MessageBox.Show("Vui lòng chọn hình ảnh cover", "Thông báo");
                return;
            }
            if (SachBUS.addBook(newSach,imgLoc,imgCoverLoc) == false)
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình cập nhật sách", "Thông báo");
                imgCoverLoc = imgLoc = "";
                return;
            }
           

            MessageBox.Show("Thêm sách mới thành công", "Thông báo");
            Global.Books = SachBUS.loadAll();
            ListViewBooks.ItemsSource = Global.Books;

            LogSachDTO logSach = new LogSachDTO();
            logSach.HanhDong = "Add a book";
            logSach.SoLuong = newSach.SoLuong;
            logSach.ThoiGian = newSach.NgayNhap;
            logSach.MaSach = Global.Books[Global.Books.Count - 1].MaSach;
            LogSachBUS.insertToLog(logSach);
            imgCoverLoc = imgLoc = "";
            Textbox__addBook_id.Text = "";
            //Img__addBook_avatar.ImageSource = "";
            //Img__addBook_cover.ImageSource = "";
            Textbox__addBook_author.Text = "";
            Textbox__addBook_id.Text = "";
            Textbox__addBook_priceRoot.Text = "";
            Textbox__addBook_priceSell.Text = "";
            Textbox__addBook_exist.Text = "0";
            Loaded_CategoriesBook(sender, e);
        }

        private void BtnCancel_addBook_Click(object sender, RoutedEventArgs e)
        {
            addBook.Visibility = Visibility.Collapsed;
            reviewBook.Visibility = Visibility.Visible;
            ListViewBooks.IsEnabled = true;
            Textbox__addBook_id.Text = "";
            //Img__addBook_avatar.ImageSource = "";
            //Img__addBook_cover.ImageSource = "";
            Textbox__addBook_author.Text = "";
            Textbox__addBook_id.Text = "";
            Textbox__addBook_priceRoot.Text = "";
            Textbox__addBook_priceSell.Text = "";
            Textbox__addBook_exist.Text = "0";
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text == "")
            {
                ListViewBooks.ItemsSource = SachBUS.loadByMaLoai(Combobox_CategoriesBook.SelectedValue.ToString());
            }
        }

        
    }
}
