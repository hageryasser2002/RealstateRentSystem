using RealStateSystem_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStateRentSystem_Buisness
{
    public class clsBuildingType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public long ID { set; get; }
        public string Building_Type { set; get; }

        public clsBuildingType()
        {
            this.ID = 0;
            this.Building_Type = "";
            Mode = enMode.AddNew;
        }

        private clsBuildingType(long id, string building_Type)
        {
            this.ID = id;
            this.Building_Type = building_Type;
            Mode = enMode.Update;
        }

        private bool _AddNewBuildingType()
        {
            this.ID = clsBuildingTypeData.AddNewBuildingType(this.Building_Type);
            return (this.ID != 0);
        }

        private bool _UpdateBuildingType()
        {
            return clsBuildingTypeData.UpdateBuildingType(this.ID, this.Building_Type);
        }

        public static clsBuildingType Find(long id)
        {
            string building_Type = "";

            bool isFound = clsBuildingTypeData.GetBuildingTypeInfoByID(id, ref building_Type);

            if (isFound)
                return new clsBuildingType(id, building_Type);
            else
                return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewBuildingType())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateBuildingType();
            }
            return false;
        }

        public static DataTable GetAllBuildingTypes()
        {
            return clsBuildingTypeData.GetAllBuildingTypes();
        }

        public static bool DeleteBuildingType(long id)
        {
            return clsBuildingTypeData.DeleteBuildingType(id);
        }
    }
}
