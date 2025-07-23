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
    public partial class Local_Driving_License_Application : Form
    {
       public enum enMode
        {
            vision=1,writen=2,street=3
                
        }
        public enMode mode;
     
        public Local_Driving_License_Application()
        {
            InitializeComponent();
           
           
        }
       
        
        
        private void _filldata()
        {
            DataTable dt = ClsApplicationBU.getallaplication();
            if(dt!=null)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    string fullname = "",status="";
                    if (dr["ThirdName"] == DBNull.Value)
                        fullname = dr["FirstName"].ToString() + " "+ dr["SecondName"].ToString() +" "+ dr["LastName"].ToString();
                    else
                        fullname = dr["FirstName"].ToString() +" "+ dr["SecondName"].ToString() +" "+ dr["ThirdName"].ToString() +" "+ dr["LastName"].ToString();

                    if (Convert.ToInt32( dr["ApplicationStatus"]) == 1)
                        status = "new";
                    else if (Convert.ToInt32(dr["ApplicationStatus"]) == 2)
                        status = "canceld";
                    else if (Convert.ToInt32(dr["ApplicationStatus"]) == 3)
                        status ="complete";



                    dataGridView1.Rows.Add(dr["localID"].ToString(), dr["ClassName"].ToString(), dr["NationalNo"].ToString(), fullname, dr["ApplicationDate"].ToString(), dr["passedTest"].ToString(),status) ;
                }
               
            }
            lblrecord.Text = dataGridView1.Rows.Count.ToString();
            comfilter.SelectedIndex = 0;
        }
        private void Local_Driving_License_Application_Load(object sender, EventArgs e)
        {
            _filldata();
           
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if(ClsApplicationBU.IsApplicationCanceled(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)))
            {
                ShowLicense.Enabled=false;
                deleteApplicationToolStripMenuItem.Enabled=true;
                SechduleTest.Enabled = false;
                cancelApplicationToolStripMenuItem.Enabled = false;
                IssueDrivingLicense.Enabled=false;
                return;

            }

          sbyte NumberOfPassed = ClsApplicationBU.GetPassedTest(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            
            if(NumberOfPassed==0)
            {
                VisionTest.Enabled = true;
                WrittenTest.Enabled = false;
                StreetTest.Enabled = false;
                IssueDrivingLicense.Enabled = false;
               SechduleTest.Enabled = true;
                ShowLicense.Enabled = false;
                deleteApplicationToolStripMenuItem.Enabled = true;
                cancelApplicationToolStripMenuItem.Enabled = true;
            }
            else if (NumberOfPassed==1)
            {
                VisionTest.Enabled = false;
                WrittenTest.Enabled = true;
                StreetTest.Enabled = false;
                IssueDrivingLicense.Enabled = false;
               SechduleTest.Enabled = true;
                ShowLicense.Enabled = false;
                deleteApplicationToolStripMenuItem.Enabled = true;
                cancelApplicationToolStripMenuItem.Enabled = true;
            }
            else if (NumberOfPassed==2)
            {
                VisionTest.Enabled = false;
                WrittenTest.Enabled = false;
                StreetTest.Enabled = true;
                IssueDrivingLicense.Enabled = false;
               SechduleTest.Enabled = true;
                ShowLicense.Enabled = false;
                deleteApplicationToolStripMenuItem.Enabled = true;
                cancelApplicationToolStripMenuItem.Enabled = true;
            }
            else if (NumberOfPassed==3)
            {
               SechduleTest.Enabled = false;
                if (ClsApplicationBU.IsApplicationComplete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value))) 
                {
                    IssueDrivingLicense.Enabled = false;
                    ShowLicense.Enabled = true;
                    deleteApplicationToolStripMenuItem.Enabled = false;
                    cancelApplicationToolStripMenuItem.Enabled = false;
                }
                else
                {
                    deleteApplicationToolStripMenuItem.Enabled = true;
                    cancelApplicationToolStripMenuItem.Enabled = true;
                    IssueDrivingLicense.Enabled = true;
                        ShowLicense.Enabled = false;

                }
            }
          
        }

        private void showApllicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            InfoApplicationScreen frm = new InfoApplicationScreen(Convert.ToInt32( dataGridView1.CurrentRow.Cells[0].Value));
            frm.Show();

        }

        private void btnaddnew_Click(object sender, EventArgs e)
        {
            
            LocalLicenseScrees frm = new LocalLicenseScrees();
            frm.ShowDialog();
            dataGridView1.Rows.Clear();
            _filldata();
        }

        private void txtfilter_TextChanged(object sender, EventArgs e)
        {

            string searchValue = txtfilter.Text.Trim().ToLower();

            if(comfilter.SelectedIndex==0)
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
                    row.Visible = string.IsNullOrEmpty(searchValue) || row.Cells["ClmAppID"].Value.ToString().ToLower().Contains(searchValue);
                }
            }
            else if (comfilter.SelectedIndex == 2)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Visible = string.IsNullOrEmpty(searchValue) || row.Cells["ClmFullName"].Value.ToString().ToLower().Contains(searchValue);
                }
            }
            else if (comfilter.SelectedIndex == 3)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Visible = string.IsNullOrEmpty(searchValue) || row.Cells["ClmNationalNO"].Value.ToString().ToLower().Contains(searchValue);
                }
            }
            else if (comfilter.SelectedIndex == 4)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Visible = string.IsNullOrEmpty(searchValue) || row.Cells["ClmStatus"].Value.ToString().ToLower().Contains(searchValue);
                }
            }






        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = enMode.vision;
            Vision_Test_Application_Screes frm = new Vision_Test_Application_Screes(Convert.ToInt32( dataGridView1.CurrentRow.Cells[0].Value),(int)mode);
            frm.DataBack += RefreshData;
            frm.Show();
           
            
        }

        private void lblrecord_Click(object sender, EventArgs e)
        {

        }

        private void scheduleWritenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = enMode.writen;
            Vision_Test_Application_Screes frm = new Vision_Test_Application_Screes(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value), (int)mode);
            frm.DataBack += RefreshData;
            frm.Show();
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = enMode.street;
            Vision_Test_Application_Screes frm = new Vision_Test_Application_Screes(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value), (int)mode);
            frm.DataBack += RefreshData;
            frm.Show();
        }

        private void Local_Driving_License_Application_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void IssueDrivingLicense_Click(object sender, EventArgs e)
        {
            Issue_driving_license_screen frm = new Issue_driving_license_screen(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            frm.DataBack += RefreshData;
            frm.Show();
            //DateTime hadi = DateTime.Today;
            //DateTime hadi2 = hadi.AddYears(10);
            //MessageBox.Show(hadi2.ToString("yyyy-MM-dd"));

        }
        private void RefreshData()
        {
            dataGridView1.Rows.Clear();
            _filldata();
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClsApplicationBU.DeleteApplication(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)))
                MessageBox.Show("Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Deleted NOT Successfully", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            RefreshData();

        }

        private void comfilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comfilter.SelectedIndex == 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Visible = true;
                }

            }
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClsApplicationBU.SetApplicationCancel(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value))) 
                MessageBox.Show("Update Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Update NOT Successfully", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            RefreshData();



        }

        private void ShowLicense_Click(object sender, EventArgs e)
        {
            ShowLicenseScreen frm = new ShowLicenseScreen(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),(dataGridView1.CurrentRow.Cells[2].Value).ToString());
            frm.Show();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            License_History_Screen frm = new License_History_Screen(dataGridView1.CurrentRow.Cells[2].Value.ToString()) ;
            frm.Show();
        }
    }
}
