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
    public partial class Edit_ApplicationType_Screen : Form
    {
        int ApplicationID = 0;
        string Name = "";

       
        public delegate void Data();

        public event Data DataBack;

        public Edit_ApplicationType_Screen(int ApplicationID,string ApplicationNAme)
        {
            InitializeComponent();
            this.ApplicationID = ApplicationID;
            this.Name = ApplicationNAme;    

        }

        private void Edit_ApplicationType_Screen_Load(object sender, EventArgs e)
        {
            lblID.Text = ApplicationID.ToString();
            lblApplicationName.Text = Name;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtfees.Text != "")
            {
                if (ClsApplicationBU.UpdateFeesOfApplicationType(Convert.ToInt32(txtfees.Text), Convert.ToInt32(lblID.Text))) 
                    MessageBox.Show("Fees Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("You Have To Enter Fees", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Edit_ApplicationType_Screen_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataBack?.Invoke();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
