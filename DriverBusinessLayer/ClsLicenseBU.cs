using DriverAccsesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverBusinessLayer
{
    public class ClsLicenseBU
    {

        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public double PaidFees { get; set; }
        public bool IsActive { get; set; }
        public int IssueReason { get; set; }
        public int CreatedByUserID { get; set; }

        public ClsLicenseBU(int ApplicationID, int DriverID,int LicenseClass,DateTime IssueDate,DateTime ExpirationDate,string Notes,double PaidFees,bool IsActive,int IssueReason,int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID; 
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID= CreatedByUserID;

        }

        public bool Save()
        {
            int licenseID=ClsLicenseAC.AddLicense(ApplicationID, DriverID,LicenseClass,IssueDate,ExpirationDate,Notes,PaidFees,IsActive,IssueReason,CreatedByUserID);
            if(licenseID!=-1)
            {
                this.LicenseID = licenseID;
                return true;
            }
            return false;
        }

        public static DataTable GetLicenseInformation(int localID)
        {
            return ClsLicenseAC.GetLicenseInformation(localID);
        }

        public static DataTable GetLicenseByID(int licenseID)
        {
            return ClsLicenseAC.GetLicenseByID(licenseID);
        }

        public static DataTable GetLicenseBYPersonID(int personID)
        {
            return ClsLicenseAC.GetLicenseBYPersonID(personID);
        }

        public static int GetValidityOfLicenseByLicenseID(int licenseID)
        {
            return ClsLicenseAC.GetValidityOfLicenseByLicenseID(licenseID);
        }

        public static double GetFeesOfLicenseBYLicenseID(int licenseID)
        {
            return ClsLicenseAC.GetFeesOfLicenseBYLicenseID(licenseID);
        }

        public static int GetLicenseClassBYLicenseID(int LicenseID)
        {
            return ClsLicenseAC.GetLicenseClassBYLicenseID(LicenseID);
        }

        public static bool SetLicenseUnActiveORActive(int licenseID,bool StatusActive)
        {
            return ClsLicenseAC.SetLicenseUnActiveORActive(licenseID,StatusActive);
        }

        public static int GetLicenseIDBYDetainID(int DetainID)
        {
            return ClsLicenseAC.GetLicenseIDBYDetainID(DetainID);
        }


    }
}
