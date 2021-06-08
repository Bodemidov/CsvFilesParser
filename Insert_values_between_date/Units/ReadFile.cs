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
    }
}
