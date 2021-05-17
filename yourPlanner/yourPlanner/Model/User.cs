using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using yourPlanner.ViewModel;

namespace yourPlanner.Model
{
    class User : BasicViewModel
    {
        //public User DefaultUser { get; set; } 
        //public User PlaceHolder { get; set; }

        //public bool isPlaceHolder = false;
        public long UserId { get; set; }
        private string name;
        private string email;
        private string login;
        private string password;
        public string Name 
        {
            get
            {
                return name;
            }
            set {

                name = value;
                OnPropertyChanged("Name");
            } 
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public byte[] ImageByteArray
        {
            get
            {
                if (image != null)
                {
                    byte[] data;
                    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                    encoder.QualityLevel = 30;
                    encoder.Frames.Add(BitmapFrame.Create(image as BitmapImage));
                    using (MemoryStream ms = new MemoryStream())
                    {
                        encoder.Save(ms);
                        data = ms.ToArray();
                    }
                    return data;
                }
                return null;
            }
            set
            {
                if (value != null)
                {
                    using (var ms = new MemoryStream(value))
                    {
                        BitmapImage image = new BitmapImage();
                        image.BeginInit();
                        image.CacheOption = BitmapCacheOption.OnLoad; // here
                        image.StreamSource = ms;
                        image.EndInit();
                        Image = image;
                        OnPropertyChanged(nameof(Image));
                    }
                }
            }
        }

        private ImageSource image;
        [NotMapped]
        public ImageSource Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                OnPropertyChanged(nameof(Image));
            }
        }
        public User()
        {
        }

        public User(string name, string email, string login, string password)
        {
            this.name = name;
            this.email = email;
            this.login = login;
            this.password = password;
        }
    }
}
