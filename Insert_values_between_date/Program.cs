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

            var filledData = new Powers();

            var correctDates = uti.GetDateTimeFourPace(powers.Select(p => p.datetime).ToList());

            for (int counter = 0; counter < correctDates.Count; counter++)
            {
                var aboveGas = GetAboveGas(gases, correctDates[counter]);

                var beloveGas = GetBeloveGas(gases, correctDates[counter]);

                filledData.datetime = correctDates[counter];
                filledData.p = powers.Where(p => correctDates[counter] == p.datetime).Select(x => x.p).First();
                filledData.q = powers.Where(q => correctDates[counter] == q.datetime).Select(x => x.q).First();
                filledData.s = powers.Where(s => correctDates[counter] == s.datetime).Select(x => x.s).First();
                filledData.i_pa = powers.Where(p => correctDates[counter] == p.datetime).Select(x => x.i_pa).First();
                filledData.i_pb = powers.Where(p => correctDates[counter] == p.datetime).Select(x => x.i_pb).First();
                filledData.i_pc = powers.Where(p => correctDates[counter] == p.datetime).Select(x => x.i_pc).First();

                filledData.h2 = li.Linear(2, 1, 3, Convert.ToDouble(aboveGas.h2.Replace(".",",")), Convert.ToDouble(beloveGas.h2.Replace(".", ","))).ToString(); 
                filledData.o2 = li.Linear(2, 1, 3, Convert.ToDouble(aboveGas.o2.Replace(".", ",")), Convert.ToDouble(beloveGas.o2.Replace(".", ","))).ToString(); 
                filledData.ch4 = li.Linear(2, 1, 3, Convert.ToDouble(aboveGas.ch4.Replace(".", ",")), Convert.ToDouble(beloveGas.ch4.Replace(".", ","))).ToString(); 
                filledData.co = li.Linear(2, 1, 3, Convert.ToDouble(aboveGas.co.Replace(".", ",")), Convert.ToDouble(beloveGas.co.Replace(".", ","))).ToString(); 
                filledData.c2h4 = li.Linear(2, 1, 3, Convert.ToDouble(aboveGas.c2h4.Replace(".", ",")), Convert.ToDouble(beloveGas.c2h4.Replace(".", ","))).ToString(); 
                filledData.c2h6 = li.Linear(2, 1, 3, Convert.ToDouble(aboveGas.c2h6.Replace(".", ",")), Convert.ToDouble(beloveGas.c2h6.Replace(".", ","))).ToString(); 
                filledData.c2h2 = li.Linear(2, 1, 3, Convert.ToDouble(aboveGas.c2h2.Replace(".", ",")), Convert.ToDouble(beloveGas.c2h2.Replace(".", ","))).ToString(); 
                filledData.co2 = li.Linear(2, 1, 3, Convert.ToDouble(aboveGas.co2.Replace(".", ",")), Convert.ToDouble(beloveGas.co2.Replace(".", ","))).ToString(); 
                filledData.n2 = li.Linear(2, 1, 3, Convert.ToDouble(aboveGas.n2.Replace(".", ",")), Convert.ToDouble(beloveGas.n2.Replace(".", ","))).ToString(); 
                filledData.Toil = li.Linear(2, 1, 3, Convert.ToDouble(aboveGas.Toil.Replace(".", ",")), Convert.ToDouble(beloveGas.Toil.Replace(".", ","))).ToString();

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

                belowGas = gas.Where(p => p.datetime.Date == correctDate.AddDays(1)).First();
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
                    .Take(8).ToList();

                aboveGas = gas.Where(p => p.datetime.Date == correctDate.AddDays(-1)).First();
            }

            return aboveGas;
        }
    }
}
