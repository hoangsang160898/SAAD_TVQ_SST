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
            InitializeComponent(); 
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var reports = BaoCaoTonSachBUS.loadReportBook(Global.Books, "1990-01-01", DateTime.Now.ToString());
            Global.BookReport = reports;
            ListViewBookReports.ItemsSource = Global.BookReport;

            var reportCustomer = BaoCaoCongNoBUS.loadReport(Global.Customers, "1990-01-01", DateTime.Now.ToString());
            Global.CustomerReport = reportCustomer;
            if (reportCustomer != null)
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

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            List<BaoCaoTonSachDTO> reports;
            if (startDate.SelectedDate == null)
            {
                reports = BaoCaoTonSachBUS.loadReportBook(Global.Books, "1990-01-01", endDate.SelectedDate.Value.ToString());
            }
            else
            {
                reports = BaoCaoTonSachBUS.loadReportBook(Global.Books, startDate.SelectedDate.Value.ToString(), endDate.SelectedDate.Value.ToString());
            }
            Global.BookReport = reports;
            ListViewBookReports.ItemsSource = Global.BookReport;
        }

        private void Customer_EndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            List<BaoCaoCongNoDTO> reportCustomer;
            if (Customer_StartDate.SelectedDate == null)
            {
                reportCustomer = BaoCaoCongNoBUS.loadReport(Global.Customers,"1990-01-01", Customer_EndDate.SelectedDate.Value.ToString());
            }
            else
            {
                reportCustomer = BaoCaoCongNoBUS.loadReport(Global.Customers, Customer_StartDate.SelectedDate.Value.ToString(), Customer_EndDate.SelectedDate.Value.ToString());
            }
            Global.CustomerReport = reportCustomer;
            if (reportCustomer != null)
                 ListViewCustomerReports.ItemsSource = Global.CustomerReport;
        }
    }
}
