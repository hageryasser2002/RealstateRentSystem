using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealStateRentSystem
{
    class GetDates
    {

        public static int DateDiffDays(DateTime startDate, DateTime endDate)
        {

            int yr = 0;
            int mth = 0;
            int days = 0;

            TimeSpan ts = new TimeSpan();
            ts = endDate.Subtract(startDate);
            yr = (ts.Days / 365);
            do
            {
                for (int i = 0; i <= 12; i++)
                {
                    if (endDate.Subtract(startDate.AddYears(yr).AddMonths(i)).Days > 0)
                    {
                        mth = i;
                    }
                    else
                    {
                        break;
                    }
                }

                if (mth > 12)
                    yr = yr + 1;
            }
            while (mth > 12);

            //            days = endDate.Subtract(startDate.AddYears(yr).AddMonths(mth)).Days;

            days = endDate.Subtract(startDate).Days;
            return (days);
        }

        public static int DateDiffMonuth(DateTime startDate, DateTime endDate)
        {

            int yr = 0;
            int mth = 0;
            int days = 0;
            
            TimeSpan ts = new TimeSpan();
            ts = endDate.Subtract(startDate);
            yr = (ts.Days + 365);
            do
            {
                for (int i = 0; i <= 12; i++)
                {
                    if (endDate.Subtract(startDate.AddYears(yr).AddMonths(i)).Days > 0)
                    {
                        mth++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (mth >= 12)
                    yr = yr + 1;
            } 
            while (mth > 12);
            days = endDate.Subtract(startDate.AddYears(yr).AddMonths(mth)).Days;
            return (mth);
        }

        public static int DateDiffYear(DateTime startDate, DateTime endDate)
        {

            int yr = 0;
            int mth = 0;
            int days = 0;

            TimeSpan ts = new TimeSpan();
            ts = endDate.Subtract(startDate);
            yr = (ts.Days / 365);
            do
            {
                for (int i = 0; i <= 12; i++)
                {
                    if (endDate.Subtract(startDate.AddYears(yr).AddMonths(i)).Days > 0)
                    {
                        mth = i;
                    }
                    else
                    {
                        break;
                    }
                }

                if (mth > 12)
                    yr = yr + 1;
            } while (mth > 12);
            days = endDate.Subtract(startDate.AddYears(yr).AddMonths(mth)).Days;
            return (yr);
        }

        public static string DateDiff(DateTime startDate, DateTime endDate)
        {
            string timeStr = string.Empty;
            int yr = 0;
            int mth = 0;
            int days = 0;

            TimeSpan ts = new TimeSpan();
            ts = endDate.Subtract(startDate);
            yr = (ts.Days / 365);
            do
            {
                for (int i = 0; i <= 12; i++)
                {
                    if (endDate.Subtract(startDate.AddYears(yr).AddMonths(i)).Days > 0)
                    {
                        mth = i;
                    }
                    else
                    {
                        break;
                    }
                }

                if (mth > 12)
                    yr = yr + 1;
            } while (mth > 12);

            days = endDate.Subtract(startDate.AddYears(yr).AddMonths(mth)).Days;

            if (yr > 0)
            {

                timeStr += yr.ToString();
                timeStr += "-";
            }

            if (mth > 0)
            {

                timeStr += mth.ToString();

                timeStr += "-";
            }

            if (days > 0)
            {

                timeStr += days.ToString();
                timeStr += "-";

            }

            return (timeStr);
        }
        public static DateTime GetEndDate(DateTime startDate, int period)
        {
            
            //            enddate.AddYears(startDate.Year).AddMonths(startDate.Month).AddDays(startDate.Day);
            startDate = startDate.AddMonths(period);
            return startDate;


        }
    }
}
