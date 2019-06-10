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
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        public ReportPage()
        {
            var reports = new List<BaoCaoTonSachDTO>();
            reports.Add(new BaoCaoTonSachDTO(1,1, "Python Crash Course, 2nd Edition","6/10/2019","5/1/2019","5/30/2019",60,20,10));
            reports.Add(new BaoCaoTonSachDTO(2, 2, "Clean Code", "6/10/2019", "5/1/2019", "5/30/2019", 50, 10, 20));
            reports.Add(new BaoCaoTonSachDTO(3, 3, "The Clean Coder", "6/10/2019", "5/1/2019", "5/30/2019", 50, 10, 20));
            reports.Add(new BaoCaoTonSachDTO(4, 4, "Refactoring, 2nd Edition", "6/10/2019", "5/1/2019", "5/30/2019", 50, 10, 20));
            reports.Add(new BaoCaoTonSachDTO(5, 5, "Building Microservices", "6/10/2019", "5/1/2019", "5/30/2019", 50, 10, 20));
            reports.Add(new BaoCaoTonSachDTO(6, 6, "Patterns of Enterprise Application Architecture", "6/10/2019", "5/1/2019", "5/30/2019", 50, 10, 20));
            reports.Add(new BaoCaoTonSachDTO(7, 7, "Domain-Driven Design", "6/10/2019", "5/1/2019", "5/30/2019", 50, 10, 20));
            reports.Add(new BaoCaoTonSachDTO(8, 8, "Domain-Driven Design Reference", "6/10/2019", "5/1/2019", "5/30/2019", 60, 10, 15));
            reports.Add(new BaoCaoTonSachDTO(9, 9, "Python Crash Course, 2nd Edition", "6/10/2019", "5/1/2019", "5/30/2019", 50, 10, 20));
            reports.Add(new BaoCaoTonSachDTO(10, 10, "Domain-Driven Design Distilled", "6/10/2019", "5/1/2019", "5/30/2019", 50, 10, 20));
            reports.Add(new BaoCaoTonSachDTO(11, 11, "Implementing Domain-Driven Design", "6/10/2019", "5/1/2019", "5/30/2019", 50, 10, 20));
            Global.BookReport = reports;

            var reportCuss = new List<BaoCaoCongNoDTO>();
            reportCuss.Add(new BaoCaoCongNoDTO(1, 1, "Leo Nguyen", "6/10/2019", "5/1/2019", "5/30/2019", 60, 20, 10));
            reportCuss.Add(new BaoCaoCongNoDTO(2, 2, "Le Hoang Sang", "6/10/2019", "5/1/2019", "5/30/2019", 50, 10, 20));
            reportCuss.Add(new BaoCaoCongNoDTO(3, 3, "Nguyen Thi Thu Quyen", "6/10/2019", "5/1/2019", "5/30/2019", 50, 10, 20));
            reportCuss.Add(new BaoCaoCongNoDTO(4, 4, "Truong Quang", "6/10/2019", "5/1/2019", "5/30/2019", 50, 10, 20));
            reportCuss.Add(new BaoCaoCongNoDTO(5, 5, "Huynh Lam Phu Si", "6/10/2019", "5/1/2019", "5/30/2019", 50, 10, 20));
            reportCuss.Add(new BaoCaoCongNoDTO(6, 6, "Nguyen Van Phuoc", "6/10/2019", "5/1/2019", "5/30/2019", 50, 10, 20));
            reportCuss.Add(new BaoCaoCongNoDTO(7, 7, "Phan Quoc Phong", "6/10/2019", "5/1/2019", "5/30/2019", 50, 10, 20));
            reportCuss.Add(new BaoCaoCongNoDTO(8, 8, "Hoang Trung Duc", "6/10/2019", "5/1/2019", "5/30/2019", 60, 10, 15));
            reportCuss.Add(new BaoCaoCongNoDTO(9, 9, "Chau Hoang Phuc", "6/10/2019", "5/1/2019", "5/30/2019", 50, 10, 20));
            reportCuss.Add(new BaoCaoCongNoDTO(10, 10, "Le Quoc Duy Quang", "6/10/2019", "5/1/2019", "5/30/2019", 50, 10, 20));
            reportCuss.Add(new BaoCaoCongNoDTO(11, 11, "Dang Vinh Phat", "6/10/2019", "5/1/2019", "5/30/2019", 50, 10, 20));
            Global.CustomerReport = reportCuss;
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ListViewBookReports.ItemsSource = Global.BookReport;
            ListViewCustomerReports.ItemsSource = Global.CustomerReport;
        }
        private void ScrollViewerBookReports_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }
        private void ScrollViewerCustomerReports_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }
    }
}
