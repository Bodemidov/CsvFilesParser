using Insert_values_between_date.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Insert_values_between_date.Units
{
    class ReadFile
    {
        public List<TempDateTime> GetPersons(string filepath)
        {
            var dictionaryTest = new List<TempDateTime>();

            using (var reader = new StreamReader(filepath))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    dictionaryTest.Add(new TempDateTime
                    {
                        date = DateTime.Parse(values[0].Replace("\"", "")),
                        time = DateTime.Parse(values[1].Replace("\"", "")),
                        tempValue = values[2].Replace("\"", "")
                    });
                }

            }
            return dictionaryTest;
        }

        public List<Gases> GetGases(string filepath)
        {
            var dictionaryTest = new List<Gases>();

            using (var reader = new StreamReader(filepath))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    dictionaryTest.Add(new Gases
                    {
                        datetime = DateTime.Parse(values[0]),
                        h2 = values[1],
                        o2 = values[2],
                        ch4 = values[3],
                        co = values[4],
                        c2h4 = values[5],
                        c2h6 = values[6],
                        c2h2 = values[7],
                        co2 = values[8],
                        n2 = values[9],
                        Toil = values[10],
                    });
                }

            }
            return dictionaryTest;
        }

        public List<Powers> GetPowers(string filepath)
        {
            var dictionaryTest = new List<Powers>();

            using (var reader = new StreamReader(filepath))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    dictionaryTest.Add(new Powers
                    {
                        datetime = DateTime.Parse(values[0]),
                        p = values[1],
                        q = values[2],
                        s = values[3],
                        i_pa = values[4],
                        i_pb = values[5],
                        i_pc = values[6],
                    });
                }

            }
            return dictionaryTest;
        }
    }
}
