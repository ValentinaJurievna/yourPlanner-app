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
using yourPlanner.Model;

namespace yourPlanner
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public static Authorization authorization { get; set; }
        public Authorization()
        {
            InitializeComponent();
            PlannerDataBaseContext aut = PlannerDataBaseContext.GetPlannerBaseContext();
            //aut.Database.Delete();
            aut.Database.Initialize(false);
            StaticFrame.Frame = frame;
            authorization = this;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_signIn_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new mainPage());
        }

        private void textBox_gotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (textbox.Name == "login_textBox" && textbox.Text == "Login") textbox.Text = "";
            if (textbox.Name == "password_textBox" && textbox.Text == "Password") textbox.Text = "";
            if (textbox.Name == "name_textBox" && textbox.Text == "Name") textbox.Text = "";
            if (textbox.Name == "email_textBox" && textbox.Text == "Email") textbox.Text = "";
            if (textbox.Name == "loginSignUp_textBox" && textbox.Text == "Login") textbox.Text = "";
            if (textbox.Name == "passwordSignUp_textBox" && textbox.Text == "Password") textbox.Text = "";
            if (textbox.Name == "confirmPassword_textBox" && textbox.Text == "Confirm password") textbox.Text = "";
        }

        private void textBox_lostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (textbox.Name == "login_textBox" && textbox.Text == "") textbox.Text = "Login";
            if (textbox.Name == "password_textBox" && textbox.Text == "") textbox.Text = "Password";
            if (textbox.Name == "name_textBox" && textbox.Text == "") textbox.Text = "Name";
            if (textbox.Name == "email_textBox" && textbox.Text == "") textbox.Text = "Email";
            if (textbox.Name == "loginSignUp_textBox" && textbox.Text == "") textbox.Text = "Login";
            if (textbox.Name == "passwordSignUp_textBox" && textbox.Text == "") textbox.Text = "Password";
            if (textbox.Name == "confirmPassword_textBox" && textbox.Text == "") textbox.Text = "Confirm password";
        }

        

        //private void Enter_click(object sender, RoutedEventArgs e)
        //{
        //    frame.Navigate(new mainPage());
        //}
    }
}
