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
using yourPlanner.DataBaseConnector;

namespace yourPlanner
{
    /// <summary>
    /// Логика взаимодействия для Day.xaml
    /// </summary>
    public partial class Day : Page
    {
        public Day()
        {
            InitializeComponent();

            mcolor = new ColorRGB();
            mcolor.red = 0;
            mcolor.green = 0;
            mcolor.blue = 0;
            this.selectedColor.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(mcolor.red, mcolor.green, mcolor.blue));
        }

        private void textBox_gotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (textbox.Name == "addTask_textBox" && textbox.Text == "Добавить новую задачу...") textbox.Text = "";
        }

        private void textBox_lostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (textbox.Name == "addTask_textBox" && textbox.Text == "") textbox.Text = "Добавить новую задачу...";
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            addTask_textBox.Text = "Добавить новую задачу...";
        }

        //private void openImage(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Filter =
        //        "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
        //    //openFileDialog.FilterIndex = 1;

        //    if (openFileDialog.ShowDialog() == true)
        //        img.Source = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Relative));

        //    //using (PlannerDataBaseContext db = new PlannerDataBaseContext())
        //    //{

        //    //    var p = db.DayInfo.FirstOrDefault();
        //    //    db.Entry(p).Reference("ImagesBytes").Load();
        //    //    Console.WriteLine($"{p.ImagesBytes}");

        //    //}

        //}




        public class ColorRGB
        {
            public byte red { get; set; }
            public byte green { get; set; }
            public byte blue { get; set; }
        }

        public ColorRGB mcolor { get; set; }

        public Color clr { get; set; }

        private void sld_Color_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as Slider;
            string crlName = slider.Name; //Определяем имя контрола, который покрутили
            double value = slider.Value; // Получаем значение контрола
                                         //В зависимости от выбранного контрола, меняем ту или иную компоненту и переводим ее в тип byte
            if (crlName.Equals("sld_RedColor"))
            {
                mcolor.red = Convert.ToByte(value);
            }
            if (crlName.Equals("sld_GreenColor"))
            {
                mcolor.green = Convert.ToByte(value);
            }
            if (crlName.Equals("sld_BlueColor"))
            {
                mcolor.blue = Convert.ToByte(value);
            }

            //Задаем значение переменной класса clr 
            clr = Color.FromRgb(mcolor.red, mcolor.green, mcolor.blue);
            //Устанавливаем фон для контрола Label 
            this.selectedColor.Background = new SolidColorBrush(Color.FromRgb(mcolor.red, mcolor.green, mcolor.blue));
            // Задаем цвет кисти для контрола InkCanvas
            this.canvakd.DefaultDrawingAttributes.Color = clr;
        }
    }
}
