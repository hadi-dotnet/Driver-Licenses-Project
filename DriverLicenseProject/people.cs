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
    public partial class people : Form
    {
        public people()
        {
            InitializeComponent();
        }
        private void _filldata()
        {
          dataGridView1.DataSource=clsPeopleBU.GetAllPeople();
            lblrecord.Text=dataGridView1.Rows.Count.ToString();
        }

        private void people_Load(object sender, EventArgs e)
        {
            if (clsPeopleBU.GetAllPeople() != null)
            {
                dataGridView1.DataSource = clsPeopleBU.GetAllPeople();
            }
            else
                MessageBox.Show("THERE is NO people", "ERROR", MessageBoxButtons.OK);
            lblrecord.Text = dataGridView1.Rows.Count.ToString();
        }

        private void comfilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comfilter.SelectedIndex!=0)
                 txtfilter.Visible = true;
            else
                txtfilter.Visible = false;
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

        private void btnaddnew_Click(object sender, EventArgs e)
        {
            addnewscreen frm = new addnewscreen();
            frm.ShowDialog();
            _filldata();

        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewscreen frm = new addnewscreen();
            frm.ShowDialog();
            _filldata();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewscreen add = new addnewscreen((int)dataGridView1.CurrentRow.Cells[0].Value);
            add.ShowDialog();
            _filldata();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsPeopleBU.deletepesonBU((int)dataGridView1.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("deleted successfully");
            }
            else
                MessageBox.Show("deleted Not successfully");
            _filldata();
        }

        private void showDatailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoPersonScreen frm = new InfoPersonScreen((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
