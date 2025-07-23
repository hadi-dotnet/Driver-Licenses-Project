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
    public partial class ManageUsersScreen : Form
    {
        public ManageUsersScreen()
        {
            InitializeComponent();
        }

           
        private void button1_Click(object sender, EventArgs e)
        {
           

        }
        private void _filldata()
        {
            DataTable dt = clsusersbusiness.GetAllUsers();
            
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["ThirdName"] == DBNull.Value)
                {
                    
                    dataGridView1.Rows.Add(dr["userid"].ToString(), dr["personID"].ToString(), dr["FirstName"].ToString() + " " + dr["SecondName"].ToString() + " " +
                        dr["LastName"].ToString(), dr["username"].ToString(), dr["isactive"]);

                }
                else
                {
                    dataGridView1.Rows.Add(dr["userid"].ToString(), dr["personID"].ToString(), dr["FirstName"].ToString() + " " + dr["SecondName"].ToString() + " " + dr["ThirdName"].ToString() + " " +
                    dr["LastName"].ToString(), dr["username"].ToString(), dr["isactive"]);
                }

            }
            lblrecord.Text = dataGridView1.Rows.Count.ToString();
        }

        private void btnaddnew_Click(object sender, EventArgs e)
        {
            AddUserScrees frm = new AddUserScrees();
            frm.ShowDialog();
            dataGridView1.Rows.Clear();
            _filldata();
            
        }

        private void ManageUsersScreen_Load(object sender, EventArgs e)
        {
            _filldata();
            

        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUserScrees frm = new AddUserScrees();
            frm.ShowDialog();
            dataGridView1.Rows.Clear();
            _filldata();
          
            
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsusersbusiness.DeleteUser(Convert.ToInt32( dataGridView1.CurrentRow.Cells[0].Value)))
            {
             MessageBox.Show("Deleted Seccessfully", "INFO", MessageBoxButtons.OK);
                dataGridView1.Rows.Clear();
                _filldata();
            }
            else
                MessageBox.Show("Deleted NOT Seccessfully", "ERROR", MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void txtfilter_TextChanged(object sender, EventArgs e)
        {
            if (txtfilter.Text != "")
            {
                if (comfilter.SelectedIndex == 1)
                {
                    dataGridView1.DataSource = clsPeopleBU.FindByIDBU(txtfilter.Text);
                    lblrecord.Text = dataGridView1.Rows.Count.ToString();
                }
                if (comfilter.SelectedIndex == 2)
                {
                    dataGridView1.DataSource = clsPeopleBU.FindByNameBU(txtfilter.Text);
                    lblrecord.Text = dataGridView1.Rows.Count.ToString();
                }
                if (comfilter.SelectedIndex == 3)
                {
                    dataGridView1.DataSource = clsPeopleBU.FindByNationalBU(txtfilter.Text);
                    lblrecord.Text = dataGridView1.Rows.Count.ToString();
                }

            }
            else
            {
                dataGridView1.DataSource = clsPeopleBU.GetAllPeople();
                lblrecord.Text = dataGridView1.Rows.Count.ToString();
            }

        }
    }
}
