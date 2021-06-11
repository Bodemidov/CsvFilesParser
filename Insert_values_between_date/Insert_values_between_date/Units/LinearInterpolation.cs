using System;

namespace Insert_values_between_date.Units
{
    class LinearInterpolation
    {
        public double Linear(double x, double x0, double x1, string y0, string y1)
        {
            if (y0 == "")
                y0 = "0";
            if (y1 == "")
                y1 = "0";

            if (y0 == null)
                y0 = "0";
            if (y1 == null)
                y1 = "0";

            if ((x1 - x0) == 0)
            {
                return (Convert.ToDouble(y0.Replace(".",",")) + Convert.ToDouble(y1.Replace(".", ","))) / 2;
            }
            return Convert.ToDouble(y0.Replace(".", ",")) + (x - x0) * (Convert.ToDouble(y1.Replace(".", ",")) - Convert.ToDouble(y0.Replace(".", ","))) / (x1 - x0);
        }
    }
}