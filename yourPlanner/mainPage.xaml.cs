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

namespace yourPlanner
{
    /// <summary>
    /// Логика взаимодействия для mainPage.xaml
    /// </summary>
    public partial class mainPage : Page
    {

        public mainPage()
        {
            InitializeComponent();
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {

            // Set tooltip visibility
            if (toggle_Btn.IsChecked == true)
            {
                tt_home.Visibility = Visibility.Collapsed;
                tt_year.Visibility = Visibility.Collapsed;
                tt_month.Visibility = Visibility.Collapsed;
                tt_week.Visibility = Visibility.Collapsed;
                tt_day.Visibility = Visibility.Collapsed;
                tt_toDo.Visibility = Visibility.Collapsed;
                tt_passwords.Visibility = Visibility.Collapsed;
                tt_money.Visibility = Visibility.Collapsed;
                tt_settings.Visibility = Visibility.Collapsed;

            }
            else
            {
                tt_home.Visibility = Visibility.Visible;
                tt_year.Visibility = Visibility.Visible;
                tt_month.Visibility = Visibility.Visible;
                tt_week.Visibility = Visibility.Visible;
                tt_day.Visibility = Visibility.Visible;
                tt_toDo.Visibility = Visibility.Visible;
                tt_passwords.Visibility = Visibility.Visible;
                tt_money.Visibility = Visibility.Visible;
                tt_settings.Visibility = Visibility.Visible;
            }
           
        }

        private void ListViewItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ListViewItem listViewItem = (ListViewItem)sender;
            if (listViewItem.Name == "home")
            {
                frame.Navigate(new home());
                greeting.Opacity = 0;
            }
            if (listViewItem.Name == "year")
            {
                frame.Navigate(new Year());
                greeting.Opacity = 0;
            }
            if (listViewItem.Name == "month")
            {
                frame.Navigate(new Month());
                greeting.Opacity = 0;
            }
            if (listViewItem.Name == "week")
            {
                frame.Navigate(new Week());
                greeting.Opacity = 0;
            }
            if (listViewItem.Name == "passwords")
            {
                frame.Navigate(new Passwords());
                greeting.Opacity = 0;
            }
            if (listViewItem.Name == "money")
            {
                frame.Navigate(new Money());
                greeting.Opacity = 0;
            }
        }

        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            frame.Opacity = 1;
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            frame.Opacity = 0.3;
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            toggle_Btn.IsChecked = false;
        }


    }
}
