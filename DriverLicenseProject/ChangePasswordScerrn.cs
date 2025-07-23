using DriverBusinessLayer;
using System;
using System.CodeDom;
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
    public partial class ChangePasswordScerrn : Form
    {
        public ChangePasswordScerrn()
        {
            InitializeComponent();
            informationcontrol.setid(clstrnsfer.Currentpersonid);
        }

        private void ChangePasswordScerrn_Load(object sender, EventArgs e)
        {
            lbluserid.Text = clstrnsfer.CurrentUserid.ToString();
            lblusername.Text = clstrnsfer.CurrentUserNAme.ToString();
            if (clstrnsfer.CurrentUserISACTIVE)
                lblisactive.Text = "yes";
            else
                lblisactive.Text = "NO";

        }

        private void btnchange_Click(object sender, EventArgs e)
        {
            if(!clsusersbusiness.ispasstrue(clstrnsfer.Currentpersonid,txtcurrentpassword.Text))
            {
                MessageBox.Show("The current password is incorrect.","ERROR",MessageBoxButtons.OK);
                return;
            }

            if(txtpassword.Text!=txtconfirmpass.Text)
            {

                MessageBox.Show("Passwords do not match.", "ERROR", MessageBoxButtons.OK);
                return;
            }

            if(clsusersbusiness.ChangePassword(clstrnsfer.CurrentUserid,txtpassword.Text))
            {
                MessageBox.Show("Changed seccessfully", "ERROR", MessageBoxButtons.OK);       

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
