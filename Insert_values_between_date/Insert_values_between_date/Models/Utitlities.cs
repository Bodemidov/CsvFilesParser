using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insert_values_between_date.Models
{
    class Utitlities
    {
        public List<DateTime> GetDateTimeFourPace(List<DateTime> dt)
        {
            var correctDates = dt.Where(p => p.Hour == 0 ||
            p.Hour == 4 ||
            p.Hour == 8 ||
            p.Hour == 12 ||
            p.Hour == 16 ||
            p.Hour == 20).ToList(); ;

            return correctDates;
        }
    }
}
