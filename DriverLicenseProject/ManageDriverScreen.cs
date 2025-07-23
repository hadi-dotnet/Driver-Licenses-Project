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
    public partial class ManageDriverScreen : Form
    {
        public ManageDriverScreen()
        {
            InitializeComponent();
        }
        private void _FillData()
        {
            DataTable table = ClsDriversBU.GetAllDrivers();
            if(table != null )
            {
                foreach(DataRow row in table.Rows)
                {
                    string fullname = "";
                    if (row["ThirdName"] == DBNull.Value)
                        fullname = row["FirstName"].ToString() + " " + row["SecondName"].ToString() + " " + row["LastName"].ToString();
                    else
                        fullname = row["FirstName"].ToString() + " " + row["SecondName"].ToString() + " " + row["ThirdName"].ToString() + " " + row["LastName"].ToString();

                    DateTime Date = Convert.ToDateTime(row["IssueDate"]);
                    string StrDate = Date.ToString("yyyy-MM-dd");

                    dataGridView1.Rows.Add(row["DriverID"].ToString(), row["PersonID"].ToString(), row["NationalNo"].ToString(), fullname, StrDate, row["IsActive"]);


                }
            }
            lblrecord.Text = dataGridView1.Rows.Count.ToString();
          

        }
        private void ManageDriverScreen_Load(object sender, EventArgs e)
        {
            _FillData();
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
                    row.Visible = string.IsNullOrEmpty(searchValue) || row.Cells["ClmPersonID"].Value.ToString().ToLower().Contains(searchValue);
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
