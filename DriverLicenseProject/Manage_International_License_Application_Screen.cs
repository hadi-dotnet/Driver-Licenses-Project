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
    public partial class Manage_International_License_Application_Screen : Form
    {
        public Manage_International_License_Application_Screen()
        {
            InitializeComponent();
        }

        private void _FillDate()
        {
            DataTable Table = clsInternationalLicenseBU.GetAllInternationalLicense();
            if(Table != null )
            {
                foreach(DataRow row in Table.Rows)
                {
                    DateTime IssueDate = Convert.ToDateTime(row["IssueDate"]);
                    DateTime EXDate = Convert.ToDateTime(row["ExpirationDate"]);

                    dataGridView1.Rows.Add(row["InternationalLicenseID"].ToString(), row["ApplicationID"].ToString(), row["DriverID"].ToString(), row["IssuedUsingLocalLicenseID"].ToString(),IssueDate.ToString("yyyy-MM-dd"), EXDate.ToString("yyyy-MM-dd"), row["IsActive"].ToString()); 
                }
            }
            lblrecord.Text = dataGridView1.Rows.Count.ToString();
        }

        private void Manage_International_License_Application_Screen_Load(object sender, EventArgs e)
        {
            _FillDate();
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
                    row.Visible = string.IsNullOrEmpty(searchValue) || row.Cells["clmInterLicenseID"].Value.ToString().ToLower().Contains(searchValue);
                }
            }
            else if (comfilter.SelectedIndex == 2)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Visible = string.IsNullOrEmpty(searchValue) || row.Cells["clmApplicationID"].Value.ToString().ToLower().Contains(searchValue);
                }
            }
            else if (comfilter.SelectedIndex == 3)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Visible = string.IsNullOrEmpty(searchValue) || row.Cells["clmDriverID"].Value.ToString().ToLower().Contains(searchValue);
                }
            }
            else if (comfilter.SelectedIndex == 4)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Visible = string.IsNullOrEmpty(searchValue) || row.Cells["clmLocalLicenseID"].Value.ToString().ToLower().Contains(searchValue);
                }
            }


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
    }
}
