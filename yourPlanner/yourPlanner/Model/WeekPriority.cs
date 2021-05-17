using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yourPlanner.ViewModel;

namespace yourPlanner.Model
{
    class WeekPriority : BasicViewModel
    {
        public WeekPriority()
        {

        }
        public WeekPriority(User user, DateTime date)
        {
            this.User = user;
            Monday = date;
            Tuesday = date;
            Wednesday = date;
            Thursday = date;
            Friday = date;
            Saturday = date;
            Sunday = date;
            firstPriority = "";
            secondPriority = "";
            thirdPriority = "";
        }
        public long id { get; set; }
        public User User { get; set; }

        private DateTime monday;
        public DateTime Monday
        {
            get
            {
                return monday;
            }
            set
            {
                monday = GetWeekStart(value);
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
                tuesday = GetTuesday(value);
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
                wednesday = GetWednesday(value);
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
                thursday = GetThursday(value);
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
                friday = GetFriday(value);
                OnPropertyChanged("Friday");
            }
        }

        private DateTime saturday;
        public DateTime Saturday
        {
            get
            {
                return saturday;
            }
            set
            {
                saturday = GetSaturday(value);
                OnPropertyChanged("Saturday");
            }
        }

        private DateTime sunday;
        public DateTime Sunday
        {
            get
            {
                return sunday;
            }
            set
            {
                sunday = GetSunday(value);
                OnPropertyChanged("Sunday");
            }
        }

        public DateTime GetWeekStart(DateTime date)
        {
            while (!date.DayOfWeek.Equals(DayOfWeek.Monday))
            {
                date = date.AddDays(-1);
            }
            return date;
        }

        public DateTime GetTuesday(DateTime date)
        {
            while (!date.DayOfWeek.Equals(DayOfWeek.Tuesday))
            {
                date = date.AddDays(1);
            }
            return date;
        }

        public DateTime GetWednesday(DateTime date)
        {
            while (!date.DayOfWeek.Equals(DayOfWeek.Wednesday))
            {
                date = date.AddDays(1);
            }
            return date;
        }

        public DateTime GetThursday(DateTime date)
        {
            while (!date.DayOfWeek.Equals(DayOfWeek.Thursday))
            {
                date = date.AddDays(1);
            }
            return date;
        }

        public DateTime GetFriday(DateTime date)
        {
            while (!date.DayOfWeek.Equals(DayOfWeek.Friday))
            {
                date = date.AddDays(1);
            }
            return date;
        }

        public DateTime GetSaturday(DateTime date)
        {
            while (!date.DayOfWeek.Equals(DayOfWeek.Saturday))
            {
                date = date.AddDays(1);
            }
            return date;
        }

        public DateTime GetSunday(DateTime date)
        {
            while (!date.DayOfWeek.Equals(DayOfWeek.Sunday))
            {
                date = date.AddDays(1);
            }
            return date;
        }


        private string firstPriority;
        private string secondPriority;
        private string thirdPriority;
        public string FirstPriority
        {
            get
            {
                return firstPriority;
            }
            set
            {
                firstPriority = value;
                OnPropertyChanged(nameof(FirstPriority));
            }
        }

        public string SecondPriority
        {
            get
            {
                return secondPriority;
            }
            set
            {
                secondPriority = value;
                OnPropertyChanged(nameof(SecondPriority));
            }
        }
        public string ThirdPriority
        {
            get
            {
                return thirdPriority;
            }
            set
            {
                thirdPriority = value;
                OnPropertyChanged(nameof(ThirdPriority));
            }
        }
    }
}
