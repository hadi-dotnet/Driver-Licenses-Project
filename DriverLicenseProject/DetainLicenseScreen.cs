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
    public partial class DetainLicenseScreen : Form
    {
        private int LicenseID = 0, LocalID = 0,PersonID=0;
        public delegate void DataBackEventHandler();


        public event DataBackEventHandler DataBack;


        public DetainLicenseScreen()
        {
            InitializeComponent();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if(txtFineFees.Text=="")
            {
                MessageBox.Show("You Have TO Enter Fees","ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are You Sure", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClsDetainBU Detain = new ClsDetainBU(LicenseID, DateTime.Now, Convert.ToDouble(txtFineFees.Text), clstrnsfer.CurrentUserid, false);
                if (Detain.Save() && ClsLicenseBU.SetLicenseUnActiveORActive(LicenseID, false))
                {
                    lbldetainedID.Text = Detain.DetainID.ToString();
                    MessageBox.Show("License Detained Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    find_License_Control1.Instancetxtbox.Enabled = false;
                    find_License_Control1.InstannceBTN.Enabled = false;
                    btnDetain.Enabled = false;

                }
            }

        }

        private void DetainLicenseScreen_Load(object sender, EventArgs e)
        {
            lblcreatedby.Text = clstrnsfer.CurrentUserNAme.ToString();
            lbldetainDate.Text = DateTime.Now.ToString();
        }

        private void find_License_Control1_SetIssueDesable(bool obj)
        {
            btnDetain.Enabled = obj;    
        }

        private void find_License_Control1_getLicenseID(int obj)
        {
            LicenseID = obj;
            lblliencseID.Text = obj.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            License_History_Screen frm = new License_History_Screen(PersonID);
            frm.Show();
        }

        private void find_License_Control1_SetLinkLalbe(bool obj)
        {
            lblShowLicenseHistory.Enabled = obj;
            lblShowLicenseInfo.Enabled = obj;   
        }

        private void lblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLicenseScreen frm = new ShowLicenseScreen(LocalID);
            frm.Show();

        }

        private void DetainLicenseScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataBack?.Invoke();
        }

        private void find_License_Control1_GetPersonID(int obj)
        {
            PersonID = obj;
        }

        private void find_License_Control1_GetLocalID(int obj)
        {
            LocalID = obj;
        }
    }
}
