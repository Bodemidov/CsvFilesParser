using Insert_values_between_date.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Insert_values_between_date.Units
{
    public class ReadFile
    {
        public List<TempDateTime> GetValueWithData(string filepath)
        {
            var dictionaryTest = new List<TempDateTime>();

            using (var reader = new StreamReader(filepath))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    //убираем ms
                    var dt = DateTime.ParseExact(values[0], "dd.MM.yyyy HH:mm:ss:fff", null);
                    values[0] = dt.ToString("dd.MM.yyyy HH:mm:ss");
                    
                    dictionaryTest.Add(new TempDateTime
                    {
                        
                        datetime = DateTime.Parse(values[0]),
                        //time = DateTime.Parse(values[1].Replace("\"", "")),
                        tempValue = values[1],
                        tempValue1 = values[2]
                        //tempValue2 = values[3]
                    });
                }

            }
            return dictionaryTest;
        }

        public List<GeneralParams> GetGases(string filepath)
        {
            var dictionaryTest = new List<GeneralParams>();

            using (var reader = new StreamReader(filepath))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    dictionaryTest.Add(new GeneralParams
                    {
                        datetime = DateTime.Parse(values[0]),
                        h2 = values[1],
                        o2 = values[2],
                        ch4 = values[3],
                        co = values[4],
                        c2h4 = values[5],
                        c2h6 = values[6],
                        c2h2 = values[7],
                        co2 = values[8]
                        /*n2 = values[9],
                        t_o_top_mes = values[10],
                        t_o_bot_m = values[11],
                        Pa_HV = values[12],
                        Qa_HV = values[13],
                        Sa_HV = values[14],
                        Ia_HV = values[15],//
                        Ib_HV = values[16],
                        Ic_HV = values[17]*/
                    });
                }

            }
            return dictionaryTest;
        }

        public List<GeneralParams> GetGasesV3(string filepath)
        {
            var dictionaryTest = new List<GeneralParams>();

            using (var reader = new StreamReader(filepath))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    dictionaryTest.Add(new GeneralParams
                    {
                        datetime = DateTime.Parse(values[0]),
                        Pa_HV = values[1],
                        Qa_HV = values[2],
                        Sa_HV = values[3],
                        Ia_HV = values[4],//
                        Ib_HV = values[5],
                        Ic_HV = values[6],
                        h2 = values[7],
                        o2 = values[8],
                        ch4 = values[9],
                        co = values[10],
                        c2h4 = values[11],
                        c2h6 = values[12],
                        c2h2 = values[13],
                        co2 = values[14],
                        n2 = values[15],
                        t_o_bot_m = values[16]
                     
                    });
                }

            }
            return dictionaryTest;
        }


        public List<Gases> GetGasesV2(string filepath)
        {
            var dictionaryTest = new List<Gases>();

            using (var reader = new StreamReader(filepath))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    //убираем ms
                    var dt = DateTime.ParseExact(values[0], "dd.MM.yyyy HH:mm:ss:fff", null);
                    values[0] = dt.ToString("dd.MM.yyyy HH:mm:ss");

                    dictionaryTest.Add(new Gases
                    {
                        datetime = DateTime.Parse(values[0]),
                        h2 = values[1],
                        co = values[2],
                        co2 = values[3],
                        ch4 = values[4],
                        c2h2 = values[5],
                        c2h4 = values[6],
                        c2h6 = values[7]

//                        o2 = values[2],
//                        n2 = values[9],
                    });
                }

            }
            return dictionaryTest;
        }

        public List<GeneralParams> GetPowers(string filepath)
        {
            var dictionaryTest = new List<GeneralParams>();

            using (var reader = new StreamReader(filepath))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    dictionaryTest.Add(new GeneralParams
                    {
                        datetime = DateTime.Parse(values[0]),
                        Pa_HV = values[1],
                        Qa_HV = values[2],
                        Sa_HV = values[3],
                        Ia_HV = values[4],
                        Ib_HV = values[5],
                        Ic_HV = values[6],
                    });
                }

            }
            return dictionaryTest;
        }

        public List<GeneralParams> GetParamsFromFile(string filepath)
        {
            var dictionaryTest = new List<GeneralParams>();

            using (var reader = new StreamReader(filepath))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    dictionaryTest.Add(new GeneralParams
                    {
                        datetime = DateTime.Parse(values[0]),
                        h2 = values[1],
                        o2 = values[2],
                        ch4 = values[3],
                        co = values[4],
                        co2 = values[5],
                        c2h6 = values[6],
                        c2h4 = values[7],
                        c2h2 = values[8],
                        n2 = values[9],
                        humab_lq = values[10],
                        humrel_lq = values[11],
                        t_o_bot_m = values[12],
                        t_o_top_mes = values[13],
                        Pa_HV = values[14],
                        Qa_HV = values[15],
                        Sa_HV = values[16],
                        Ia_HV = values[17],//
                        Ib_HV = values[18],
                        Ic_HV = values[19],
                        t_a = values[20]
                    });
                }

            }
            return dictionaryTest;
        }
    }
}
