using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Insert_values_between_date
{
    class Program
    {
        class TempDateTime
        {
            public DateTime date;
            public DateTime time;
            public string tempValue;
        }


        static public double Linear(double x, double x0, double x1, double y0, double y1)
        {
            if ((x1 - x0) == 0)
            {
                return (y0 + y1) / 2;
            }
            return y0 + (x - x0) * (y1 - y0) / (x1 - x0);
        }

        public static void ExampleAsync(string str1, string str2, string str3)
        {
            string text = str1 + "," + str2 + "," + str3.Replace(",", ".");


                //str3.Replace(",",".");

            //20.891135344431017

            File.AppendAllText(@"c:\work\file.txt", text + Environment.NewLine);
        }

        private static TempDateTime ParsePersonFromLine(string line)
        {
            var values = line.Split(',');
            return new TempDateTime
            {
                date = DateTime.Parse(values[0]),
                time = DateTime.Parse(values[0]),
                tempValue = values[1]
            };
        }

        static void Main(string[] args)
        {
            var dictionaryTest = new List<TempDateTime>();

            using (var reader = new StreamReader(@"C:\work\TO.csv"))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    dictionaryTest.Add(new TempDateTime
                    {
                        date = DateTime.Parse(values[0].Replace("\"","")),
                        time = DateTime.Parse(values[1].Replace("\"", "")),
                        tempValue = values[2].Replace("\"","")
                    });
                }

            }

            for (int counter = 0; counter < dictionaryTest.Count; counter++)
            {
                var person = File.ReadLines(@"C:\work\Weather.csv").Skip(1)
                 .Select(ParsePersonFromLine)
                 .Where(p => p.date.Date == dictionaryTest[counter].date.Date)
                 .OrderByDescending(x => x.date).ToList();

                var aboveTemp = person.Where(p => p.time.TimeOfDay < dictionaryTest[counter].time.TimeOfDay).FirstOrDefault();

                if (aboveTemp == null)
                {
                    person = File.ReadLines(@"C:\work\Weather.csv").Skip(1)
                     .Select(ParsePersonFromLine)
                     .Where(p => p.date.Date <= dictionaryTest[counter].date.Date)
                     .OrderByDescending(x => x.date)
                     .Take(8).ToList();


                    aboveTemp = person.Where(p => p.date.Date == dictionaryTest[counter].date.AddDays(-1)).First();
                }


                var belowTemp = person.OrderBy(x => x.date).Where(p => p.time.TimeOfDay > dictionaryTest[counter].time.TimeOfDay && p.date.Date == dictionaryTest[counter].date.Date).FirstOrDefault();

                if (belowTemp == null)
                {
                    person = File.ReadLines(@"C:\work\Weather.csv").Skip(1)
                     .Select(ParsePersonFromLine)
                     .Where(p => p.date.Date >= dictionaryTest[counter].date.Date)
                     .OrderBy(x => x.date)
                     .Take(8).ToList();

                    //щас тута
                    belowTemp = person.Where(p => p.date.Date == dictionaryTest[counter].date.AddDays(1)).First();

                }


                double linear = 0;

                linear = Linear(2, 1, 3, Convert.ToDouble(aboveTemp.tempValue), Convert.ToDouble(belowTemp.tempValue));

                ExampleAsync(dictionaryTest[counter].date.Date.ToString("yyyy-MM-dd"), dictionaryTest[counter].time.ToString("HH:mm:ss"), linear.ToString("G17", CultureInfo.InvariantCulture));
            }
        }
    }
}
