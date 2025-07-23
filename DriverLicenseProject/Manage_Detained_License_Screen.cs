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
    public partial class Manage_Detained_License_Screen : Form
    {
        public Manage_Detained_License_Screen()
        {
            InitializeComponent();
        }
        private void  _FillDate()
        {
            DataTable dt = ClsDetainBU.GetAllDetainLicense();
            foreach(DataRow dr in dt.Rows)
            {
                string FullName = "",ApplcationID="",Releasedate="";

                if (dr["ReleaseDate"] != DBNull.Value)
                    Releasedate = dr["ReleaseDate"].ToString();
                else
                    Releasedate = "NULL";

                if (dr["ReleaseApplicationID"] != DBNull.Value)
                    ApplcationID = dr["ReleaseApplicationID"].ToString();
                else
                    ApplcationID = "NULL";


                if (dr["ThirdName"] == DBNull.Value)
                      FullName = dr["FirstName"].ToString() + " " + dr["SecondName"].ToString() + " " + dr["LastName"].ToString();
                else
                      FullName = dr["FirstName"].ToString() + " " + dr["SecondName"].ToString() + " " + dr["ThirdName"].ToString() + " " + dr["LastName"].ToString();


                dataGridView1.Rows.Add(dr["DetainID"].ToString(), dr["LicenseID"].ToString(), dr["DetainDate"].ToString(), dr["IsReleased"], dr["FineFees"].ToString(), Releasedate, dr["NationalNo"].ToString(), FullName, ApplcationID) ;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Manage_Detained_License_Screen_Load(object sender, EventArgs e)
        {
            _FillDate();
            lblrecord.Text = dataGridView1.Rows.Count.ToString();
            comfilter.SelectedIndex = 0;    
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            clstrnsfer.Mode = clstrnsfer.EnMode.Detain;
            DetainLicenseScreen frm  = new DetainLicenseScreen();
            frm.DataBack += RefreshData;
            frm.Show();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            clstrnsfer.Mode = clstrnsfer.EnMode.Release;
            Release_Detained_License_Screen frm = new Release_Detained_License_Screen();
            frm.DataBack += RefreshData;
            frm.Show();

        }
        private void RefreshData()
        {
            dataGridView1.Rows.Clear();
            _FillDate();
            lblrecord.Text = dataGridView1.Rows.Count.ToString();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            bool IsRelease = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[3].Value);
            if (IsRelease)
                releaseDetainedLicenseToolStripMenuItem.Enabled = false;
            else
                releaseDetainedLicenseToolStripMenuItem.Enabled = true;

        }

        private void showPersonDetilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsPeopleBU.GetPersonIDBYNationalNO(dataGridView1.CurrentRow.Cells[6].Value.ToString());
            InfoPersonScreen frm = new InfoPersonScreen(PersonID);
            frm.Show();
        }

        private void showLicenseDetilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalID = ClsApplicationBU.GetLocalIDByLicenselID(Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value));
            ShowLicenseScreen frm = new ShowLicenseScreen(LocalID, dataGridView1.CurrentRow.Cells[6].Value.ToString());
            frm.Show();
        }

        private void showPersonLicenseHisotryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            License_History_Screen frm = new License_History_Screen(clsPeopleBU.GetPersonIDBYNationalNO(dataGridView1.CurrentRow.Cells[6].Value.ToString()));
            frm.Show();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clstrnsfer.Mode = clstrnsfer.EnMode.Release;
            int licenseID = ClsLicenseBU.GetLicenseIDBYDetainID(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            Release_Detained_License_Screen frm = new Release_Detained_License_Screen(licenseID);
            frm.DataBack += RefreshData;
            frm.Show();
        }

        private void txtfilter_TextChanged(object sender, EventArgs e)
        {

            string searchValue = txtfilter.Text.Trim().ToLower();

            if (comfilter.SelectedIndex == 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Visible = true;
                }

            }
            else if (comfilter.SelectedIndex == 1)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Visible = string.IsNullOrEmpty(searchValue) || row.Cells["ClmDetainedID"].Value.ToString().ToLower().Contains(searchValue);
                }
            }
            else if (comfilter.SelectedIndex == 2)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Visible = string.IsNullOrEmpty(searchValue) || row.Cells["clmLicenseID"].Value.ToString().ToLower().Contains(searchValue);
                }
            }
            else if (comfilter.SelectedIndex == 3)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Visible = string.IsNullOrEmpty(searchValue) || row.Cells["clmName"].Value.ToString().ToLower().Contains(searchValue);
                }
            }
          
        }
    }
}
