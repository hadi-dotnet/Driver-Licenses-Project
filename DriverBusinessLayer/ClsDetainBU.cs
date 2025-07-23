using DriverAccsesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverBusinessLayer
{
    public class ClsDetainBU
    {
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public double FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleaseApplicationID { get; set; }

        public ClsDetainBU(int LicenseID, DateTime DetainDate ,double FineFees,int CreatedByUserID,bool IsReleased)
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            

        }

        public bool Save()
        {
            int Did = ClsDetainAC.AddDetain(LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased);
            if(Did !=-1)
            {
                DetainID = Did;
                return true;
            }
            return false;
        }

        public static bool IsDenaited(int LicenseID)
        {
            return ClsDetainAC.Isdetain(LicenseID);
        }

        public static bool IsDetainedBYNationalNOAndLocalID(int LocalID,string NationalNO)
        {
            return ClsDetainAC.IsDetainedBYNationalNOAndLocalID(LocalID, NationalNO);
        }

        public static DataTable GetDetainDateAndFeesAndIDBYLicenseID(int LicenseID)
        {
            return ClsDetainAC.GetDetainDateAndFeesAndIDBYLicenseID(LicenseID);
        }

        public static bool UpdateDetain(int DetainID, DateTime ReleaseDate,int ReleaseBYuserID,int ReleaseApplicationID,bool Isrelese)
        {
            return ClsDetainAC.UpdateDetain(DetainID, ReleaseDate, ReleaseBYuserID, ReleaseApplicationID,Isrelese);
        }

        public static DataTable GetAllDetainLicense()
        {
            return ClsDetainAC.GetAllDetainLicense();
        }


    }
}
