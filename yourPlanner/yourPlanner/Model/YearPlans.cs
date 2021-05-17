using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yourPlanner.ViewModel;

namespace yourPlanner.Model
{
    class YearPlans : BasicViewModel
    {
        public long Id { get; set; }
        public User User { get; set; }
        private string year;
        private string yearPlan;

        public string Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
                OnPropertyChanged("Year");

            }
        }

        public string YearPlan
        {
            get
            {
                return yearPlan;
            }
            set
            {
                yearPlan = value;
                OnPropertyChanged("YearPlan");

            }
        }

        public YearPlans()
        {

        }

        public YearPlans(string year, string yearPlan)
        {
            this.year = year;
            this.yearPlan = yearPlan;
        }
    }
}
