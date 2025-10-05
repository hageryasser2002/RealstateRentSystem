using RealStateSystem_DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;

namespace RealStateRentSystem_Buisness
{
    public class clsUser
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Color { get; set; }
        //public bool IsLoggedIn { get; set; } // مضافة حديثًا لو احتجناها لاحقًا

        // 1. تسجيل الدخول
        public static clsUser Login(string username, string password)
        {
            DataRow row = clsUsersData.LoginUser(username, password);
            if (row == null)
                return null;

            return new clsUser
            {
                ID = Convert.ToInt32(row["ID"]),
                UserName = row["User_Name"].ToString(),
                Password = row["User_Password"].ToString(),
                Color = row["Color"].ToString(),
                //IsLoggedIn = Convert.ToBoolean(row["IsLoggedIn"]) // قد نحتاجها
            };
        }

        // 2. جلب كل المستخدمين النشطين
        public static List<clsUser> GetAllActiveUsers()
        {
            var rows = clsUsersData.GetAllActiveUsers();
            var users = new List<clsUser>();

            foreach (var row in rows)
            {
                users.Add(new clsUser
                {
                    ID = Convert.ToInt32(row["ID"]),
                    UserName = row["User_Name"].ToString(),
                    Password = row["User_Password"].ToString(),
                    Color = row["Color"].ToString(),
                    //IsLoggedIn = Convert.ToBoolean(row["IsLoggedIn"])
                });
            }

            return users;
        }

        //// 3. تسجيل خروج مستخدم
        //public static void Logout(string username)
        //{
        //    //clsUsersData.SetUserLoginStatus(username, false);
        //}

        // 4. تصفير حالة الدخول لكل المستخدمين
        //public static void ResetAllLoginStatus()
        //{
        //    //clsUsersData.ResetAllLoginStatus();
        //}

        public static List<clsUser> GetAdminUsers()
        {
            DataTable dt = clsUsersData.GetAdminUsers();
            List<clsUser> admins = new List<clsUser>();

            foreach (DataRow row in dt.Rows)
            {
                clsUser user = new clsUser
                {
                    ID = Convert.ToInt32(row["ID"]),
                    UserName = row["User_Name"].ToString(),
                    Password = row["User_Password"].ToString(),
                    Color = row["Color"].ToString(),
                    //IsLoggedIn = Convert.ToBoolean(row["IsLoggedIn"])
                };
                admins.Add(user);
            }

            return admins;
        }


    }
}
