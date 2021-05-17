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
    /// Логика взаимодействия для ToggleSwitchMode.xaml
    /// </summary>
    public partial class ToggleSwitchMode : UserControl
    {
        Thickness LeftSide = new Thickness(-59, 0, 0, 0);
        Thickness RightSide = new Thickness(0, 0, -59, 0);
        SolidColorBrush Off = new SolidColorBrush(Color.FromRgb(52, 85, 139));
        SolidColorBrush On = new SolidColorBrush(Color.FromRgb(231, 215, 185));
        private bool Toggled = false;
        public ToggleSwitchMode()
        {
            InitializeComponent();
            Back.Fill = Off;
            Toggled = false;
            Mode.Margin = LeftSide;
        }

        private void Mode_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            Uri uri = null;
            bool isTheme = false;

            if (!Toggled)
            {
                Back.Fill = On;
                Toggled = true;
                Mode.Margin = RightSide;
                Mode.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/img/light.png"));
                uri = new Uri("/Themes/Light.xaml", UriKind.Relative);
                isTheme = true;

            }
            else
            {
                Back.Fill = Off;
                Toggled = false;
                Mode.Margin = LeftSide;
                Mode.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/img/dark.png"));
                uri = new Uri("/Themes/Dark.xaml", UriKind.Relative);
                isTheme = true;
            }

            if (isTheme)
            {
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            }
        }

        private void Back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            Uri uri = null;
            bool isTheme = false;

            if (!Toggled)
            {
                Back.Fill = On;
                Toggled = true;
                Mode.Margin = RightSide;
                Mode.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/img/light.png"));
                uri = new Uri("/Themes/Light.xaml", UriKind.Relative);
                isTheme = true;

            }
            else
            {
                Back.Fill = Off;
                Toggled = false;
                Mode.Margin = LeftSide;
                Mode.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/img/dark.png"));
                uri = new Uri("/Themes/Dark.xaml", UriKind.Relative);
                isTheme = true;
            }

            if (isTheme)
            {
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            }
        }
    }
}
