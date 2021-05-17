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
    class DailyPlansViewModel : INotifyPropertyChanged
    {
        public static DailyPlansViewModel DailyPlans { get; private set; }
        public string AddTaskStr { get; set; } = "Добавить новую задачу...";

        private DateTime newTaskDateTime;
        public DateTime NewTaskDateTime {
            get
            {
                return newTaskDateTime;
            }
            set
            {
                newTaskDateTime = value;
                if (dayInfos != null && newDayPlans != null){
                    
                    CurrentDayInfo = dayInfos
                        .Where(di => di.DayInfoDate.Value.Date.Equals(newTaskDateTime.Date))
                        .FirstOrDefault();
                    if (CurrentDayInfo == null)
                    {
                        CurrentDayInfo = new DayInfo(newTaskDateTime, ThisUser);
                        dataBase.DayInfo.Add(CurrentDayInfo);
                        dataBase.SaveChanges();
                    }
                    dayInfos.Add(CurrentDayInfo);
                    UpdateNewDayPlans(newTaskDateTime);
                }

                NotifyPropertyChanged("NewTaskDateTime");
            }
        }
        void UpdateThisDayPlans()
        {
            oneDayPlans.Clear();
            DateTime dateTime = DateTime.Now;
            foreach (DailyPlans dp in plans)
            {
                if (dp.DateFrom.Value.Date.Equals(dateTime.Date))
                {
                    oneDayPlans.Add(dp);
                }
            }
        }
        void UpdateNewDayPlans(DateTime dateTime)
        {
            newDayPlans.Clear();
            foreach (DailyPlans dp in plans)
            {
                if (dp.DateFrom.Value.Date.Equals(dateTime.Date))
                {
                    newDayPlans.Add(dp);
                }
            }
        }
        private RelayCommand canvasDeleteCommand;
        public RelayCommand CanvasDeleteCommand
        {
            get
            {
                return canvasDeleteCommand ?? (canvasDeleteCommand = new RelayCommand(action =>
                {
                    CurrentDayInfo.Strokes = new StrokeCollection();
                    MessageBox.Show("canvas deleted");
                    dataBase.SaveChanges();
                }, func =>
                {
                    return true;
                }));
            }
        }
        private RelayCommand canvasChangedCommand;
        public RelayCommand CanvasChangedCommand
        {
            get
            {
                return canvasChangedCommand ?? (canvasChangedCommand = new RelayCommand(action =>
                {
                    CurrentDayInfo.Strokes = CurrentDayInfo.Strokes;
                    MessageBox.Show("canvas saved");
                    dataBase.SaveChanges();
                }, func =>
                {
                    return true;
                }));
            }
        }

        private RelayCommand imageChangedCommand;
        public RelayCommand ImageChangedCommand
        {
            get
            {
                return imageChangedCommand ?? (imageChangedCommand = new RelayCommand(action =>
                {
                    CurrentDayInfo.Images = CurrentDayInfo.Images;
                    MessageBox.Show("image saved");
                    dataBase.SaveChanges();
                }, func =>
                {
                    return true;
                }));
            }
        }

        private RelayCommand deleteTaskCommand;
        public RelayCommand DeleteTaskCommand
        {
            get
            {
                return deleteTaskCommand ?? (deleteTaskCommand = new RelayCommand(action =>
                {
                    long id = (long)action;
                    dataBase.DailyPlans.Remove(dataBase.DailyPlans.Where(d => d.Id == id).FirstOrDefault());
                    dataBase.SaveChanges();
                    plans.Remove(plans.Where(d => d.Id == id).FirstOrDefault());
                    newDayPlans.Remove(newDayPlans.Where(d => d.Id == id).FirstOrDefault());
                    oneDayPlans.Remove(oneDayPlans.Where(d => d.Id == id).FirstOrDefault());

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
                NotifyPropertyChanged("newDayPlans");
            }
        }

        private RelayCommand addTaskCommand;
        public RelayCommand AddTaskCommand
        {
            get
            {
                return addTaskCommand ?? (addTaskCommand = new RelayCommand(action =>
                {
                    DailyPlans dp = new DailyPlans(DateTime.Now, AddTaskStr);
                    dp.User = ThisUser;
                    dataBase.DailyPlans.Add(dp);
                    dataBase.SaveChanges();
                    oneDayPlans.Add(dp);
                    plans.Add(dp);
                }, func =>
                {
                    return true;
                }));
            }
        }

        
        public User ThisUser;

        private DayInfo dayInfo;
        public DayInfo CurrentDayInfo
        {
            get
            {
                return dayInfo;
            }
            set
            {
               
                dayInfo = value;
                dataBase.SaveChanges();
               NotifyPropertyChanged("CurrentDayInfo");
            }
        }
        private RelayCommand addTaskNewDateCommand;
        public RelayCommand AddTaskNewDateCommand
        {
            get
            {
                return addTaskNewDateCommand ?? (addTaskNewDateCommand = new RelayCommand(action =>
                {
                    DailyPlans dayPlan = new DailyPlans(NewTaskDateTime, AddTaskStr);
                    dayPlan.User = ThisUser;
                    newDayPlans.Add(dayPlan);
                    oneDayPlans.Add(dayPlan);
                    plans.Add(dayPlan);
                    dataBase.DailyPlans.Add(dayPlan);
                    dataBase.SaveChanges();
                    if (NewTaskDateTime.Date.Equals(DateTime.Now))
                    {
                        UpdateThisDayPlans();
                    }
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
                NotifyPropertyChanged("oneDayPlans");
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
                NotifyPropertyChanged("Plans");
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
        PlannerDataBaseContext dataBase;

        ObservableCollection<DayInfo> dayInfos;
        public DailyPlansViewModel()
        {
            DailyPlans = this;
            ThisUser = UserViewModel.GetUser();
            NewTaskDateTime = DateTime.Now;
            oneDayPlans = new ObservableCollection<DailyPlans>();
            newDayPlans = new ObservableCollection<DailyPlans>();

            dataBase = PlannerDataBaseContext.GetPlannerBaseContext();

            dayInfos = new ObservableCollection<DayInfo>();
            foreach (DayInfo di in dataBase.DayInfo.Where(p => p.User.UserId == ThisUser.UserId).AsEnumerable())
            {
                dayInfos.Add(di);
            }
            plans = new ObservableCollection<DailyPlans>();
            foreach (DailyPlans dp in dataBase.DailyPlans.Where(p => p.User.UserId == ThisUser.UserId).AsEnumerable())
            {
                plans.Add(dp);
            }


            //dayInfos = new ObservableCollection<DayInfo>();
            //foreach (DayInfo di in dataBase.DayInfo.Where(p => p.User == null))
            //{
            //    dayInfos.Remove(di);
            //}

            //plans = new ObservableCollection<DailyPlans>();
            //foreach (DailyPlans dp in dataBase.DailyPlans.Where(p => p.User == null))
            //{
            //    plans.Remove(dp);
            //}


            foreach (DailyPlans dp in plans)
            {
                if (dp.DateFrom.Value.Date.Equals(DateTime.Today.Date))
                {
                    oneDayPlans.Add(dp);
                    newDayPlans.Add(dp);
                }
            }
            



        }

    }
}
