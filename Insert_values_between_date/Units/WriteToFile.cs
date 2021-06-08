using System;
using System.IO;

namespace Insert_values_between_date.Units
{
    class WriteToFile
    {
        public void ExampleAsync(string str1, string str2, string str3)
        {
            string text = str1 + "," + str2 + "," + str3.Replace(",", ".");


            File.AppendAllText(@"c:\work\file.txt", text + Environment.NewLine);
        }
    }
}
