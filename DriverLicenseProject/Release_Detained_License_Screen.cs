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
    public partial class Release_Detained_License_Screen : Form
    {
        
        int LiceseID = 0,PersonID =0,Localid = 0;
        public Release_Detained_License_Screen()
        {
            InitializeComponent();

        }

        public Release_Detained_License_Screen(int licenseID)
        {
            InitializeComponent();
            find_License_Control1.Instancetxtbox.Text = licenseID.ToString();
            find_License_Control1.InstannceBTN.Enabled = false;
            find_License_Control1.Instancetxtbox.Enabled = false;

        }

        public delegate void DataBackEventHandler();


        public event DataBackEventHandler DataBack;

        private void Release_Detained_License_Screen_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnRelease_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You Sure","Information",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                ClsApplicationBU Release = new ClsApplicationBU(PersonID, DateTime.Now, 5, 3, DateTime.Now, Convert.ToInt32(lblApplicatonFees.Text),clstrnsfer.CurrentUserid);
                if( Release.SaveWithoutLocal()!=-1)
                {
                    if (ClsDetainBU.UpdateDetain(Convert.ToInt32(lbldetainedID.Text), DateTime.Now, clstrnsfer.CurrentUserid, Release.ApplicationID, true) && ClsLicenseBU.SetLicenseUnActiveORActive(LiceseID, true))
                    {
                        lblApplicationID.Text = Release.ApplicationID.ToString();
                        BtnRelease.Enabled=false;
                        find_License_Control1.Instancetxtbox.Enabled=false;
                        find_License_Control1.InstannceBTN.Enabled=false;
                        MessageBox.Show("License Detain Has Been Successfully Cancelled", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }

            }
        }

        private void find_License_Control1_getLicenseID(int obj)
        {
            LiceseID = obj;
            lblApplicatonFees.Text = ClsApplicationBU.GetFeesOFApplcaton(5).ToString();
            DataTable Dt = ClsDetainBU.GetDetainDateAndFeesAndIDBYLicenseID(LiceseID);

            foreach(DataRow dr in Dt.Rows)
            {
                // DateTime DetainDate = Convert.ToDateTime(dr["DetainDate"]);
                lbldetainDate.Text = dr["DetainDate"].ToString();
                lblFineFees.Text = dr["FineFees"].ToString();
                lbldetainedID.Text = dr["DetainID"].ToString();
            }
 
            lblliencseID.Text = LiceseID.ToString();
            lblTotalFees.Text = ((Convert.ToDouble(lblApplicatonFees.Text)) + (Convert.ToDouble(lblFineFees.Text))).ToString();
            lblcreatedby.Text = clstrnsfer.CurrentUserNAme;
        }

        private void find_License_Control1_GetPersonID(int obj)
        {
            PersonID = obj;
        }

        private void Release_Detained_License_Screen_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataBack?.Invoke();
        }

        private void find_License_Control1_SetLinkLalbe(bool obj)
        {
            lblShowLicenseHistory.Enabled = obj;
            lblShowLicenseInfo.Enabled = obj;
        }

        private void lblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLicenseScreen frm = new ShowLicenseScreen(Localid);
            frm.Show();
        }

        private void lblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            License_History_Screen frm = new License_History_Screen(PersonID);
            frm.Show();
        }

        private void find_License_Control1_GetLocalID(int obj)
        {
            Localid = obj;
        }

        private void find_License_Control1_SetIssueDesable(bool obj)
        {
            BtnRelease.Enabled = obj;
        }
    }
}
