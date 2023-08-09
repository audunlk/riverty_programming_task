using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.ConsoleApp.Operations.Validators
{
    public class CheckDateValidity
    {
        //can only go back to 1999
        //only till year 2022
        //month 1-12
        //day 1-31
        public static bool CheckDate(string date)
        {
            var dateArray = date.Split('-');
            

            if (!int.TryParse(dateArray[0], out int year) ||
            !int.TryParse(dateArray[1], out int month) ||
            !int.TryParse(dateArray[2], out int day))
            {
                return false; // Invalid integer values
            }
            //February case
            if (month == 2)
            {
                if (day > 28)
                {
                    return false;
                }
            }

            //April, June, September, November case
            if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                if (day > 30)
                {
                    return false;
                }
            }

            if (year < 1999 || year > 2022)
            {
                return false;
            }
            if (month < 1 || month > 12)
            {
                return false;
            }
            if (day < 1 || day > 31)
            {
                return false;
            }
            return true;
        }
    }
}
