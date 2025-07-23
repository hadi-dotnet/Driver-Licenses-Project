using DriverBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverLicenseProject
{
    public partial class Manage_Application_Type : Form
    {
        public Manage_Application_Type()
        {
            InitializeComponent();
        }

        private void _FillData()
        {
            DataTable dt = ClsApplicationBU.GetALlApplicationType();
            foreach(DataRow dr in dt.Rows)
            {
                dataGridView1.Rows.Add(dr["applicationtypeid"].ToString(), dr["applicationtypetitle"].ToString(), dr["applicationfees"].ToString());
            }

        }

        private void Manage_Application_Type_Load(object sender, EventArgs e)
        {
            _FillData();
            lblrecord.Text = dataGridView1.Rows.Count.ToString();
        }

        private void editFeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edit_ApplicationType_Screen frm = new Edit_ApplicationType_Screen(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value), dataGridView1.CurrentRow.Cells[1].Value.ToString());
            frm.DataBack += _RefreshData;
            frm.Show();
        }
        private void _RefreshData()
        {
            dataGridView1.Rows.Clear();
            _FillData();
            lblrecord.Text = dataGridView1.Rows.Count.ToString();
        }
    }
}
