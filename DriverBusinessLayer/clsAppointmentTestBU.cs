using DriverAccsesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverBusinessLayer
{
    public class clsAppointmentTestBU
    {
        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }

        public clsAppointmentTestBU( int TestTypeID, int LocalDrivingLicenseApplicationID ,DateTime AppointmentDate,float PaidFees,int CreatedByUserID,bool IsLocked,int RetakeTestApplicationID)
        {
            this.TestAppointmentID = 0;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;

        }

        public bool Save()
        {
            return clsAppointmentTestAC.Save(TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees,CreatedByUserID,IsLocked, RetakeTestApplicationID);

        }

        public static DataTable getappointment(int localID,int typeid)
        {
            return clsAppointmentTestAC.getAppointment(localID,typeid);
        }
        public static string GetDateOfAppointment(int appointmentID)
        {
            return clsAppointmentTestAC.GetDateOfAppointment(appointmentID);
        }

      

        public static int GetFeesOfVisionTest()
        {
            return clsAppointmentTestAC.GetFeesOfVisionTest();
        }

        public static int GetFeesOfwritenTest()
        {
            return clsAppointmentTestAC.GetFeesOfwritenTest();
        }

        public static int GetFeesOfStreetTest()
        {
            return clsAppointmentTestAC.GetFeesOfwritenTest();
        }

        public static bool LockAppointment(int appointmentID)
        {
            return clsAppointmentTestAC.LockAppointment(appointmentID);
        }

        public static bool IsLockedBU(int appointmentID)
        {
            return clsAppointmentTestAC.IsLocked(appointmentID);
        }

        public static bool UpdatePassed(int localID,int PassedID)
        {
            return clsAppointmentTestAC.UpdatePassed(localID, PassedID);
        }

        public static bool CheckTestResult(int appointmentID)
        {
            return clsAppointmentTestAC.CheckTestResult(appointmentID);
        }

    }
}
