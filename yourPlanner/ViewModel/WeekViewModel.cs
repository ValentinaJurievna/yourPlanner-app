using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using yourPlanner.Command;
using yourPlanner.DataBaseConnector;
using yourPlanner.Model;

namespace yourPlanner.ViewModel
{
    class WeekViewModel : BasicViewModel
    {
        User ThisUser;
        DailyPlansViewModel dailyPlansViewModel;

        private DateTime monday;
        public DateTime Monday
        {
            get
            {
                return monday;
            }
            set
            {
                monday = value;
                OnPropertyChanged("Monday");
            }
        }

        private DateTime tuesday;
        public DateTime Tuesday
        {
            get
            {
                return tuesday;
            }
            set
            {
                tuesday = value;
                OnPropertyChanged("Tuesday");
            }
        }

        private DateTime wednesday;
        public DateTime Wednesday
        {
            get
            {
                return wednesday;
            }
            set
            {
                wednesday = value;
                OnPropertyChanged("Wednesday");
            }
        }

        private DateTime thursday;
        public DateTime Thursday
        {
            get
            {
                return thursday;
            }
            set
            {
                thursday = value;
                OnPropertyChanged("Thursday");
            }
        }

        private DateTime friday;
        public DateTime Friday
        {
            get
            {
                return friday;
            }
            set
            {
                friday = value;
                OnPropertyChanged("Friday");
            }
        }

        private DateTime weekend;
        public DateTime Weekend
        {
            get
            {
                return weekend;
            }
            set
            {
                weekend = value;
                OnPropertyChanged("Weekend");
            }
        }


        private WeekPriority weekPriority;
        public WeekPriority WeekPriority
        {
            get
            {
                return weekPriority;
            }
            set
            {
                weekPriority = value;
                dataBase.SaveChanges();
                OnPropertyChanged("WeekPriority");
            }
        }

        private ObservableCollection<WeekPriority> weekPriorities;
        public ObservableCollection<WeekPriority> WeekPriorities 
        {
            get
            {
                return weekPriorities;
            }
            set
            {
                weekPriorities = value;
                
                OnPropertyChanged("WeekPriorities");
            }
        }


