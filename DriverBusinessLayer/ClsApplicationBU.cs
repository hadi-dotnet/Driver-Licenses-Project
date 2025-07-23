using DriverAccsesLayer;
using DriverLicenseProject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DriverBusinessLayer
{
    public class ClsApplicationBU
    {
        public int ApplicationID { set; get; }

        public int localapplicationID { get; set; }
        public int ApplicantPersonID { set; get; }
        public DateTime ApplicationDate { set; get; }
        public int ApplicationTypeID { set; get; }
        public byte ApplicationStatus { set; get; }
        public DateTime LastStatusDate { set; get; }
        public double PaidFees { set; get; }
        public int CreatedByUserID { set; get; }
        public int ClassLicense { set; get; }
        public byte PassedTest { set; get; }



        public ClsApplicationBU()
        {
            ApplicationID = 0;
            ApplicantPersonID = 0;
            ApplicationDate = DateTime.Now;
            ApplicationTypeID = 0;
            ApplicationStatus = 1;
            LastStatusDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = 0;
            ClassLicense = 0;
        }

        public ClsApplicationBU(int PersonID, DateTime appdate, int apptype, byte appstatus, DateTime laststatusdate, double fees, int byuserid)
        {
            this.ApplicantPersonID = PersonID;
            this.ApplicationDate = appdate;
            this.ApplicationTypeID = apptype;
            this.ApplicationStatus = appstatus;
            this.LastStatusDate = laststatusdate;
            this.PaidFees = fees;
            this.CreatedByUserID = byuserid;

        }

       
        public bool Save()
        {
            int appid = ClsApplicationAC.AddNewApplication(ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            if (appid != -1)
            {
                ApplicationID = appid;
                int localid = ClsDriverLicenseAC.AddlocaldrivingLicenseApplication(appid, ClassLicense, PassedTest);
                if (localid != -1)
                {
                    localapplicationID = localid;
                    return true;
                }
            }

            return false;
        }

        public int SaveWithoutLocal()
        {
            int appid = ClsApplicationAC.AddNewApplication(ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            if (appid != -1)
            {
                this.ApplicationID = appid;

                return appid;

            }
            return -1;

        }

        public static int GetPesrsonIDReatakeTest(int localID)
        {
            return ClsApplicationAC.GetPesrsonIDReatakeTest(localID);
        }

        public static DataTable getallaplication()
        {
            return ClsApplicationAC.getallapplication();
        }

        public static DataTable getallinformaion(int id)
        {
            return ClsApplicationAC.getfullinformaion(id);
        }

        public static bool CheckClassLicnse(int personID, int classid)
        {
            return ClsApplicationAC.CheckClassLicense(personID, classid);

        }
        public static DataTable getapplicationstatus(int personID)
        {
            return ClsApplicationAC.GetApplicationStatus(personID);
        }
       

        public static sbyte GetPassedTest(int localID)
        {
            return ClsApplicationAC.GetPassedTest(localID);
        }

        public static bool SetApplicationStatusComplete(int localID)
        {
            return ClsApplicationAC.SetApplicationStatusComplete(localID);
        }

        public static bool IsApplicationComplete(int LocalID)
        {
            return ClsApplicationAC.IsApplicationComplete(LocalID);
        }

        public static bool DeleteApplication(int LocalID)
        {
            return ClsApplicationAC.DeleteApplication(LocalID);
        }

        public static bool SetApplicationCancel(int LocalID)
        {
            return ClsApplicationAC.SetApplicationCancel(LocalID);
        }

        public static bool IsApplicationCanceled(int LocalID)
        {
            return ClsApplicationAC.IsApplicationCanceled(LocalID);
        }


        public static double GetFeesOFApplcaton(int ApplcationTypeID)
        {
            return ClsApplicationAC.GetFeesOFApplcaton(ApplcationTypeID);
        }

        public static int GetLocalIDByLicenselID(int LicenseID)
        {
            return ClsApplicationAC.GetLocalIDByLicenselID(LicenseID);
        }

        public static DataTable GetALlApplicationType()
        {
            return ClsApplicationAC.GetALlApplicationType();
        }


        public static bool UpdateFeesOfApplicationType(int fees,int ID)
        {
            return ClsApplicationAC.UpdateFeesOfApplicationType(fees,ID);
        }
     

      
    }

}
