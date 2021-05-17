using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using yourPlanner.Command;
using yourPlanner.DataBaseConnector;
using yourPlanner.Model;

namespace yourPlanner.ViewModel
{
    class LoginPasswordViewModel : BasicViewModel
    {
        //public static LoginPasswordViewModel LoginPassword { get; private set; }
        //public User CurrentUser;
        //PlannerDataBaseContext dataBase;
        ////ObservableCollection<LoginPassword> loginPassword;

        //private LoginPassword loginpassword;
        //public LoginPassword Loginpassword
        //{
        //    get
        //    {
        //        return loginpassword;
        //    }
        //    set
        //    {
        //        loginpassword = value;
        //        dataBase.SaveChanges();
        //        NotifyPropertyChanged("Loginpassword");
        //    }
        //}

        //private ObservableCollection<LoginPassword> loginPasswords;
        //public ObservableCollection<LoginPassword> LoginPasswords
        //{
        //    get
        //    {
        //        return loginPasswords;
        //    }
        //    set
        //    {
        //        loginPasswords = value;

        //        NotifyPropertyChanged("LoginPasswords");
        //    }
        //}
        //public LoginPasswordViewModel()
        //{
        //    LoginPassword = this;
        //    CurrentUser = UserViewModel.GetUser();
        //    LoginPasswords = new ObservableCollection<LoginPassword>();

        //    dataBase = PlannerDataBaseContext.GetPlannerBaseContext();

        //    LoginPasswords = new ObservableCollection<LoginPassword>();
        //    foreach (LoginPassword lp in dataBase.LoginPasswords.Where(p => p.User.UserId == CurrentUser.UserId).AsEnumerable())
        //    {
        //        LoginPasswords.Add(lp);
        //    }
        //}
       public static LoginPasswordViewModel loginpassword { get; private set; }
        public User ThisUser;

        private RelayCommand saveSocial;
        public RelayCommand SaveSocial
        {
            get
            {
                return saveSocial ?? (saveSocial = new RelayCommand(action =>
                {
                    LoginPassword.SocialNetwork = LoginPassword.SocialNetwork;
                    MessageBox.Show("canvas saved");
                    dataBase.SaveChanges();
                }, func =>
                {
                    return true;
                }));
            }
        }

      

        PlannerDataBaseContext dataBase;
        private LoginPassword loginPassword;
        public LoginPassword LoginPassword
        {
            get
            {
                return loginPassword;
            }
            set
            {

                loginPassword = value;
                dataBase.SaveChanges();
                OnPropertyChanged("LoginPassword");
            }
        }

        private ObservableCollection<LoginPassword> loginPasswords;
        public ObservableCollection<LoginPassword> LoginPasswords
        {
            get
            {
                return loginPasswords;
            }
            set
            {

                loginPasswords = value;

                OnPropertyChanged("LoginPasswords");
            }
        }

       

        public LoginPasswordViewModel()
        {
            loginpassword = this;
            ThisUser = UserViewModel.GetUser();

            dataBase = PlannerDataBaseContext.GetPlannerBaseContext();

            
            //loginPassword = new LoginPassword("Name", "Email", "Login");
            LoginPasswords = new ObservableCollection<LoginPassword>();
            foreach (LoginPassword lp in dataBase.LoginPasswords.Where(lp => lp.User.UserId == ThisUser.UserId).AsEnumerable())
            {
                LoginPasswords.Add(lp);

                
            }

            LoginPassword = new LoginPassword(ThisUser);
            loginPasswords.Add(LoginPassword);
            dataBase.LoginPasswords.Add(LoginPassword);
            dataBase.SaveChanges();

        }

        



    }
}
