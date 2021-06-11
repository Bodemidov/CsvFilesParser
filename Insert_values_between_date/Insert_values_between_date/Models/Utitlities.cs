using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insert_values_between_date.Models
{
    public class Utitlities
    {
        public List<DateTime> GetDateTimeFourPace(List<DateTime> dt)
        {
            var correctDates = dt.Where(p => p.Hour == 0 ||
            p.Hour == 4 ||
            p.Hour == 8 ||
            p.Hour == 12 ||
            p.Hour == 16 ||
            p.Hour == 20).ToList();

            return correctDates;
        }
        public List<GeneralParams> GetDateTimeFourPace(List<GeneralParams> dt)
        {
            var correctDates = dt.Where(p => p.datetime.Hour == 0 ||
            p.datetime.Hour == 4 ||
            p.datetime.Hour == 8 ||
            p.datetime.Hour == 12 ||
            p.datetime.Hour == 16 ||
            p.datetime.Hour == 20).ToList();

            return correctDates;
        }

        internal List<Gases> GetDateTimeFourPace(List<Gases> newPartData)
        {
            var correctDates = newPartData.Where(p => p.datetime.Hour == 0 ||
            p.datetime.Hour == 4 ||
            p.datetime.Hour == 8 ||
            p.datetime.Hour == 12 ||
            p.datetime.Hour == 16 ||
            p.datetime.Hour == 20).ToList();

            return correctDates;
        }

        internal List<TempDateTime> GetDateTimeFourPace(List<TempDateTime> newPartData)
        {
            var correctDates = newPartData.Where(p => p.datetime.Hour == 0 ||
            p.datetime.Hour == 4 ||
            p.datetime.Hour == 8 ||
            p.datetime.Hour == 12 ||
            p.datetime.Hour == 16 ||
            p.datetime.Hour == 20).ToList();

            return correctDates;
        }
    }
}
