using DriverAccsesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverBusinessLayer
{
    public class ClsTakeTestBU
    {

        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }   
        public int CreatedByUserID { get; set; }

        public ClsTakeTestBU(int testapp,bool testresult , string notes , int createdbuuserid)
        {
            this.TestAppointmentID = testapp;
            this.TestResult = testresult;
            this.Notes = notes;
            this.CreatedByUserID = createdbuuserid;
        }
        public bool Save()
        {
            if (ClsTakeTestAC.AddTest(TestAppointmentID, TestResult, Notes, CreatedByUserID))
            {
                return true;

            }
            else
                return false;
        }

        public static DataTable GetAllTestsType()
        {
            return ClsTakeTestAC.GetAllTestsType();
        }
        public static bool updateFeesOFTestType(int ID,int Fees)
        {
            return ClsTakeTestAC.updateFeesOFTestType(ID, Fees);
        }

    }
}
