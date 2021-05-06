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
        }

        private void OpenToDo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ListViewItem listViewItem = (ListViewItem)sender;
            if (listViewItem.Name == "toDoList")
            {
                fram.Navigate(new CreateNote());
            }
        }

    }
}
