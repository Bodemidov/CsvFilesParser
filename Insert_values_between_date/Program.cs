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
            var wtf = new WriteToFile();
            var rf = new ReadFile();
            var uti = new Utitlities();







            var gases = rf.GetGases(@"D:\work\7x.csv");
            var powers = rf.GetPowers(@"D:\work\atx1.csv");

            var filledData = new GeneralParams();

            var correctDates = uti.GetDateTimeFourPace(powers.Select(p => p.datetime).ToList());

            for (int counter = 0; counter < correctDates.Count; counter++)
            {
                var aboveGas = GetAboveGas(gases, correctDates[counter]);

                var beloveGas = GetBeloveGas(gases, correctDates[counter]);

                filledData.datetime = correctDates[counter];
                filledData.Pa_HV = powers.Where(p => correctDates[counter] == p.datetime).Select(x => x.Pa_HV).First();
                filledData.Qa_HV = powers.Where(q => correctDates[counter] == q.datetime).Select(x => x.Qa_HV).First();
                filledData.Sa_HV = powers.Where(s => correctDates[counter] == s.datetime).Select(x => x.Sa_HV).First();
                filledData.Ia_HV = powers.Where(p => correctDates[counter] == p.datetime).Select(x => x.Ia_HV).First();
                filledData.Ib_HV = powers.Where(p => correctDates[counter] == p.datetime).Select(x => x.Ib_HV).First();
                filledData.Ic_HV = powers.Where(p => correctDates[counter] == p.datetime).Select(x => x.Ic_HV).First();

                filledData.h2 = li.Linear(2, 1, 3, aboveGas.h2, beloveGas.h2).ToString(); 
                filledData.o2 = li.Linear(2, 1, 3, aboveGas.o2, beloveGas.o2).ToString(); 
                filledData.ch4 = li.Linear(2, 1, 3, aboveGas.ch4, beloveGas.ch4).ToString(); 
                filledData.co = li.Linear(2, 1, 3, aboveGas.co, beloveGas.co).ToString(); 
                filledData.c2h4 = li.Linear(2, 1, 3, aboveGas.c2h4, beloveGas.c2h4).ToString(); 
                filledData.c2h6 = li.Linear(2, 1, 3, aboveGas.c2h6, beloveGas.c2h6).ToString(); 
                filledData.c2h2 = li.Linear(2, 1, 3, aboveGas.c2h2, beloveGas.c2h2).ToString(); 
                filledData.co2 = li.Linear(2, 1, 3, aboveGas.co2, beloveGas.co2).ToString(); 
                filledData.n2 = li.Linear(2, 1, 3, aboveGas.n2, beloveGas.n2).ToString();
                //filledData.Toil = li.Linear(2, 1, 3, aboveGas.Toil, beloveGas.Toil).ToString();

                /*filledData.Humidity = li.Linear(2, 1, 3, aboveGas.Humidity, beloveGas.Humidity).ToString();
                filledData.Moisture = li.Linear(2, 1, 3, aboveGas.Moisture, beloveGas.Moisture).ToString();
                filledData.OilTemp = li.Linear(2, 1, 3, aboveGas.OilTemp, beloveGas.OilTemp).ToString();*/

                wtf.WriteByLine(filledData.ToString().Replace(",","."));
                Console.WriteLine(filledData.ToString());
            }
        }

        private static Gases GetBeloveGas(List<Gases> gas, DateTime correctDate)
        {
            var belowGas = gas.OrderBy(x => x.datetime).Where(p => p.datetime.TimeOfDay > correctDate.TimeOfDay && p.datetime.Date == correctDate.Date).FirstOrDefault();

            if (belowGas == null)
            {
                var tempGas = gas.Where(p => p.datetime.Date >= correctDate.Date)
                    .OrderBy(x => x.datetime)
                    .Take(8).ToList();

                belowGas = tempGas.Where(p => p.datetime.Date == correctDate.AddDays(1)).First();
            }

            return belowGas;
        }

        private static Gases GetAboveGas(List<Gases> gas, DateTime correctDate)
        {
            var aboveGas = gas.OrderByDescending(x => x.datetime).Where(p => p.datetime.TimeOfDay < correctDate.TimeOfDay && p.datetime.Date == correctDate.Date).FirstOrDefault();

            if (aboveGas == null)
            {
                var tempGas = gas.Where(p => p.datetime.Date <= correctDate.Date)
                    .OrderByDescending(x => x.datetime)
                    .Take(16).ToList();

                aboveGas = tempGas.Where(p => p.datetime.Date == correctDate.AddDays(-1)).First();
            }

            return aboveGas;
        }
    }
}
