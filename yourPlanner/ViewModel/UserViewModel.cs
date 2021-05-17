using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using yourPlanner.Command;
using yourPlanner.DataBaseConnector;
using yourPlanner.Model;

namespace yourPlanner.ViewModel
{
    class UserViewModel : BasicViewModel
    {
        public static UserViewModel StaticUserViewModel { get; set; }
        private static User staticUser;
        public static User GetUser() { return staticUser; }
        private RelayCommand singinCommand;
        public RelayCommand SinginCommand
        {
            get
            {
                return singinCommand ?? (singinCommand = new RelayCommand(action =>
                {

                    Windows.notificationWindow window = new Windows.notificationWindow();
                    
                    dataBase = PlannerDataBaseContext.GetPlannerBaseContext();
                    User tempUser = dataBase.Users.Where(u => u.Login.Equals(User.Login)).FirstOrDefault();

                    if (User.Password == "Password" || User.Login == "Login")
                    {
                        window.Show();
                        window.notificationTitle.Text = "Enter your login details";
                    }
                    else
                    {
                        if (tempUser is null)
                        {
                            window.Show();
                            window.notificationTitle.Text = User.Login + " not found";
                        }
                        else
                        {
                            if (tempUser.Password.Equals(user.Password))
                            {
                                user = tempUser;
                                staticUser = tempUser;
                                StaticFrame.Frame.Navigate(new mainPage());
                            }
                            else
                            {
                                window.Show();
                                window.notificationTitle.Text = "Wrong password";
                            }

                        }
                    }
                    

                }, func =>
                {
                    return true;
                }));
            }
        }
        PlannerDataBaseContext dataBase;
        private RelayCommand singupCommand;
        public RelayCommand SingupCommand
        {
            get
            {
                return singupCommand ?? (singupCommand = new RelayCommand(action =>
                {
                    // проверяешь валидность soma
                    string patternEmail = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
                    string patternName = @"^([a-zA-Z0-9А-Яа-я])+$";
                    string patternLogin = @"^(?=.{5,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$";
                    //содержит только буквы, подчеркивание и точку; 
                    //подчеркивание и точка не может быть рядом друг с другом;
                    //подчеркивание или точка не могут использоваться несколько раз в строке;
                    //количество символов должно быть от 5 до 20.
                    string patternPassword = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$";
                    //длина строки должна составлять от 8 до 15 символов
                    //строка должна содержать хотя бы одну цифру
                    //строка должна содержать хотя бы одну заглавную букву
                    //строка должна содержать хотя бы одну строчную букву
                    //строка должна содержать хотя бы один дополнительный символ
                    string name = User.Name;
                    string email = User.Email;
                    string login = User.Login;
                    string password = User.Password;

                    Windows.notificationWindow window = new Windows.notificationWindow();

                    if (User.Name == "Name" || User.Email == "Email" || User.Login == "Login" || User.Password == "Password" || ConfirmPassword == "Confirm password")
                    {
                        window.Show();
                        window.notificationText.Text = "Please fill in the fields!";
                    }
                    else
                    {
                        window.Show();

                        if (!Regex.IsMatch(name, patternName, RegexOptions.IgnoreCase))
                        {
                            window.Title = "Wrong name";
                            window.notificationText.Text = "Неправильный формат имени";
                        }

                        if (!Regex.IsMatch(email, patternEmail, RegexOptions.IgnoreCase))
                        {
                            //Authorization authorization = new Authorization();
                            //authorization.emailBorder.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));

                            window.Title = "Wrong email";
                            window.notificationText.Text = "Неправильный формат электронной почты";
                        }
                        if (!Regex.IsMatch(login, patternLogin, RegexOptions.IgnoreCase))
                        {
                            window.Title = "Wrong login";
                            window.notificationText.Text = "Неправильный формат логина \n " +
                                                            "Логин должен содержать \n " +
                                                            "- только буквы, подчеркивание и точку \n" +
                                                            "- подчеркивание и точка не могут быть рядом друг с другом \n" +
                                                            "- подчеркивание или точка не могут использоваться несколько раз в строке \n" +
                                                            "- количество символов должно быть от 8 до 20";

                        }
                        if (!Regex.IsMatch(password, patternPassword, RegexOptions.IgnoreCase))
                        {
                            window.Title = "Wrong password";
                            window.notificationText.Text = "Неправильный формат пароля \n " +
                                                            "Пароль должен соответствовать следующим требованиям \n " +
                                                            "- длина должна составлять от 8 до 15 символов \n" +
                                                            "- строка должна содержать хотя бы одну цифру \n" +
                                                            "- строка должна содержать хотя бы одну заглавную букву \n" +
                                                            "- строка должна содержать хотя бы одну строчную букву";
                        }
                        if ((User.Password != ConfirmPassword) && Regex.IsMatch(password, patternPassword, RegexOptions.IgnoreCase))
                        {
                            window.Title = "Passwords don't match";
                            window.notificationText.Text = "Пароли не совпадают";
                        }

                        if (dataBase.Users.Where(u => u.Email.Equals(User.Email)).Count() != 0)
                        {
                            window.notificationText.Text = "Email " + User.Email + " already taken";
                        }
                        if (dataBase.Users.Where(u => u.Login.Equals(User.Login)).Count() != 0)
                        {
                            window.notificationText.Text = "Login " + User.Login + " already taken";
                        }

                        if (Regex.IsMatch(name, patternName, RegexOptions.IgnoreCase) &&
                            Regex.IsMatch(email, patternEmail, RegexOptions.IgnoreCase) &&
                            Regex.IsMatch(login, patternLogin, RegexOptions.IgnoreCase) &&
                            Regex.IsMatch(password, patternPassword, RegexOptions.IgnoreCase) &&
                            User.Password == ConfirmPassword &&
                            dataBase.Users.Where(u => u.Email.Equals(User.Email)).Count() == 0 &&
                            dataBase.Users.Where(u => u.Login.Equals(User.Login)).Count() == 0)
                        {
                            dataBase.Users.Add(User);
                            window.notificationTitle.Text = User.Name + ", " + "регистрация прошла успешно!";
                            dataBase.SaveChanges();

                            //User.Name = "Name";
                            //User.Email = "Email";
                            //User.Login = "Login";
                            //User.Password = "Password";
                            //ConfirmPassword = "ConfirmPassword";
                        }

                    }
                    

                }, func =>
                {
                    return true;
                }));
            }
        }

