using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yourPlanner.ViewModel;

namespace yourPlanner.Model
{
    class LoginPassword : BasicViewModel
    {
        public LoginPassword()
        {

        }
        public LoginPassword(User user)
        {
            this.User = user;
            socialNetwork = "";
            socialLogin = "";
            socialPassword = "";
        }
        public LoginPassword(User user, string network, string login, string password)
        {
            this.User = user;
            this.socialNetwork = network;
            this.socialLogin = login;
            this.socialPassword = password;
        }
        public long Id { get; set; }
        public User User { get; set; }
        private string socialNetwork;
        private string socialLogin;
        private string socialPassword;

        public string SocialNetwork
        {
            get
            {
                return socialNetwork;
            }
            set
            {
                socialNetwork = value;
                OnPropertyChanged(nameof(SocialNetwork));
            }
        }

        public string SocialLogin
        {
            get
            {
                return socialLogin;
            }
            set
            {
                socialLogin = value;
                OnPropertyChanged(nameof(SocialLogin));
            }
        }
        public string SocialPassword
        {
            get
            {
                return socialPassword;
            }
            set
            {
                socialPassword = value;
                OnPropertyChanged(nameof(SocialPassword));
            }
        }

       

    }
}
