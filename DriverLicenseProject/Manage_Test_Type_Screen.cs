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
    public partial class Manage_Test_Type_Screen : Form
    {
        public Manage_Test_Type_Screen()
        {
            InitializeComponent();
        }

        private void _FillDate()
        {
            DataTable dt = ClsTakeTestBU.GetAllTestsType();
            foreach (DataRow dr in dt.Rows)
            {
                dataGridView1.Rows.Add(dr["TestTypeID"].ToString(), dr["TestTypeTitle"].ToString(), dr["TestTypeDescription"].ToString(), dr["TestTypeFees"].ToString());
            }
        }

        private void Manage_Test_Type_Screen_Load(object sender, EventArgs e)
        {
            _FillDate();
            lblrecord.Text = dataGridView1.Rows.Count.ToString();
        }

        private void editFeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            Edit_Fees_OF_TestType_Screen frm = new Edit_Fees_OF_TestType_Screen(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value), dataGridView1.CurrentRow.Cells[1].Value.ToString());
            frm.DataBack += _RefreshData;
            frm.Show();
        }
        private void _RefreshData()
        {
            dataGridView1.Rows.Clear();
            _FillDate();
            lblrecord.Text = dataGridView1.Rows.Count.ToString();
        }
    }
}
