using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.EventCalendar;
using yourPlanner.ViewModel;

namespace yourPlanner.Model
{
    class DailyPlans : BasicViewModel, ICalendarEvent
    {
        public long Id { get; set; }
        public User User { get; set; }
        private bool isDone;
        private DateTime? dateFrom;
        private DateTime? dateTo;
        private string label;

        public bool IsDone
        {
            get
            {
                return isDone;
            }
            set
            {
                isDone = value;
                //isDone = true;
                OnPropertyChanged("IsDone");
            }
        }
        public DateTime? DateFrom 
        {
            get
            {
                return dateFrom;
            }
            set
            {
                dateFrom = value;
                OnPropertyChanged("DateFrom");
            }
        }
        public DateTime? DateTo 
        {
            get
            {
                return dateTo;
            }
            set
            {
                dateTo = value;
                OnPropertyChanged("DateTo");

            }
        }
        public string Label {
            get
            {
                return label;
            }
            set
            {
                label = value;
                OnPropertyChanged("Label");

            }
        }
        public DailyPlans()
        {

        }

        public DailyPlans(DateTime? date, string label)
        {
            this.dateFrom = date;
            this.dateTo = date;
            this.label = label;
        }
    }
}
