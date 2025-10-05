using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealStateRentSystem
{

    class Monthes
    {
        private static int[] monthDay =
             new int[12] { 31, -1, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        private static DateTime fromDate;
        private static DateTime toDate;
        private static int year;
        private static int month;
        private static int day;


        public static int DateDifference(DateTime d1, DateTime d2)
        {

            fromDate = d1;
            toDate = d2;

            int increment = 0;
            if (fromDate.Day > toDate.Day)
            {
                increment = monthDay[fromDate.Month - 1];
            }


            if (increment != 0)
            {
                day = (toDate.Day + increment) - fromDate.Day;
                increment = 1;
            }
            else
            {
                day = toDate.Day - fromDate.Day;
            }


            if ((fromDate.Month + increment) > toDate.Month)
            {
                month = (toDate.Month + 12) - (fromDate.Month + increment);
                increment = 1;
            }
            else
            {
                month = (toDate.Month) - (fromDate.Month + increment);
                increment = 0;
            }


            year = toDate.Year - (fromDate.Year + increment);



            return month;
        }




    }
}

