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
    /// Логика взаимодействия для Year.xaml
    /// </summary>
    public partial class Year : Page
    {
        public Year()
        {
            InitializeComponent();
        }

        private void textBox_gotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (textbox.Name == "year_textBox" && textbox.Text == "Год") textbox.Text = "";
            if (textbox.Name == "addYearTask_textBox" && textbox.Text == "Цель на год") textbox.Text = "";
        }

        private void textBox_lostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (textbox.Name == "year_textBox" && textbox.Text == "") textbox.Text = "Год";
            if (textbox.Name == "addYearTask_textBox" && textbox.Text == "") textbox.Text = "Цель на год";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (year_textBox.Text == "Год" || addYearTask_textBox.Text == "Цель на год")
            {
                MessageBox.Show("Заполните поля");
            }
        }
    }
}
