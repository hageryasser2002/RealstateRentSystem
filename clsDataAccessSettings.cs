using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace RealStateSystem_DataAccess
{
    public class clsDataAccessSettings
    {

        ////    //public static string ConnectionString = "Server=.;Database=EmployeeSalarieSystem;User Id=sa;Password=sa123456;";
        ////private static readonly string DbFilePath = @"C:\Users\Lenovo\Desktop\Somer\db1\db1.accdb";
        //////System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mydatabase.db");

        //public static string DbFilePath;

        //public static string ConnectionString =>
        //  $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={DbFilePath};Persist Security Info=False;";

        public static string ConnectionString =>
        ConfigurationManager.ConnectionStrings["RealStateRentSystem.Properties.Settings.db1ConnectionString"].ConnectionString;

    }

}
