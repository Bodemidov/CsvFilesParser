using Insert_values_between_date.Models;
using Insert_values_between_date.Units;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Insert_values_between_date
{
    class Program
    {
        static void Main(string[] args)
        {
            var li = new LinearInterpolation();
            var personParser = new PersonParser();
            var wtf = new WriteToFile();
            var rf = new ReadFile();

            var dictionaryTest = rf.GetPersons(@"C:\work\TO.csv");

            for (int counter = 0; counter < dictionaryTest.Count; counter++)
            {
                var person = File.ReadLines(@"C:\work\Weather.csv").Skip(1)
                 .Select(personParser.ParsePersonFromLine)
                 .Where(p => p.date.Date == dictionaryTest[counter].date.Date)
                 .OrderByDescending(x => x.date).ToList();

                var aboveTemp = person.Where(p => p.time.TimeOfDay < dictionaryTest[counter].time.TimeOfDay).FirstOrDefault();

                if (aboveTemp == null)
                {
                    person = File.ReadLines(@"C:\work\Weather.csv").Skip(1)
                     .Select(personParser.ParsePersonFromLine)
                     .Where(p => p.date.Date <= dictionaryTest[counter].date.Date)
                     .OrderByDescending(x => x.date)
                     .Take(8).ToList();


                    aboveTemp = person.Where(p => p.date.Date == dictionaryTest[counter].date.AddDays(-1)).First();
                }


                var belowTemp = person.OrderBy(x => x.date).Where(p => p.time.TimeOfDay > dictionaryTest[counter].time.TimeOfDay && p.date.Date == dictionaryTest[counter].date.Date).FirstOrDefault();

                if (belowTemp == null)
                {
                    person = File.ReadLines(@"C:\work\Weather.csv").Skip(1)
                     .Select(personParser.ParsePersonFromLine)
                     .Where(p => p.date.Date >= dictionaryTest[counter].date.Date)
                     .OrderBy(x => x.date)
                     .Take(8).ToList();

                    //щас тута
                    belowTemp = person.Where(p => p.date.Date == dictionaryTest[counter].date.AddDays(1)).First();

                }


                double linear = 0;

                linear = li.Linear(2, 1, 3, Convert.ToDouble(aboveTemp.tempValue), Convert.ToDouble(belowTemp.tempValue));

                wtf.ExampleAsync(dictionaryTest[counter].date.Date.ToString("yyyy-MM-dd"), dictionaryTest[counter].time.ToString("HH:mm:ss"), linear.ToString("G17", CultureInfo.InvariantCulture));
            }
        }
    }
}
