using System;
using System.IO;

namespace Insert_values_between_date.Units
{
    public class WriteToFile
    {
        public void ExampleAsync(string str1, string str2, string str3)
        {
            string text = str1 + "," + str2 + "," + str3.Replace(",", ".");


            File.AppendAllText(@"c:\work\file.txt", text + Environment.NewLine);
        }

        public void WriteByLine(string str1)
        {
            File.AppendAllText(@"d:\work\new_file.csv", str1 + Environment.NewLine);
        }

        public void WriteByLineSql(string str1)
        {
            File.AppendAllText(@"d:\work\sql\sql_file.sql", str1 + Environment.NewLine);
        }
    }
}
