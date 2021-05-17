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
    class YearPlansViewModel : INotifyPropertyChanged
    {
        public static YearPlansViewModel YearPlans { get; private set; }
        public string AddYearTaskStr { get; set; } = "Цель на год";
        public string YearStr { get; set; } = "Год";

        public User ThisUser;

        PlannerDataBaseContext dataBase;

        private ObservableCollection<YearPlans> newYearPlans;
        public ObservableCollection<YearPlans> NewYearPlans
        {
            get
            {
                return newYearPlans;
            }
            set
            {
                newYearPlans = value;
                NotifyPropertyChanged("NewYearPlans");
            }
        }

        private ObservableCollection<YearPlans> plansYear;

        public ObservableCollection<YearPlans> PlansYear
        {
            get
            {
                return plansYear;
            }
            set
            {
                plansYear = value;
                NotifyPropertyChanged("PlansYear");
            }
        }

        private RelayCommand addYearTaskCommand;
        public RelayCommand AddYearTaskCommand
        {
            get
            {
                return addYearTaskCommand ?? (addYearTaskCommand = new RelayCommand(action =>
                {
                    YearPlans yp = new YearPlans(YearStr, AddYearTaskStr);
                    if(AddYearTaskStr != "Цель на год" && YearStr != "Год")
                    {
                        yp.User = ThisUser;
                        dataBase.YearPlans.Add(yp);
                        dataBase.SaveChanges();
                        newYearPlans.Add(yp);
                    }
                    

                }, func =>
                {
                    return true;
                }));
            }
        }

        private RelayCommand deleteYearTaskCommand;
        public RelayCommand DeleteYearTaskCommand
        {
            get
            {
                return deleteYearTaskCommand ?? (deleteYearTaskCommand = new RelayCommand(action =>
                {
                    // удалить из бд элемент
                    // удалить из коллекции по айди
                    long id = (long)action;
                    dataBase.YearPlans.Remove(dataBase.YearPlans.Where(d => d.Id == id).FirstOrDefault());
                    dataBase.SaveChanges();
                    newYearPlans.Remove(newYearPlans.Where(d => d.Id == id).FirstOrDefault());

                    MessageBox.Show("deleted");
                }, func =>
                {
                    return true;
                }));
            }
        }

        public YearPlansViewModel()
        {
            YearPlans = this;
            ThisUser = UserViewModel.GetUser();
            newYearPlans = new ObservableCollection<YearPlans>();

            dataBase = PlannerDataBaseContext.GetPlannerBaseContext();

            //plansYear = new ObservableCollection<YearPlans>();
            foreach (YearPlans dp in dataBase.YearPlans.Where(p => p.User.UserId == ThisUser.UserId).AsEnumerable())
            {
                newYearPlans.Add(dp);
            }


        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
