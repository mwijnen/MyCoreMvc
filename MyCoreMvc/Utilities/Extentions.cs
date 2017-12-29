using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreMvc.Utilities
{
    public static class Extentions
    {
        public static string Truncate(this string value, int maxLenth = 25)
        {
            //No need to truncate
            if (value == null || value.Length < maxLenth)
                return value;
                        
            //Not possible to truncate at space
            if (value.IndexOf(" ", maxLenth) == -1)
                return value.Substring(0, maxLenth) + "..." ;

            //Truncate after last full word
            return value.Substring(0, value.IndexOf(" ", maxLenth)) + " ...";
        }
    }
}
