using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yourPlanner.Model;

namespace yourPlanner.ViewModel
{
    class WeekViewModel : BasicViewModel
    {
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
