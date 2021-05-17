using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using yourPlanner.Command;
using yourPlanner.DataBaseConnector;
using yourPlanner.Model;

namespace yourPlanner.ViewModel
{
    class EditProfileViewModel : BasicViewModel
    {
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
                OnPropertyChanged(nameof(User));
            }
        }

        private RelayCommand saveUserCommand;
        public RelayCommand SaveUserCommand
        {
            get
            {
                return saveUserCommand ?? (saveUserCommand = new RelayCommand(action =>
                {
                    PlannerDataBaseContext dataBase = PlannerDataBaseContext.GetPlannerBaseContext();
                    User editUser = dataBase.Users.Where(u => u.UserId == user.UserId).FirstOrDefault();
                    editUser = User;
                    UserViewModel.StaticUserViewModel.User = User;
                    dataBase.SaveChanges();
                }, func =>
                {
                    return true;
                }));
            }
        }
        public EditProfileViewModel()
        {
            this.User = UserViewModel.GetUser();
            //if(User.Image == null)
            //{
            //    user.Image = new Image();
            //}
        }
    }
}
