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
using System.Windows.Threading;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string password = "1";
        private DispatcherTimer dispatcherTimer;
        public MainWindow()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            InitializeComponent();
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btn_CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_SignIn(object sender, RoutedEventArgs e)
        {
            string pw = pwb_SignIn.Password.ToString();
            if (pw == password)
            {
                var window = new DashboardWindow();
                window.Show();
                this.Close();
            }
            else
            {
                angle_Error.Visibility = Visibility.Visible;
                content_Error.Visibility = Visibility.Visible;
                pwb_SignIn.Clear();
                dispatcherTimer.Start();
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            angle_Error.Visibility = Visibility.Collapsed;
            content_Error.Visibility = Visibility.Collapsed;
            dispatcherTimer.IsEnabled = false;
        }
    }

}

