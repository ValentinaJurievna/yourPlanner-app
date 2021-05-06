using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                //if (!isPlaceHolder) {
                //    if (value.Equals(""))
                //    {
                //        PlaceHolder.Name = DefaultUser.Name;
                //    }
                //    else
                //    {
                //        PlaceHolder.Name = "";
                //    }
                //    name = value;
                //}
                //else
                //{
                //    name = value;
                //}
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
