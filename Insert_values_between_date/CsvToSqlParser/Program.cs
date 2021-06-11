using Insert_values_between_date.Units;
using System;
using System.IO;

namespace CsvToSqlParser
{
    class Program
    {
        static void Main(string[] args)
        {

            if (File.Exists(@"d:\work\sql\sql_file.sql"))
            {
                File.Delete(@"d:\work\sql\sql_file.sql");
            }

            var wtf = new WriteToFile();
            var rf = new ReadFile();

            var dataSetMain = rf.GetParamsFromFile(@"D:\work\sql\file.csv");

            wtf.WriteByLineSql("INSERT INTO public.measurements");
            wtf.WriteByLineSql("(\"OPC-Label\", measuredate, value, status)");
            wtf.WriteByLineSql("VALUES");


            for (int counter = 0; counter < dataSetMain.Count; counter++)
            {
                if (dataSetMain[counter].t_o_top_mes == "")
                {
                    dataSetMain[counter].t_o_top_mes = "NULL";
                }
                wtf.WriteByLineSql("('ns=1;i=1.AT-2 TM8.Device5.СО2', '" + dataSetMain[counter].datetime + "', " + dataSetMain[counter].co2 + ", 1),");
                wtf.WriteByLineSql("('ns=1;i=1.AT-2 TM8.Device5.С2Н2', '" + dataSetMain[counter].datetime + "', " + dataSetMain[counter].c2h2 + ", 1),");
                wtf.WriteByLineSql("('ns=1;i=1.AT-2 TM8.Device5.Н2', '" + dataSetMain[counter].datetime + "', " + dataSetMain[counter].h2 + ", 1),");
                wtf.WriteByLineSql("('ns=1;i=1.AT-2 TM8.Device5.СН4', '" + dataSetMain[counter].datetime + "', " + dataSetMain[counter].ch4 + ", 1),");
                wtf.WriteByLineSql("('ns=1;i=1.AT-2 TM8.Device5.СО', '" + dataSetMain[counter].datetime + "', " + dataSetMain[counter].co + ", 1),");
                wtf.WriteByLineSql("('ns=1;i=1.AT-2 TM8.Device5.температура низ', '" + dataSetMain[counter].datetime + "', " + dataSetMain[counter].t_o_bot_m + ", 1),");
                wtf.WriteByLineSql("('ns=1;i=1.AT-2 TM8.Device5.температура верх', '" + dataSetMain[counter].datetime + "', " + dataSetMain[counter].t_o_top_mes + ", 1),");
                wtf.WriteByLineSql("('ns=1;i=1.IEC104CLIENT.104client.АТ-2 ток фаза А', '" + dataSetMain[counter].datetime + "', " + dataSetMain[counter].Ia_HV + ", 1),");
                wtf.WriteByLineSql("('ns=1;i=1.IEC104CLIENT.104client.АТ-2 ток фаза В', '" + dataSetMain[counter].datetime + "', " + dataSetMain[counter].Ib_HV + ", 1),");
                wtf.WriteByLineSql("('ns=1;i=1.IEC104CLIENT.104client.АТ-2 ток фаза С', '" + dataSetMain[counter].datetime + "', " + dataSetMain[counter].Ic_HV + ", 1),");
                wtf.WriteByLineSql("('ns=1;i=1.IEC104CLIENT.104client.АТ-2 мощность Активная', '" + dataSetMain[counter].datetime + "', " + dataSetMain[counter].Pa_HV + ", 1),");
                wtf.WriteByLineSql("('ns=1;i=1.IEC104CLIENT.104client.АТ-2 мощность Реактивная', '" + dataSetMain[counter].datetime + "', " + dataSetMain[counter].Qa_HV + ", 1),");
                wtf.WriteByLineSql("('ns=1;i=1.IEC104CLIENT.104client.АТ-2 мощность Полная', '" + dataSetMain[counter].datetime + "', " + dataSetMain[counter].Sa_HV + ", 1),");
                wtf.WriteByLineSql("('ns=1;i=1.IEC104CLIENT.104client.АТ-2 температура наружная', '" + dataSetMain[counter].datetime + "', " + dataSetMain[counter].t_a + ", 1),");
                wtf.WriteByLineSql("('ns=1;i=1.AT-2 TM8.Device5.С2Н4', '" + dataSetMain[counter].datetime + "', " + dataSetMain[counter].c2h4 + ", 1),");
                wtf.WriteByLineSql("('ns=1;i=1.AT-2 TM8.Device5.С2Н6', '" + dataSetMain[counter].datetime + "', " + dataSetMain[counter].c2h6 + ", 1),");
            }
        }
    }
}
