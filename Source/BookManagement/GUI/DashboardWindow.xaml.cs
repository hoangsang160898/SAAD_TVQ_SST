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
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : Window
    {
        public DashboardWindow()
        {
            InitializeComponent();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            GridPrincipal.IsEnabled = false;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
            GridPrincipal.IsEnabled = true;
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btn_CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_MinimizeWindow(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);
            switch (index)
            {
                case 0:
                    //GridPrincipal.Content = new ViewItemsPage();

                    break;
                case 1:
                    //GridPrincipal.Content = new ReportPage();
                    break;
                case 2:
                    //GridPrincipal.Content = new ChartPage();
                    break;
                case 3:
                    //GridPrincipal.Content = new ManageProductsPage();
                    break;
                case 4:
                    //GridPrincipal.Content = new ManageSalesPage();
                    break;
                case 5:
                    //GridPrincipal.Content = new AboutPage();
                    break;
                default:
                    break;
            }
        }

        private void MoveCursorMenu(int index)
        {
            string testContent = "ListViewMenu__tab1_content";
            ;
            GridCursor.Margin = new Thickness(0, (157+(50 * index)), 0, 0);
            switch (index)
            {
                case 0:
                    ListViewMenu__tab1_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000"));
                    ListViewMenu__tab1_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000"));
                    ListViewMenu__tab2_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab2_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab3_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab3_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab4_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab4_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab5_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab5_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab6_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab6_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    break;
                case 1:
                    ListViewMenu__tab1_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab1_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab2_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000"));
                    ListViewMenu__tab2_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000"));
                    ListViewMenu__tab3_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab3_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab4_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab4_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab5_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab5_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab6_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab6_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    break;
                case 2:
                    ListViewMenu__tab1_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab1_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab2_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab2_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab3_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000"));
                    ListViewMenu__tab3_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000"));
                    ListViewMenu__tab4_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab4_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab5_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab5_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab6_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab6_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    break;
                case 3:
                    ListViewMenu__tab1_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab1_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab2_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab2_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab3_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab3_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab4_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000"));
                    ListViewMenu__tab4_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000"));
                    ListViewMenu__tab5_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab5_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab6_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab6_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    break;
                case 4:
                    ListViewMenu__tab1_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab1_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab2_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab2_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab3_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab3_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab4_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab4_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab5_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000"));
                    ListViewMenu__tab5_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000"));
                    ListViewMenu__tab6_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab6_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    break;
                case 5:
                    ListViewMenu__tab1_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab1_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab2_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab2_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab3_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab3_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab4_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab4_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab5_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab5_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b6b8ba"));
                    ListViewMenu__tab6_icon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000"));
                    ListViewMenu__tab6_content.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000"));
                    break;
                default:
                    break;
            }
          
        }
    }
}
