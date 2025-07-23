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
    public partial class International_License_Screen : Form
    {
        public International_License_Screen()
        {
            InitializeComponent();
        }
        private int LicenseID = 0;
        private int PersonID = 0;
        private int DriverID = 0;
        private int InterLicenseID = 0;
        private int ClassLicenseID = 0;
        private bool StatusOFShowLicense=true;  

        private void International_License_Screen_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblInterIssueDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblInterExpirationDate.Text = DateTime.Now.AddYears(1).ToString("yyyy-MM-dd");
            lblCreatedBY.Text = clstrnsfer.CurrentUserNAme;
            lblInternationalApplicationFees.Text = ClsApplicationBU.GetFeesOFApplcaton(6).ToString() ;

        }

        private void find_License_Control1_getLicenseID(int obj)
        {
            LicenseID=obj;
            lblLocalLicense.Text=obj.ToString();
          
        }

        private void find_License_Control1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void find_License_Control1_SetIssueDesable(bool obj)
        {
            btnIssue.Enabled = obj;

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            ClsApplicationBU objapplication = new ClsApplicationBU();
            objapplication.ApplicantPersonID = PersonID;
            objapplication.ApplicationDate = DateTime.Now;
            objapplication.ApplicationTypeID = 6;
            objapplication.ApplicationStatus = 3;
            objapplication.LastStatusDate = DateTime.Now;
            objapplication.CreatedByUserID = clstrnsfer.CurrentUserid;
            objapplication.PaidFees=ClsApplicationBU.GetFeesOFApplcaton(6);
            objapplication.ClassLicense = ClassLicenseID;
            objapplication.PassedTest = 3;
            if(objapplication.Save())
            {
                lblInternationalApplication.Text = objapplication.ApplicationID.ToString();
                clsInternationalLicenseBU inter = new clsInternationalLicenseBU(objapplication.ApplicationID, DriverID, LicenseID, DateTime.Now, DateTime.Now.AddYears(1), true, clstrnsfer.CurrentUserid);
                if(inter.Save())
                {
                    lblInternationalLicense.Text = inter.InternationalLicenseID.ToString();
                    MessageBox.Show($"Issues International Driving License With ID = {inter.InternationalLicenseID}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblShowLicenseInfo.Enabled=true;
                    StatusOFShowLicense = true;
                    btnIssue.Enabled = false;
                }

            }
            
        }

        private void find_License_Control1_GetPersonID(int obj)
        {
            PersonID=obj;
            lblShowLicenseHistory.Enabled=true;
        
        }

        private void find_License_Control1_GetDriverID(int obj)
        {
            DriverID=obj;   
        
        }

        private void lblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(StatusOFShowLicense)
            {
                Show_International_License_Screen frm = new Show_International_License_Screen(Convert.ToInt32(lblInternationalLicense.Text));
                frm.Show();

            }
            else
            {
                Show_International_License_Screen frm = new Show_International_License_Screen(InterLicenseID);
                frm.Show();
            }
        }

        private void find_License_Control1_GetInterLicenseID(int obj)
        {
            InterLicenseID=obj;
            lblShowLicenseInfo.Enabled=true;
            StatusOFShowLicense = false;
        }

        private void find_License_Control1_SetLinkLalbe(bool obj)
        {
            lblShowLicenseInfo.Enabled = obj;
        }

        private void lblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            License_History_Screen frm = new License_History_Screen(PersonID);
            frm.Show();
        }

        private void find_License_Control1_GetLicenseClassID(int obj)
        {
            ClassLicenseID=obj;
        }
    }
}
