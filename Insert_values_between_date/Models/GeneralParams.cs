using System;
using System.Collections.Generic;
using System.Text;

namespace Insert_values_between_date.Models
{
    class GeneralParams : Gases
    {
        public string Pa_HV;
        public string Qa_HV;
        public string Sa_HV;
        public string Ia_HV;
        public string Ib_HV;
        public string Ic_HV;
        public string t_o_top_mes;
        public string t_o_bot_m;
        public string Humidity;
        public string Moisture;
        public string OilTemp;

        public override string ToString()
        {
            return
                datetime.Date.ToString("yyyy-MM-dd") + delimiter +
                datetime.ToString("HH:mm:ss") + delimiter +
                /*p + delimiter +
                q + delimiter +
                s + delimiter +
                i_pa + delimiter +
                i_pb + delimiter +
                i_pc + delimiter +

                ch4 + delimiter +
                co2 + delimiter +
                c2h4 + delimiter +
                c2h2 + delimiter +
                c2h6 + delimiter +
                h2 + delimiter +
                co + delimiter +
                
                
                o2 + delimiter +
                
                
                n2 + delimiter +
                /*Humidity + delimiter +
                Moisture + delimiter +
                OilTemp;*/
                t_o_bot_m;
        }
    }
}
