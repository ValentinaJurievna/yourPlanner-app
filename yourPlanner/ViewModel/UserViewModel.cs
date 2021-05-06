using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using yourPlanner.Command;
using yourPlanner.DataBaseConnector;
using yourPlanner.Model;

namespace yourPlanner.ViewModel
{
    class UserViewModel : BasicViewModel
    {
        private static User staticUser;
        public static User GetUser() { return staticUser; }
        private RelayCommand singinCommand;
        public RelayCommand SinginCommand
        {
            get
            {
                return singinCommand ?? (singinCommand = new RelayCommand(action =>
                {
                    
                    PlannerDataBaseContext db = PlannerDataBaseContext.GetPlannerBaseContext();
                    User tempUser = db.Users.Where(u => u.Login.Equals(User.Login)).FirstOrDefault();
                    if(tempUser is null)
                    {
                        MessageBox.Show("ne nashol natogo usera");
                    }
                    else
                    {
                        if (tempUser.Password.Equals(user.Password))
                        {
                            user = tempUser;
                            StaticFrame.Frame.Navigate(new mainPage());
                        }
                        else
                        {
                            MessageBox.Show("parol gg");
                        }

                    }

                    // zaletaem v kabinet 303-1


                }, func =>
                {
                    return true;
                }));
            }
        }
        private RelayCommand singupCommand;
        public RelayCommand SingupCommand
        {
            get
            {
                return singupCommand ?? (singupCommand = new RelayCommand(action =>
                {
                    // проверяешь валидность soma

                    //и в базу данных пытаешься записать 
                    // ищешь по имейлу если такого мейла нет то ок
                    PlannerDataBaseContext db = PlannerDataBaseContext.GetPlannerBaseContext();
                    if (db.Users.Where(u => u.Email.Equals(User.Email)).Count()  != 0)
                    {
                        MessageBox.Show("Email " + User.Email + " already taken");
                        throw new Exception("dsisdsdji");
                    }
                    else
                    {
                       
                        db.Users.Add(User);
                        MessageBox.Show(User.Name + " added");
                        db.SaveChanges();
                    }

                    // zaletaem v kabinet 303-1


                }, func =>
                {
                    return true;
                }));
            }
        }
        private string confirmPassword;
        public string ConfirmPassword {
            get
            {
                return confirmPassword;
            }
            set
            {
                confirmPassword = value;
                OnPropertyChanged("ConfirmPassword");
            }
        }

        private User user;
        public User User 
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                staticUser = user;
                OnPropertyChanged("User");
            }
        }
        public UserViewModel()
        {
            
            user = new User("Name", "Email", "Login", "Password");
            staticUser = user;
            //user.DefaultUser = new User("Name", "Email", "Login", "Password");
            //user.PlaceHolder = new User("Name", "Email", "Login", "Password");
            //user.PlaceHolder.isPlaceHolder = true;
            ConfirmPassword = "Password";
        }

    }
}
