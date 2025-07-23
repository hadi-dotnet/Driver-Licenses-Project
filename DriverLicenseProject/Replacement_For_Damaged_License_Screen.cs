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
    public partial class Replacement_For_Damaged_License_Screen : Form
    {
        public Replacement_For_Damaged_License_Screen()
        {
            InitializeComponent();
        }

        private int PersonID = 0, OldLicenseID = 0, NewLocalID=0, ReplaceID = 0,StatusOFReplacement=0,DriverID=0,LicenseClaasID=0,LocalID=0;
        private DateTime Exdate;
        private string Notes = "" ;
        private bool ShowLicenseInfoStatus = true;

        private void find_License_Control1_getLicenseID(int obj)
        {
            OldLicenseID = obj;
            lblOldLicense.Text = obj.ToString();
        }

        private void rdbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            StatusOFReplacement = 4;
        }

        private void find_License_Control1_GetLicenseClassID(int obj)
        {
            LicenseClaasID = obj;
        }

        private void find_License_Control1_GetPersonID(int obj)
        {
            PersonID = obj;
        }

        private void find_License_Control1_GetExDate(DateTime obj)
        {
            Exdate = obj;
        }

        private void find_License_Control1_GetNots(string obj)
        {
            Notes = obj;
        }

        private void lblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            License_History_Screen frm = new License_History_Screen(PersonID);
            frm.Show();
        }

        private void rdbDamageLicense_CheckedChanged(object sender, EventArgs e)
        {
            StatusOFReplacement = 3;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void find_License_Control1_SetLinkLalbe(bool obj)
        {
            lblShowLicenseHistory.Enabled=obj;
            lblShowLicenseInfo.Enabled=obj;
        }

        private void lblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ShowLicenseInfoStatus)
            {
                ShowLicenseScreen frm = new ShowLicenseScreen(LocalID);
                frm.Show();

            }
            else
            {
                ShowLicenseScreen frm = new ShowLicenseScreen(NewLocalID);
                frm.Show();

            }

        }

        private void find_License_Control1_GetLocalID(int obj)
        {
            LocalID = obj;
        }

        private void find_License_Control1_SetIssueDesable(bool obj)
        {
            btnIssue.Enabled = obj;
        }

        private void find_License_Control1_GetDriverID(int obj)
        {
            DriverID = obj;
        }

        private void Replacement_For_Damaged_License_Screen_Load(object sender, EventArgs e)
        {
            lblCreatedBY.Text = clstrnsfer.CurrentUserNAme;
            lblapplicationDate.Text = DateTime.Now.ToString();
            lblApplicationFees.Text = ClsApplicationBU.GetFeesOFApplcaton(4).ToString();
            rdbDamageLicense.Checked = true;
        }

   
        private void btnfind_Click(object sender, EventArgs e)
        {
            ClsApplicationBU Replace = new ClsApplicationBU(PersonID, DateTime.Now, StatusOFReplacement, 3, DateTime.Now, Convert.ToDouble(lblApplicationFees.Text), clstrnsfer.CurrentUserid);
            Replace.ClassLicense = LicenseClaasID;
           
            Replace.PassedTest = 3;
            if (Replace.Save())
            {
                lblRepalceApplication.Text = Replace.ApplicationID.ToString();
                 NewLocalID = Replace.localapplicationID;
                ShowLicenseInfoStatus = false;
                ClsLicenseBU License = new ClsLicenseBU(Replace.ApplicationID, DriverID, LicenseClaasID, DateTime.Now, Exdate,Notes, Replace.PaidFees, true, StatusOFReplacement, clstrnsfer.CurrentUserid);
                if (License.Save() && ClsLicenseBU.SetLicenseUnActiveORActive(OldLicenseID, false))
                {
                    lblReplaceLicenseID.Text = License.LicenseID.ToString();

                    if(StatusOFReplacement == 3) 
                         MessageBox.Show($"The driver's license was successfully reissued as a replacement for the damaged one. Whith ID = {License.LicenseID}","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                   else if (StatusOFReplacement == 4)
                         MessageBox.Show($"The driver's license was successfully reissued as a replacement for the Lost one.  Whith ID = {License.LicenseID}","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);

                    btnIssue.Enabled = false;
                }

            }

        }
    }
}
