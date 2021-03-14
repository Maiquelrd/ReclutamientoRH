using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_V_2.Helpers
{
    public static class Datefix
    {
        public static string FixDate(string s)
        {
            string sfix = string.Empty;
            try
            {
                string[] sub = s.Split('/', ' ');
                sfix = sub[1] + "/" + sub[0] + "/" + sub[2];
            }
            catch (Exception)
            {
                return s;
            }
            return sfix;
        }
    }
}
