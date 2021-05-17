using Microsoft.Win32;
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
    /// Логика взаимодействия для home.xaml
    /// </summary>
    public partial class home : Page
    {
        public home()
        {
            InitializeComponent();

            if (taskList.Items.Count == 0)
            {
                noTasks.Visibility = Visibility.Visible;
            }
            else
            {
                noTasks.Visibility = Visibility.Hidden;
            }
        }

        private void OpenToDo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //ListViewItem listViewItem = (ListViewItem)sender;
            //if (listViewItem.Name == "toDoList")
            //{
            //    miniFrame.Navigate(new CreateNote());
            //}
        }

        //private void openSettings(object sender, RoutedEventArgs e)
        //{
        //    miniFrame.Navigate(new Settings());
        //}

        private void textBox_gotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (textbox.Name == "addTodayTask_textBox" && textbox.Text == "Добавить новую задачу...") textbox.Text = "";
        }

        private void textBox_lostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (textbox.Name == "addTodayTask_textBox" && textbox.Text == "") textbox.Text = "Добавить новую задачу...";
        }

        private void addTask_Click(object sender, RoutedEventArgs e)
        {
            noTasks.Visibility = Visibility.Hidden;
            addTodayTask_textBox.Text = "Добавить новую задачу...";
        }
    }
}
