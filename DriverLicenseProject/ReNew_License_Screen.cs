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
    public partial class ReNew_License_Screen : Form
    {
        private int OldLicenseID = 0,PersonID = 0,LicenseClassID=0 ,DriverID=0,NewLicenseID=0,LocalID=0,NewLocalID=0;
       private bool StatusOFShowLicense = true;


        public ReNew_License_Screen()
        {
            
            InitializeComponent();
        }
        private void find_License_Control1_GetPersonID(int obj)
        {

           PersonID = obj;
            lblShowLicenseHistory.Enabled = true;
        }

        private void find_License_Control1_SetIssueDesable(bool obj)
        {
            btnIssue.Enabled = obj;
        }

        private void ReNew_License_Screen_Load(object sender, EventArgs e)
        {
           
            lblApplicationDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblIssueDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
           
            lblCreatedBY.Text = clstrnsfer.CurrentUserNAme;
            lblApplicationFees.Text = ClsApplicationBU.GetFeesOFApplcaton(2).ToString() ;
        }

        private void lblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (StatusOFShowLicense)
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

        private void lblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            License_History_Screen frm = new License_History_Screen(PersonID);
            frm.Show();
        }

        private void find_License_Control1_GetRenewLicenseID(int obj)
        {

        }

        private void find_License_Control1_GetLocalID(int obj)
        {
            LocalID = obj;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     

        private void find_License_Control1_GetDriverID(int obj)
        {
            DriverID = obj;
          
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            ClsApplicationBU RenewApplication = new ClsApplicationBU(PersonID, DateTime.Now, 2, 3, DateTime.Now, Convert.ToDouble(lblApplicationFees.Text), clstrnsfer.CurrentUserid);
            RenewApplication.ClassLicense = LicenseClassID;
            RenewApplication.PassedTest = 3;
            if(RenewApplication.Save())
            {
                lblRenewApplicationID.Text = RenewApplication.ApplicationID.ToString();
                NewLocalID = RenewApplication.localapplicationID;
                ClsLicenseBU License = new ClsLicenseBU(RenewApplication.ApplicationID, DriverID, LicenseClassID, DateTime.Now, Convert.ToDateTime(lblReExpirationDate.Text), txtNotes.Text, RenewApplication.PaidFees, true, 2, clstrnsfer.CurrentUserid);
                if(License.Save()&&ClsLicenseBU.SetLicenseUnActiveORActive(OldLicenseID, false))
                {
                    lblRenewedLicenseID.Text=License.LicenseID.ToString();
                    MessageBox.Show($"Driving license renewed successfully .. New License ID = {License.LicenseID}");
                    StatusOFShowLicense = false;
                    btnIssue.Enabled = false;
                }

            }



        }

        private void find_License_Control1_getLicenseID(int obj)
        {
            OldLicenseID = obj;
            lblOldLicense.Text = OldLicenseID.ToString();
            int Validity = ClsLicenseBU.GetValidityOfLicenseByLicenseID(OldLicenseID);
            lblReExpirationDate.Text = DateTime.Now.AddYears(Validity).ToString("yyyy-MM-dd");           
            lblLicenseFees.Text = ClsLicenseBU.GetFeesOfLicenseBYLicenseID(OldLicenseID).ToString();
            lblTotalFees.Text = (Convert.ToDouble(lblApplicationFees.Text) + Convert.ToDouble(lblLicenseFees.Text)).ToString(); 
            LicenseClassID = ClsLicenseBU.GetLicenseClassBYLicenseID(OldLicenseID);
            lblShowLicenseInfo.Enabled = true;
            
        }
    }
}
