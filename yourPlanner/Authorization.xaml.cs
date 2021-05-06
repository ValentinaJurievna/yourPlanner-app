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
using yourPlanner.DataBaseConnector;

namespace yourPlanner
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
            PlannerDataBaseContext aut = PlannerDataBaseContext.GetPlannerBaseContext();
            //aut.Database.Delete();
            aut.Database.Initialize(false);
            StaticFrame.Frame = frame;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_signIn_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new mainPage());
        }
    }
}
