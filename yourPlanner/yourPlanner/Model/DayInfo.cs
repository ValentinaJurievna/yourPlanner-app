using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;
using yourPlanner.ViewModel;

namespace yourPlanner.Model
{

    class DayInfo : BasicViewModel
    {

        public DayInfo()
        {

        }
        public long Id { get; set; }
        private User user;
        private DateTime? date;
        private string firstPriority;
        private string secondPriority;
        private string thirdPriority;
        private string firstPositiveEvent;
        private string secondPositiveEvent;
        private string thirdPositiveEvent;

        private StrokeCollection images;
        private byte[] imagesBytes;
        public byte[] ImagesBytes
        {
            get
            {
                return imagesBytes;
            }
            set
            {
                if (value != null)
                {
                    imagesBytes = value;
                    var ms = new MemoryStream(imagesBytes);
                    using (ms)
                    {
                        Images = new StrokeCollection(ms);
                    }
                }
                else
                {
                    Images = new StrokeCollection();

                }
                OnPropertyChanged(nameof(ImagesBytes));
            }
        }
        private int imageCount;
        [NotMapped]
        public StrokeCollection Images
        {
            get
            {
                return images;
            }
            set
            {

                //if(value.Count());
                var ms = new MemoryStream();
                using (ms)
                {
                    value.Save(ms);
                    ms.Position = 0;
                    imagesBytes = ms.ToArray();
                }
                images = value;
                OnPropertyChanged(nameof(Images));
            }
        }



        private StrokeCollection strokes;
        private byte[] strokesBytes;
        public byte[] StrokesBytes
        {
            get
            {
                return strokesBytes;
            }
            set
            {
                if (value != null)
                {
                    strokesBytes = value;
                    var ms = new MemoryStream(strokesBytes);
                    using (ms)
                    {
                        Strokes = new StrokeCollection(ms);
                    }
                }
                else
                {
                    Strokes = new StrokeCollection();

                }
                OnPropertyChanged(nameof(StrokesBytes));
            }
        }

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
        private int strokeCount;
        [NotMapped]
        public StrokeCollection Strokes
        {
            get
            {
                return strokes;
            }
            set
            {
                //if(value.Count());
                var ms = new MemoryStream();
                using (ms)
                {
                    value.Save(ms);
                    ms.Position = 0;
                    strokesBytes = ms.ToArray();
                }
                strokes = value;
                OnPropertyChanged(nameof(Strokes));
            }
        }
        //
        public DayInfo(DateTime date, User user)
        {
            this.User = user;
            this.DayInfoDate = date;
            firstPriority = "";
            secondPriority = "";
            thirdPriority = "";
            firstPositiveEvent = "";
            secondPositiveEvent = "";
            thirdPositiveEvent = "";
            strokes = new StrokeCollection();
            images = new StrokeCollection();
        }

        //public DayInfo(DateTime date, DayPriorities priorities, DayPriorities positiveEvents)
        //{
        //    this.date = date;
        //    this.priorities = priorities;
        //    this.positiveEvents = positiveEvents;
        //}

        public DateTime? DayInfoDate 
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                OnPropertyChanged(nameof(DayInfoDate));
            }
        }
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
        public string FirstPositiveEvent
        {
            get
            {
                return firstPositiveEvent;
            }
            set
            {
                firstPositiveEvent = value;
                OnPropertyChanged(nameof(FirstPositiveEvent));
            }
        }

        public string SecondPositiveEvent
        {
            get
            {
                return secondPositiveEvent;
            }
            set
            {
                secondPositiveEvent = value;
                OnPropertyChanged(nameof(SecondPositiveEvent));
            }
        }
        public string ThirdPositiveEvent
        {
            get
            {
                return thirdPositiveEvent;
            }
            set
            {
                thirdPositiveEvent = value;
                OnPropertyChanged(nameof(ThirdPositiveEvent));
            }
        }

    }
}
