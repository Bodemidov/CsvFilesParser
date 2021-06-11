using System;
using System.Collections.Generic;
using System.Text;

namespace Insert_values_between_date.Models
{
    public class GeneralParams : Gases
    {
        public string humab_lq;
        public string humrel_lq;
        public string t_a;
        public string Pa_HV;
        public string Qa_HV;
        public string Sa_HV;
        public string Ia_HV;
        public string t_o_bot_m;
        public string Ib_HV;
        public string Ic_HV;
        public string t_o_top_mes;
        public string Humidity;
        public string Moisture;
        public string OilTemp;

        /*public override string ToString()
        {
            return
                /*datetime.Date.ToString("yyyy-MM-dd") + delimiter +
                datetime.ToString("HH:mm:ss") + delimiter +
                datetime + delimiter +
                h2 + delimiter +
                o2 + delimiter +
                ch4 + delimiter +
                co + delimiter +
                c2h4 + delimiter +
                c2h2 + delimiter +
                c2h6 + delimiter +
                co2 + delimiter +
                n2 + delimiter +
                t_o_top_mes + delimiter +
                t_o_bot_m + delimiter +
                Pa_HV + delimiter +
                Qa_HV + delimiter +
                Sa_HV + delimiter +
                Ia_HV + delimiter +
                Ib_HV + delimiter +
                Ic_HV;
        }*/

        /*
         
         INSERT INTO public.measurements
        ("OPC-Label", measuredate, value, status)
        VALUES('', '', 0, 0);


        |id  |OPC-Label                  |measuredate        |value    |status|
|----|---------------------------|-------------------|---------|------|
|2352|ns=1;s=AT-1 7Х.Device1.С2Н2|2021-04-14 10:10:00|0.2247541|1     |
|2353|ns=1;s=AT-1 7Х.Device1.С2Н2|2021-04-14 07:10:00|0.2365833|1     |
|2354|ns=1;s=AT-1 7Х.Device1.С2Н2|2021-04-14 04:10:00|0.2253174|1     |
|2355|ns=1;s=AT-1 7Х.Device1.С2Н2|2021-04-14 01:10:00|0.2371762|1     |
|2356|ns=1;s=AT-1 7Х.Device1.С2Н2|2021-04-13 22:10:00|0.2258821|1     |
|2357|ns=1;s=AT-1 7Х.Device1.С2Н2|2021-04-13 19:10:00|0.2151258|1     |
|2358|ns=1;s=AT-1 7Х.Device1.С2Н2|2021-04-13 16:10:00|0.2048817|1     |
|2359|ns=1;s=AT-1 7Х.Device1.С2Н2|2021-04-13 13:10:00|0.1951255|1     |



         */


        public override string ToString()
        {
            return
                /*datetime.Date.ToString("yyyy-MM-dd") + delimiter +
                datetime.ToString("HH:mm:ss") + delimiter +*/
                datetime + delimiter +
                h2 + delimiter +
                o2 + delimiter +
                ch4 + delimiter +
                co + delimiter +
                c2h4 + delimiter +
                c2h2 + delimiter +
                c2h6 + delimiter +
                co2 + delimiter +
                n2 + delimiter +
                t_o_top_mes + delimiter +
                t_o_bot_m + delimiter +
                Pa_HV + delimiter +
                Qa_HV + delimiter +
                Sa_HV + delimiter +
                Ia_HV + delimiter +
                Ib_HV + delimiter +
                Ic_HV;
        }
    }
}
