using DriverBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverLicenseProject
{
    public partial class Issue_driving_license_screen : Form
    {
        private int localID = 0;

        public delegate void DataBackEventHandler();

        
        public event DataBackEventHandler DataBack;
        public Issue_driving_license_screen(int localID)
        {
            InitializeComponent();
            Applcation_Details_Control.ApplicatonID = localID;
            this.localID = localID;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            int personID = 0, ApplicationID = 0, ClassID = 0, ExpirationDate = 0;
            double ClassFees = 0;
            DataTable data = ClsDriversBU.GetAllDriversAndLicenseInformation(localID);

            foreach(DataRow row in data.Rows)
            {
                personID = Convert.ToInt32(row["PersonID"]);
                ApplicationID = Convert.ToInt32(row["applicationID"]);
                ClassID = Convert.ToInt32(row["classesID"]);
                ClassFees = Convert.ToDouble(row["ClassFees"]);
                ExpirationDate = Convert.ToInt16(row["DefaultValidityLength"]);
            }
            DateTime ExpirationDateLicense = DateTime.Now.AddYears(ExpirationDate);
            int DriverID=ClsDriversBU.GetDriverID(personID);

            if(DriverID == -1)
            {
                ClsDriversBU Driver = new ClsDriversBU(personID, clstrnsfer.CurrentUserid, DateTime.Now);
                if (Driver.Save())
                {
                
                    ClsLicenseBU License = new ClsLicenseBU(ApplicationID, Driver.DriverID, ClassID, DateTime.Now, ExpirationDateLicense, TxtNotes.Text, ClassFees, true, 1, clstrnsfer.CurrentUserid);
                    if(License.Save() && ClsApplicationBU.SetApplicationStatusComplete(localID))
                    {
                        MessageBox.Show($"Driving license issued successfully. LicenseID : {License.LicenseID}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                        MessageBox.Show("The operation failed.","ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                    MessageBox.Show("The operation failed.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                ClsLicenseBU License = new ClsLicenseBU(ApplicationID, DriverID, ClassID, DateTime.Now, ExpirationDateLicense, TxtNotes.Text, ClassFees, true, 1, clstrnsfer.CurrentUserid);
                if (License.Save() && ClsApplicationBU.SetApplicationStatusComplete(localID))
                {
                    MessageBox.Show($"Driving license issued successfully. LicenseID : {License.LicenseID}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                
                }
                else
                    MessageBox.Show("The operation failed.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Issue_driving_license_screen_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataBack?.Invoke();
        }
    }
}
