using RealStateSystem_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStateRentSystem_Buisness
{
    public class clsRegion
    {
        public static long? GetRegionIDByName(string regionName)
        {
            return clsRegionData.GetRegionIDByName(regionName);
        }

        //public static string GetRegionNameByID(long regionID)
        //{
        //    return clsRegionData.GetRegionNameByID(regionID);
        //}

        public static string GetRegionNameByID(long regionID)
        {
            // تحويل آمن للنوع قبل الإرسال
            int safeRegionID = checked((int)regionID);
            return clsRegionData.GetRegionNameByID(safeRegionID);
        }
    }
}
