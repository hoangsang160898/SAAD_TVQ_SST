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
    /// Interaction logic for ManageRolePage.xaml
    /// </summary>
    public partial class ManageRulePage : Page
    {
        Thickness LeftSide = new Thickness(-39, 0, 0, 0);
        Thickness RightSide = new Thickness(0, 0, -39, 0);
        SolidColorBrush Off = new SolidColorBrush(Color.FromRgb(160, 160, 160));
        SolidColorBrush On = new SolidColorBrush(Color.FromRgb(88, 212, 75));
        public ManageRulePage()
        {
            var controlRules = new List<int>();
            controlRules.Add(1);
            controlRules.Add(1);
            controlRules.Add(1);
            controlRules.Add(0);
            Global.ControlRules = controlRules;

            var rules = new List<double>();
            rules.Add(1);
            rules.Add(20);
            rules.Add(150);
            rules.Add(300);

            Global.Rules = rules;

            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (Global.ControlRules[0] == 1)
            {
                btnChangeRule1.Back.Fill = On;
                btnChangeRule1.Dot.Margin = RightSide;
            }
            if (Global.ControlRules[1] == 1)
            {
                btnChangeRule2.Back.Fill = On;
                btnChangeRule2.Dot.Margin = RightSide;
            }
            if (Global.ControlRules[2] == 1)
            {
                btnChangeRule3.Back.Fill = On;
                btnChangeRule3.Dot.Margin = RightSide;
            }
            if (Global.ControlRules[3] == 1)
            {
                btnChangeRule4.Back.Fill = On;
                btnChangeRule4.Dot.Margin = RightSide;
            }

            TextBox_MaxDebt.Text = Global.Rules[0].ToString();
            TextBox_MinExAfterBuying.Text = Global.Rules[1].ToString();
            TextBox_MaxAddBeforeSupplying.Text = Global.Rules[2].ToString();
            TextBox_MinExBeforeSupplying.Text = Global.Rules[3].ToString();

        }
        private void btnChangeRule1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (btnChangeRule1.isActived == true)
            {

            }
            else
            {

            }
        }
        private void btnChangeRule2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (btnChangeRule2.isActived == true)
            {
                MessageBox.Show("true 2");
            }
            else
            {
                MessageBox.Show("false 2");
            }
        }
        private void btnChangeRule3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (btnChangeRule3.isActived == true)
            {
                MessageBox.Show("true 3");
            }
            else
            {
                MessageBox.Show("false 3");
            }
        }
        private void btnChangeRule4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (btnChangeRule4.isActived == true)
            {
                MessageBox.Show("true 4");
            }
            else
            {
                MessageBox.Show("false 4");
            }
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            submit.Visibility = Visibility.Collapsed;
            cancel.Visibility = Visibility.Collapsed;
            edit.Visibility = Visibility.Visible;
            TextBox_MaxDebt.IsEnabled = false;
            TextBox_MinExAfterBuying.IsEnabled = false;
            TextBox_MaxAddBeforeSupplying.IsEnabled = false;
            TextBox_MinExBeforeSupplying.IsEnabled = false;
            btnChangeRule4.IsEnabled = false;
            btnChangeRule3.IsEnabled = false;
            btnChangeRule2.IsEnabled = false;
            btnChangeRule1.IsEnabled = false;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            submit.Visibility = Visibility.Collapsed;
            cancel.Visibility = Visibility.Collapsed;
            edit.Visibility = Visibility.Visible;
            TextBox_MaxDebt.IsEnabled = false;
            TextBox_MinExAfterBuying.IsEnabled = false;
            TextBox_MaxAddBeforeSupplying.IsEnabled = false;
            TextBox_MinExBeforeSupplying.IsEnabled = false;
            btnChangeRule4.IsEnabled = false;
            btnChangeRule3.IsEnabled = false;
            btnChangeRule2.IsEnabled = false;
            btnChangeRule1.IsEnabled = false;
            Page_Loaded(sender, e);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            submit.Visibility = Visibility.Visible;
            cancel.Visibility = Visibility.Visible;
            edit.Visibility = Visibility.Collapsed;
            TextBox_MaxDebt.IsEnabled = true;
            TextBox_MinExAfterBuying.IsEnabled = true;
            TextBox_MaxAddBeforeSupplying.IsEnabled = true;
            TextBox_MinExBeforeSupplying.IsEnabled = true;
            btnChangeRule4.IsEnabled = true;
            btnChangeRule3.IsEnabled = true;
            btnChangeRule2.IsEnabled = true;
            btnChangeRule1.IsEnabled = true;
        }

        private void TextBox_MaxDebt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBox_MinExAfterBuying_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBox_MaxAddBeforeSupplying_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBox_MinExBeforeSupplying_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