        private void BackToAuthorizationWindow()
        {
            user = new User();
            staticUser = user;
            Authorization.authorization.Close();
            Authorization authorization = new Authorization();
            authorization.Show();
        }
        private RelayCommand logOutCommand;
        public RelayCommand LogOutCommand
        {
            get
            {
                return logOutCommand ?? (logOutCommand = new RelayCommand(action =>
                {
                    //StaticFrame.Frame.Navigate(new Authorization());
                    //System.Windows.Application.Current.Shutdown();

                    BackToAuthorizationWindow();

                }, func =>
                {
                    return true;
                }));
            }
        }

        private RelayCommand deleteProfileCommand;
        public RelayCommand DeleteProfileCommand
        {
            get
            {
                return deleteProfileCommand ?? (deleteProfileCommand = new RelayCommand(action =>
                {
                    //long id = (long)action;
                    dataBase.DailyPlans.RemoveRange(dataBase.DailyPlans.Where(p => p.User.UserId == staticUser.UserId));
                    dataBase.DayInfo.RemoveRange(dataBase.DayInfo.Where(p => p.User.UserId == staticUser.UserId));
                    dataBase.WeekPriorities.RemoveRange(dataBase.WeekPriorities.Where(p => p.User.UserId == staticUser.UserId));
                    dataBase.YearPlans.RemoveRange(dataBase.YearPlans.Where(p => p.User.UserId == staticUser.UserId));
                    dataBase.LoginPasswords.RemoveRange(dataBase.LoginPasswords.Where(p => p.User.UserId == staticUser.UserId));

                    dataBase.Users.Remove(dataBase.Users.Where(d => d.UserId == staticUser.UserId).FirstOrDefault());

                    dataBase.SaveChanges();
                    BackToAuthorizationWindow();
                    
                   
                    

                }, func =>
                {
                    return true;
                }));
            }
        }
        
        private RelayCommand editProfileCommand;
        public RelayCommand EditProfileCommand
        {
            get
            {
                return editProfileCommand ?? (editProfileCommand = new RelayCommand(action =>
                {
                    //long id = (long)action;

                    EditProfile editProfile = new EditProfile();
                    editProfile.Show();


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
        private object tabControl;

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
            StaticUserViewModel = this;
            dataBase = PlannerDataBaseContext.GetPlannerBaseContext();
            user = new User("Name", "Email", "Login", "Password");
            staticUser = user;
            //user.DefaultUser = new User("Name", "Email", "Login", "Password");
            //user.PlaceHolder = new User("Name", "Email", "Login", "Password");
            //user.PlaceHolder.isPlaceHolder = true;
            ConfirmPassword = "Confirm password";
        }

    }
}
