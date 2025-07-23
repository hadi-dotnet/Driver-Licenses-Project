using DriverAccsesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverBusinessLayer
{
    public class clsInternationalLicenseBU
    {
        public int InternationalLicenseID { get; set; } 
        public int ApplicationID { get; set; } 
        public int DriverID { get; set; } 
        public int IssuedUsingLocalLicenseID { get; set; } 
        public DateTime IssueDate { get; set; } 
        public DateTime ExpirationDate { get; set; } 
        public bool IsActive { get; set; } 
        public int CreatedByUserID { get; set; } 

        public clsInternationalLicenseBU(int appID,int DriverID,int IssuedUseingLocalLicenseID,DateTime IssueDate,DateTime EXpirationDate,bool IsActive,int CreatedBYUserID)
        {
            this.ApplicationID = appID;
            this.DriverID = DriverID;   
            this.IssuedUsingLocalLicenseID = IssuedUseingLocalLicenseID;   
            this.IssueDate = IssueDate;
            this.ExpirationDate = EXpirationDate;
            this.IsActive =IsActive;
            this.CreatedByUserID= CreatedBYUserID;
        }

        public bool Save()
        {
            int interID = clsInternationalLicenseAC.AddInternationalLicense(ApplicationID,DriverID,IssuedUsingLocalLicenseID,IssueDate,ExpirationDate,IsActive,CreatedByUserID);
            if(interID!=-1)
            {
                this.InternationalLicenseID = interID;
                return true;
            }
            return false;
        }

        public static DataTable GetInternationalInfoBYInterNationalLicenseID(int InterID)
        {
            return clsInternationalLicenseAC.GetInternationalInfoBYInterNationalLicenseID(InterID);
        }

        public static DataTable GetAllInternationalLicense()
        {
            return clsInternationalLicenseAC.GetAllInternationalLicense();
        }

        public static DataTable GetInternationalLicenseOfPersonID(int PersonID)
        {
            return clsInternationalLicenseAC.GetInternationalLicenseOfPersonID((PersonID));
        }


    }
}
