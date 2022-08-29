using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Business.Helper
{
    public static class Check
    {
        internal static bool Checker(string str, string filter)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }
            return str.ToLower().Trim().Contains(filter.ToLower().Trim());
        }            
    }
}

