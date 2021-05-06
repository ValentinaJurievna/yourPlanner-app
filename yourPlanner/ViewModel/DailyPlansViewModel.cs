using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using yourPlanner.Command;
using yourPlanner.DataBaseConnector;
using yourPlanner.Model;

namespace yourPlanner.ViewModel
{
    class DailyPlansViewModel : INotifyPropertyChanged
    {
        public string AddTaskStr { get; set; }

        public DateTime NewTaskDateTime { get; set; } = DateTime.Now;

        private RelayCommand deleteTaskCommand;
        public RelayCommand DeleteTaskCommand
        {
            get
            {
                return deleteTaskCommand ?? (deleteTaskCommand = new RelayCommand(action =>
                {
                   // удалить из бд элемент
                   // удалить из коллекции по айди
                     MessageBox.Show("sfsf");
                }, func =>
                {
                    return true;
                }));
            }
        }

        private ObservableCollection<DailyPlans> newDayPlans;
        public ObservableCollection<DailyPlans> NewDayPlans
        {
            get
            {
                return newDayPlans;
            }
            set
            {
                newDayPlans = value;
                NotifyPropertyChanged("Products");
            }
        }

        private RelayCommand addTaskCommand;
        public RelayCommand AddTaskCommand
        {
            get
            {
                return addTaskCommand ?? (addTaskCommand = new RelayCommand(action =>
                {
                    oneDayPlans.Add(new DailyPlans(DateTime.Now, DateTime.Now, AddTaskStr));
                }, func =>
                {
                    return true;
                }));
            }
        }
        private RelayCommand addTaskNewDateCommand;
        public RelayCommand AddTaskNewDateCommand
        {
            get
            {
                return addTaskNewDateCommand ?? (addTaskNewDateCommand = new RelayCommand(action =>
                {
                    PlannerDataBaseContext db = PlannerDataBaseContext.GetPlannerBaseContext();
                    DailyPlans dayPlan = new DailyPlans(NewTaskDateTime, NewTaskDateTime, AddTaskStr);
                    dayPlan.User = UserViewModel.GetUser();
                    newDayPlans.Add(dayPlan);
                    db.DailyPlans.Add(dayPlan);
                    db.SaveChanges();
                }, func =>
                {
                    return true;
                }));
            }
        }

        private ObservableCollection<DailyPlans> oneDayPlans;
        public ObservableCollection<DailyPlans> OneDayPlans
        {
            get
            {
                return oneDayPlans;
            }
            set
            {
                oneDayPlans = value;
                NotifyPropertyChanged("Products");
            }
        }

        private ObservableCollection<DailyPlans> plans;

        public ObservableCollection<DailyPlans> Plans
        {
            get
            {
                return plans;
            }
            set
            {
                plans = value;
                NotifyPropertyChanged("Products");
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

        public DailyPlansViewModel()
        {
            plans = new ObservableCollection<DailyPlans>
            {
                new DailyPlans(DateTime.Now, DateTime.Now, "Hochy sekc"),
                new DailyPlans(DateTime.Now, DateTime.Now, "Potom spat"),
                new DailyPlans(DateTime.Now, DateTime.Now, "Horosho"),
            };
            oneDayPlans = plans;
            newDayPlans = new ObservableCollection<DailyPlans>();
        }
    }
}