        PlannerDataBaseContext dataBase;
        public WeekViewModel()
        {
            dailyPlansViewModel = DailyPlansViewModel.DailyPlans;
            ThisUser = dailyPlansViewModel.ThisUser;
            WeekDateTime = DateTime.Now;
            mondayPlans = new ObservableCollection<DailyPlans>();
            tuesdayPlans = new ObservableCollection<DailyPlans>();
            wednesdayPlans = new ObservableCollection<DailyPlans>();
            thursdayPlans = new ObservableCollection<DailyPlans>();
            fridayPlans = new ObservableCollection<DailyPlans>();
            weekendPlans = new ObservableCollection<DailyPlans>();

            dataBase = PlannerDataBaseContext.GetPlannerBaseContext();
            WeekPriorities = new ObservableCollection<WeekPriority>();
            foreach(WeekPriority wp in dataBase.WeekPriorities.Where(wp => wp.User.UserId == ThisUser.UserId))
            {
                WeekPriorities.Add(wp);
            }

            
            //WeekDateTime = WeekDateTime;
        }
        private DateTime weekDateTime;
        public DateTime WeekDateTime
        {
            get
            {
                return weekDateTime;
            }
            set
            {//dp.DateFrom.Value.Date.Equals(dateTime.Date)
                if (weekendPlans != null) {
                    
                    while (!value.DayOfWeek.Equals(DayOfWeek.Monday))
                    {
                        value =  value.AddDays(-1);
                    }
                    WeekPriority = WeekPriorities.Where(wp => wp.Monday.Date == value.Date).FirstOrDefault();
                    if (WeekPriority == null)
                    {
                        WeekPriority = new WeekPriority(ThisUser, value);
                        weekPriorities.Add(WeekPriority);
                        dataBase.WeekPriorities.Add(WeekPriority);
                        dataBase.SaveChanges();
                    }

                    FillWeek(value);
                   

                }
                weekDateTime = value;
                OnPropertyChanged("NewTaskDateTime");
            }
        }
        private void FillWeek(DateTime value)
        {
            Monday = value;
            mondayPlans.Clear();
            foreach (DailyPlans dp in dailyPlansViewModel.Plans
            .Where(p => p.DateFrom.Value.Date.Equals(value.Date)).AsEnumerable())
            {
                mondayPlans.Add(dp);
            }

            value =  value.AddDays(1);
            Tuesday = value;
            tuesdayPlans.Clear();
            foreach (DailyPlans dp in dailyPlansViewModel.Plans
            .Where(p => p.DateFrom.Value.Date.Equals(value.Date)).AsEnumerable())
            {
                tuesdayPlans.Add(dp);
            }

            value = value.AddDays(1);
            Wednesday = value;
            wednesdayPlans.Clear();
            foreach (DailyPlans dp in dailyPlansViewModel.Plans
            .Where(p => p.DateFrom.Value.Date.Equals(value.Date)).AsEnumerable())
            {
                wednesdayPlans.Add(dp);
            }

            value = value.AddDays(1);
            Thursday = value;
            thursdayPlans.Clear();
            foreach (DailyPlans dp in dailyPlansViewModel.Plans
            .Where(p => p.DateFrom.Value.Date.Equals(value.Date)).AsEnumerable())
            {
                thursdayPlans.Add(dp);
            }

            value = value.AddDays(1);
            Friday = value;
            fridayPlans.Clear();
            foreach (DailyPlans dp in dailyPlansViewModel.Plans
            .Where(p => p.DateFrom.Value.Date.Equals(value.Date)).AsEnumerable())
            {
                fridayPlans.Add(dp);
            }

            value = value.AddDays(1);
            Weekend = value;
            weekendPlans.Clear();
            foreach (DailyPlans dp in dailyPlansViewModel.Plans
            .Where(p => p.DateFrom.Value.Date.Equals(value.Date)).AsEnumerable())
            {
                weekendPlans.Add(dp);
            }
            value = value.AddDays(1);
            foreach (DailyPlans dp in dailyPlansViewModel.Plans
            .Where(p => p.DateFrom.Value.Date.Equals(value.Date)).AsEnumerable())
            {
                weekendPlans.Add(dp);
            }
        }
        

        private ObservableCollection<DailyPlans> mondayPlans;
        public ObservableCollection<DailyPlans> MondayPlans
        {
            get
            {
                return mondayPlans;
            }
            set
            {
                mondayPlans = value;
                OnPropertyChanged("MondayPlans");
            }
        }

        private ObservableCollection<DailyPlans> tuesdayPlans;
        public ObservableCollection<DailyPlans> TuesdayPlans
        {
            get
            {
                return tuesdayPlans;
            }
            set
            {
                tuesdayPlans = value;
                OnPropertyChanged("TuesdayPlans");
            }
        }

        private ObservableCollection<DailyPlans> wednesdayPlans;
        public ObservableCollection<DailyPlans> WednesdayPlans
        {
            get
            {
                return wednesdayPlans;
            }
            set
            {
                wednesdayPlans = value;
                OnPropertyChanged("WednesdayPlans");
            }
        }

        private ObservableCollection<DailyPlans> thursdayPlans;
        public ObservableCollection<DailyPlans> ThursdayPlans
        {
            get
            {
                return thursdayPlans;
            }
            set
            {
                thursdayPlans = value;
                OnPropertyChanged("ThursdayPlans");
            }
        }

        private ObservableCollection<DailyPlans> fridayPlans;
        public ObservableCollection<DailyPlans> FridayPlans
        {
            get
            {
                return fridayPlans;
            }
            set
            {
                fridayPlans = value;
                OnPropertyChanged("FridayPlans");
            }
        }

        private ObservableCollection<DailyPlans> weekendPlans;
        public ObservableCollection<DailyPlans> WeekendPlans
        {
            get
            {
                return weekendPlans;
            }
            set
            {
                weekendPlans = value;
                OnPropertyChanged("WeekendPlans");
            }
        }

    }
}
