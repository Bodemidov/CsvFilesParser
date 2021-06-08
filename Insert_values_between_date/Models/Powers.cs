using System;
using System.Collections.Generic;
using System.Text;

namespace Insert_values_between_date.Models
{
    class Powers : Gases
    {
        public string p;
        public string q;
        public string s;
        public string i_pa;
        public string i_pb;
        public string i_pc;

        public override string ToString()
        {
            return 
                datetime + delimiter + 
                p + delimiter + 
                s + delimiter + 
                i_pa + delimiter + 
                i_pb + delimiter +
                i_pc + delimiter +
                
                h2 + delimiter +
                o2 + delimiter +
                ch4 + delimiter +
                co + delimiter +
                c2h4 + delimiter +
                c2h6 + delimiter +
                c2h2 + delimiter +
                co2 + delimiter +
                n2 + delimiter +
                Toil;
        }
    }
}
