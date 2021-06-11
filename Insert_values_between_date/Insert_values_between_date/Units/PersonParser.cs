using Insert_values_between_date.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Insert_values_between_date.Units
{
    public class PersonParser
    {
        public TempDateTime ParsePersonFromLine(string line)
        {
            var values = line.Split(',');
            return new TempDateTime
            {
                datetime = DateTime.Parse(values[0]),
                //time = DateTime.Parse(values[0]),
                tempValue = values[1]
            };
        }
    }
}
