using RealStateSystem_DataAccess;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RealStateSystem_DataAccess.clsSettingsCallingData;

namespace RealStateRentSystem_Buisness
{
    public class clsSettingsCalling
    {
        public class UserPhoneInfo
        {
            public string UserName { get; set; }
            public string PhoneName { get; set; }
            public bool PhoneRestriction { get; set; }
        }
        public static void SaveSettings(string exportLink, string importLink, int interval)
        {
            clsSettingsCallingData.SaveOrUpdateSettings(exportLink, importLink, interval);
        }
        public static (string ExportLink, string ImportLink, int Interval, string publishing_rent, string publishing_sell, string publishing_attachment) LoadSettings()
        {
            return clsSettingsCallingData.GetSettings();
        }
        public static UserPhoneInfo GetUserByName(string userName)
        {
            var row = RealStateSystem_DataAccess.clsSettingsCallingData.GetUserByName(userName);
            if (row == null) return null;

            return new UserPhoneInfo
            {
                UserName = row.UserName,
                PhoneName = row.PhoneName,
                PhoneRestriction = row.PhoneRestriction
            };
        }
        public static List<UserPhoneInfo> GetAllUsers()
        {
            var rows = RealStateSystem_DataAccess.clsSettingsCallingData.GetAllUsers();
            var list = new List<UserPhoneInfo>();

            foreach (var row in rows)
            {
                list.Add(new UserPhoneInfo
                {
                    UserName = row.UserName,
                    PhoneName = row.PhoneName,
                    PhoneRestriction = row.PhoneRestriction
                });
            }

            return list;
        }

        public static string get_main_website_address()
        {
           return clsSettingsCallingData.get_main_website_address();
        }


    }
}
