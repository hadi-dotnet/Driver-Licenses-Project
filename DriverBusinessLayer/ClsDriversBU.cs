using DriverAccsesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverBusinessLayer
{
    public class ClsDriversBU
    {
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
       public DateTime CreatedDate { get; set; }


        public ClsDriversBU(int personID,int CreatedBY,DateTime CreatedDate)
        {
            this.PersonID = personID;
            this.CreatedByUserID = CreatedBY;
            this.CreatedDate = CreatedDate;
        }

        public bool Save()
        {
            int drID=ClsDriversAC.AddDriver(PersonID, CreatedByUserID, CreatedDate);    
            if(drID!=-1)
            {
                this.DriverID = drID;
                return true;
            }
            return false;
        }

        public static DataTable GetAllDriversAndLicenseInformation(int localID)
        {
            return ClsDriversAC.GetAllDriversAndLicenseInformation(localID);
        }

        public static int GetDriverID(int personID)
        {
            return ClsDriversAC.GetDriverID(personID);
        }
        public static DataTable GetAllDrivers()
        {
            return ClsDriversAC.GetAllDrivers();
        }
        public static int IsDriverExest(int driverID)
        {
            return ClsDriversAC.IsDriverExest(driverID);
        }

    }
}
